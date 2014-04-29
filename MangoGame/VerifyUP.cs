using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MangoGame
{
    class VerifyUP
    {
        public VerifyUP(string username, string password1, string password2)
        {
            errorVerUsername = VerUsername(username);
            errorVerPassword = VerPassword(password1, password2);
        }

        public int errorVerUsername
        {
            set;
            get;
        }

        public int errorVerPassword
        {
            set;
            get;
        }

        // 验证账号枚举
        // success/0 = 验证成功; invalidCharacter/1 = 包含非法字符; invalidLength/2 = 长度不满足;
        /*
        public enum errorVerUsername : int
        {
            success = 0,
            invalidCharacter = 1,
            invalidLength = 2,
        }
        */

        // 验证密码枚举
        // success/0 = 验证成功; invalidCharacter/1 = 包含非法字符; invalidLength/2 = 长度不满足; mismatch/3 = 重复密码不匹配
        /*
        public enum errorVerPassword : int
        {
            success = 0,
            invalidCharacter = 1,
            invalidLength = 2,
            mismatch = 3,
        }
        */

        // 验证账号函数
        private int VerUsername(string username)
        {
            Regex usernameregex = new Regex("^[a-zA-Z0-9\u4e00-\u9fa5]+$");
            Match m = usernameregex.Match(username);
            if (System.Text.Encoding.Default.GetBytes(username).Length > 10 || System.Text.Encoding.Default.GetBytes(username).Length <3)
            {
                return 2;
            }
            else if (m.Success)
            {
                return 0;
            }
            else 
            {
                return 1;
            }
                
        }

        // 验证密码函数
        private int VerPassword(string password1, string password2)
        {
            Regex passwordregex = new Regex("^[a-zA-Z0-9]+$");
            Match m = passwordregex.Match(password1);

            if(password1 != password2)
            {
                return 3;
            }
            else if (password1.Length > 10 || password1.Length < 3)
            {
                return 2;
            }
            else if (m.Success)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }
    }
}
