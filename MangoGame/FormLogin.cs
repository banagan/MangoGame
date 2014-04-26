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

        }

        // 注册
        private void lblRegister_Click(object sender, EventArgs e)
        {

        }

        // 当鼠标进入注册标签区域
        private void lblRegister_MouseEnter(object sender, EventArgs e)
        {
            
        }

        // 当鼠标离开注册标签区域
        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
