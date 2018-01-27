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

namespace 偏振控制器
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbState = new System.Windows.Forms.ListBox();
            this.btnStartListen = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.btnStopListen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1Speed = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "监听端口：";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(83, 33);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 21);
            this.textBoxIP.TabIndex = 2;
            this.textBoxIP.TextChanged += new System.EventHandler(this.textBoxIP_TextChanged);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(83, 66);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 21);
            this.textBoxPort.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbState);
            this.groupBox1.Location = new System.Drawing.Point(212, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 73);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器状态";
            // 
            // lbState
            // 
            this.lbState.FormattingEnabled = true;
            this.lbState.ItemHeight = 12;
            this.lbState.Location = new System.Drawing.Point(0, 20);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(233, 52);
            this.lbState.TabIndex = 0;
            // 
            // btnStartListen
            // 
            this.btnStartListen.Location = new System.Drawing.Point(15, 202);
            this.btnStartListen.Name = "btnStartListen";
            this.btnStartListen.Size = new System.Drawing.Size(75, 23);
            this.btnStartListen.TabIndex = 7;
            this.btnStartListen.Text = "开始监听";
            this.btnStartListen.UseVisualStyleBackColor = true;
            this.btnStartListen.Click += new System.EventHandler(this.btnStartListen_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(242, 202);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(83, 23);
            this.right.TabIndex = 8;
            this.right.Text = "正转";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(242, 236);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(83, 23);
            this.left.TabIndex = 9;
            this.left.Text = "反转";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // btnStopListen
            // 
            this.btnStopListen.Location = new System.Drawing.Point(15, 236);
            this.btnStopListen.Name = "btnStopListen";
            this.btnStopListen.Size = new System.Drawing.Size(75, 23);
            this.btnStopListen.TabIndex = 10;
            this.btnStopListen.Text = "停止监听";
            this.btnStopListen.UseVisualStyleBackColor = true;
            this.btnStopListen.Click += new System.EventHandler(this.btnStopListen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "速度设置：";
            // 
            // textBox1Speed
            // 
            this.textBox1Speed.Location = new System.Drawing.Point(224, 139);
            this.textBox1Speed.Name = "textBox1Speed";
            this.textBox1Speed.Size = new System.Drawing.Size(47, 21);
            this.textBox1Speed.TabIndex = 12;
            this.textBox1Speed.TextChanged += new System.EventHandler(this.textBox1Speed_TextChanged);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(60, 139);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(56, 21);
            this.textBoxCount.TabIndex = 13;
            this.textBoxCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "步数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "速度：";
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(337, 139);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(56, 21);
            this.textBoxSpeed.TabIndex = 16;
            this.textBoxSpeed.Text = "500";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "移动";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 281);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBox1Speed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStopListen);
            this.Controls.Add(this.left);
            this.Controls.Add(this.right);
            this.Controls.Add(this.btnStartListen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "偏振控制器";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbState;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button btnStopListen;

        //全局变量
        private Socket socket;
        private Socket newSocket;
        private IPEndPoint server;
        Thread thread;
        private Label label4;
        private TextBox textBox1Speed;
        private TextBox textBoxCount;
        private Label label5;
        private Label label6;
        private TextBox textBoxSpeed;
        private Label label3;
    }
}

