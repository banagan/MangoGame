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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        // 注册按钮
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 定义局部账号变量
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string passwordRepeat = txtPasswordRepeat.Text;
            // 实例化本地验证verifyUP
            VerifyUP verifyUP = new VerifyUP(username, password, passwordRepeat);

            // 定义局部判断变量
            int validUsername = 0;
            int validPassword = 0;



            // 本地判断用户名
            switch (verifyUP.errorVerUsername)
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
            switch (verifyUP.errorVerPassword)
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
                case 3:
                    MessageBox.Show("两次密码输入不一致");
                    break;
                default:
                    break;
            }

            // 通过验证,进入注册
            if (validUsername == 1 && validPassword == 1)
            {
                FormMain.CVN_RegistUser("sh.convnet.net:23", username, password, username, "备注"); ;
            }
        }
    }
}
