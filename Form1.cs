using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Timers; 

namespace 偏振控制器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.lbState.Items.Clear();

            //this.textBoxTime.Text = DateTime.Now.ToLongTimeString().ToString(); 
            this.textBoxIP.Text = GetIpAddress();
            this.textBoxPort.Text = "8080";
        }

        private string GetIpAddress()
        {       
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }

            return AddressIP;


        }

        private void btnStartListen_Click(object sender, EventArgs e)
        {
            this.btnStartListen.Enabled = false;
            IPAddress ip = IPAddress.Parse(this.textBoxIP.Text);

            server = new IPEndPoint(ip, Int32.Parse(this.textBoxPort.Text));
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(server);

            //监听客户端连接
            socket.Listen(10);
            

            //创建一个线程接收客户信息
            Control.CheckForIllegalCrossThreadCalls = false;//Added by ZXM on May 20,2010

            thread = new Thread(new ThreadStart(AcceptMessage));
            thread.IsBackground = true;
            thread.Start();
        }

        private void AcceptMessage()
        {
            try
            {
                newSocket = socket.Accept();
            }
            catch 
            { 
            }

            //显示客户IP和端口号
            this.lbState.Items.Add("与客户 " + newSocket.RemoteEndPoint.ToString() + " 建立连接");

            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int r = newSocket.Receive(buffer);
                    if (r == 0)
                    {
                        MessageBox.Show("连接断开");
                        break;
                    }
                    string strRec = Encoding.Default.GetString(buffer, 0, r);
                   

                    if (strRec[2] == '+')
                        this.textBoxCount.Text = strRec.Substring(3, r-5);

                    if (strRec[2] == 'V')
                        this.textBoxSpeed.Text = strRec.Substring(3, r - 5);

                    this.label3.Text = this.textBoxCount.Text + "/16";

                    right.Enabled = true;
                }
                catch
                {
                    this.lbState.Items.Add("与客户断开连接");
                    break;
                }
            }
        }

        private void btnStopListen_Click(object sender, EventArgs e)
        {
           
            this.btnStartListen.Enabled = true;
            this.right.Enabled = true;
          
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                if (newSocket.Connected)
                {
                    newSocket.Close();
                    thread.Abort();
                }
            }

            catch
            {

                socket.Close();
                //newSocket.Close();
                thread.Abort();
                              
            }
            
        }

        private void right_Click(object sender, EventArgs e)
        {
            this.right.Enabled = false;
            string cmdst = ":F+#";
            try
            {                
                byte[] buffer = Encoding.Default.GetBytes(cmdst);
                newSocket.SendTo(buffer, server);
            }
            catch
            {
                MessageBox.Show("监听尚未开始，关闭无效!");
                this.right.Enabled = true;
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            string cmdst = ":F-#";
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(cmdst);
                newSocket.SendTo(buffer, server);
            }
            catch
            {
                MessageBox.Show("监听尚未开始，关闭无效!");
            }
        }

        private void textBoxIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1Speed_TextChanged(object sender, EventArgs e)
        {
                        
            string strGetSpeed = this.textBox1Speed.Text.ToString();           
            string strEnd = ":FV" + strGetSpeed + "#";
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(strEnd);
                newSocket.SendTo(buffer, server);
            }
            catch
            {
                socket.Close();
                MessageBox.Show("监听尚未开始，关闭无效!");
            }
        }

        private void rtbAccept_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label7.Text = DateTime.Now.ToLongTimeString().ToString(); 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                if (newSocket.Connected)
                {
                    newSocket.Close();
                    thread.Abort();
                }
            }
            catch
            { }
        }

    }
}
