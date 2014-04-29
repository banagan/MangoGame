using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;


namespace MangoGame
{
    public unsafe partial class FormMain : Form
    {
        
        struct TPeerGroupInfo
        {
            int GroupID;
            int Creator;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
            string GroupName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            string GroupDes;
            bool NeedPass;
        }
        struct TUserInfo
        {
            bool connecting;
            int UserID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
            string UserName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
            string AhthorPassword;
            bool ISOnline;
            bool Connected;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
            string MacAddress;

            int Con_ConnectionType;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            string Con_IP;
            int Con_port;
            int Con_RetryTime;
            long Con_send;
            long Con_recv;
            int tvUserReconn;
            int peerport;
            void* con_AContext;
            DateTime con_Lastrecv;
            void* clientDM;

            public void TryConnect_start() { }
            public void RefInfo_whenConnect(string ip, int port, string Mac) { }
            public void DissconnectPeer() { }
            public void sendtopeer(char[] buffer, int buflength) { }
            public void RetryTimer(object Sender) { }
        }

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int CVN_getUDPc2cport();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int CVN_getTCPc2cport();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_Login(string cvnurl, string username, string password);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_Message(DelegateGetCVNmessage Address);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_InitClientServer(int tcpport, int udpport);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_Logout();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_ConnectUser(int Userid, string password);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_DisConnectUser(int Userid);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern long CVN_CountSend();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern long CVN_CountRecive();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_FreeRes();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool CVN_InitEther();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool diduserinlist(int userid);//返回值一直是true？

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetCVNIPByUserID(int userid);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string CVN_GetOnlineUserinfo();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string CVN_GetUserinfo();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_ApplyForPeer(int peerid, string allpyinfo);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_ApplyForJoinGroup(int groupid, string allpyinfo);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_ConfirmJoinPeer(int peerid);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_ConfirmJoinGroup(int userid, int groupid);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_RegistUser(string serverurl, string username, string password, string nick, string desc);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void CVN_QuitGroup(int groupid);

        FormLogin formLogin = new FormLogin();

        public delegate void DelegateGetCVNmessage(int messagetype, string messagestring);
        public void GetCVNmessage(int messagetype, string messagestring)
        {
            // messagetype 客户端状态消息
            // 2 登陆失败
            // 18 返回用户组信息
            // 1000 与服务器断开连接
            // 1002 peer用户连接成功
            // 1003 peer用户连接成功
            // 1004 peer用户连接断开
            // 1005 退出登录end
            // 1006 退出登录start
            // 1007 peer用户重连尝试
            // 1008 断线重连成功
            // 1009 成功登陆
            // 1010 网络类型确定
            // 1011 网络检查开始
            // 1012 网络检查结束
            // 1111 网卡未安装
            // 1113 其他消息

            switch(messagetype)
            {
                // 如果登陆失败,则弹框通知
                case 2:
                    MessageBox.Show("登陆失败,用户名或密码错误");
                    break;
                // 登陆成功
                case 1009:
                    formLogin.Hide();
                    break;
                default:
                    break;
            }

            switch(messagestring)
            {
                case "regist success":
                    MessageBox.Show("注册成功!");

                    break;
                case "regist fail":
                    MessageBox.Show("注册失败,用户名已存在.");
                    break;
                default:
                    break;
            }
        }
            
        public FormMain()
        {
            InitializeComponent();
            DelegateGetCVNmessage dgcvn = new DelegateGetCVNmessage(GetCVNmessage);
            CVN_Message(dgcvn);
            CVN_InitClientServer(53, 53);
            CVN_InitEther();
            GC.KeepAlive(dgcvn);

            formLogin.ShowDialog();
        }

    }
}
