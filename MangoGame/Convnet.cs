using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MangoGame
{
    class Convnet
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
        private static extern int CVN_getUDPc2cport();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int CVN_getTCPc2cport();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_Login(string cvnurl, string username, string password);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_Message(DelegateGetCVNmessage Address);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_InitClientServer(int tcpport, int udpport);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_Logout();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_ConnectUser(int Userid, string password);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_DisConnectUser(int Userid);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern long CVN_CountSend();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern long CVN_CountRecive();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_FreeRes();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern bool CVN_InitEther();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern bool diduserinlist(int userid);//返回值一直是true？

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string GetCVNIPByUserID(int userid);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string CVN_GetOnlineUserinfo();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string CVN_GetUserinfo();

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_ApplyForPeer(int peerid, string allpyinfo);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_ApplyForJoinGroup(int groupid, string allpyinfo);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_ConfirmJoinPeer(int peerid);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_ConfirmJoinGroup(int userid, int groupid);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_RegistUser(string serverurl, string username, string password, string nick, string desc);

        [DllImport("cvn_main.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void CVN_QuitGroup(int groupid);

        public delegate void DelegateGetCVNmessage(int messagetype, string messagestring);

        public FormLogin FormLogin
        {
            get;
            set;
        }

        public FormRegister FormRegister
        {
            get;
            set;
        }

        public FormMain FormMain
        {
            get;
            set;
        }

        private void GetCVNmessage(int messagetype, string messagestring)
        {
            { string tmpstr = string.Empty; }
            List<string> strlist = new List<string>();
            

            //字符串 += messagetype.ToString() + " :" + messagestring + "\r\n";
            
        }
    }
}
