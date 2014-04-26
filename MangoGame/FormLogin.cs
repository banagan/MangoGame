using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            
        }

        // 启用ICMP协议
        private void enableICMP()
        {

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
