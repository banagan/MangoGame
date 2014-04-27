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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Convnet convnet = new Convnet();
            Convnet.DelegateGetCVNmessage dgcvn = new Convnet.DelegateGetCVNmessage(convnet.GetCVNmessage);
            Convnet.CVN_Message(dgcvn);
            Convnet.CVN_InitClientServer(600, 500);
            Convnet.CVN_InitEther();
            GC.KeepAlive(dgcvn);

            FormLogin fm = new FormLogin();
            fm.Show();
        }
    }
}
