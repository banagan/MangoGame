using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangoGame
{
    class VerifyUP
    {
        // 验证账号枚举
        // success/0 = 验证成功; invalidCharacter/1 = 包含非法字符; invalidLength/2 = 长度不满足;
        public enum errorVerUsername : int
        {
            success = 0,
            invalidCharacter = 1,
            invalidLength = 2,
        }

        // 验证密码枚举
        // success/0 = 验证成功; invalidCharacter/1 = 包含非法字符; invalidLength/2 = 长度不满足; mismatch/3 = 重复密码不匹配
        public enum errorVerPassword : int
        {
            success = 0,
            invalidCharacter = 1,
            invalidLength = 2,
            mismatch = 3,
        }

        // 验证账号函数
        private int VerUsername()
        {
            return 0;
        }

        // 验证密码函数
        private int VerPassword()
        {
            return 0;
        }

        // 验证重复密码函数
        // 0 = 验证成功; 1 = 
        private int VerPasswordRepeat()
        {
            return 0;
        }
    }
}
