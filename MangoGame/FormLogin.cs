using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MangoGame
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            // 如果勾选"记住密码"
            if(chkPassword.Checked)
            {
                rememberPassword();
            }

            // 启用ICMP协议，运行用户互相PING。
            enableICMP();


        }

        // 记住密码
        private void rememberPassword()
        {
            
        }

        // 添加防火墙例外
        private void addFirewallException()
        {
            string conmond = @"netsh firewall set allowedprogram C:\Games\War3\war3.exe war3 ENABLE";//设定cmd输入
            //程序路径需要修改，从textbox中读取！！！！
            Process process = new Process();//实例
            process.StartInfo.CreateNoWindow = true;//设定不显示窗口
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "cmd.exe"; //设定程序名  
            process.StartInfo.RedirectStandardInput = true;   //重定向标准输入
            process.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
            process.StartInfo.RedirectStandardError = true;//重定向错误输出
            process.Start();
            process.StandardInput.WriteLine(conmond);//执行的命令
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            process.Close();
        }

        // 启用ICMP协议
        private void enableICMP()
        {
            string conmond = "netsh firewall set icmpsetting 8";//设定cmd输入
            Process process = new Process();//实例
            process.StartInfo.CreateNoWindow = true;//设定不显示窗口
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "cmd.exe"; //设定程序名  
            process.StartInfo.RedirectStandardInput = true;   //重定向标准输入
            process.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
            process.StartInfo.RedirectStandardError = true;//重定向错误输出
            process.Start();
            process.StandardInput.WriteLine(conmond);//执行的命令
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            process.Close();
        }

        // 登陆
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 实例化本地验证verifyUP
            VerifyUP verifyUP = new VerifyUP();

            // 定义局部判断变量
            int validUsername = 0;
            int validPassword = 0;

            // 定义局部账号变量
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // 本地判断用户名
            switch(verifyUP.VerUsername(username))
            {
                case 0:
                    validUsername = 1;
                    break;

                case 1:
                    MessageBox.Show("用户名包含非法字符");
                    break;

                case 2:
                    MessageBox.Show("用户名长度不正确");
                    break;

                default:
                    break;
            }

            // 本地判断密码
            switch (verifyUP.VerPassword(password))
            {
                case 0:
                    validPassword = 1;
                    break;

                case 1:
                    MessageBox.Show("密码包含非法字符");
                    break;

                case 2:
                    MessageBox.Show("密码长度不正确");
                    break;

                default:
                    break;
            }
            
            // 通过验证,进入登陆
            if(validUsername == 1 && validPassword == 1)
            {    
                FormMain.CVN_Login("sh.convnet.net:23", username, password);
            }
            
        }


        // 注册
        private void lblRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
        }

        // 当鼠标进入注册标签区域
        private void lblRegister_MouseEnter(object sender, EventArgs e)
        {

        }

        // 当鼠标离开注册标签区域
        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            
        }

        // 关闭登陆窗口,退出程序
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
