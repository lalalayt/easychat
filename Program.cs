using OMCS.Passive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat2._0
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IMultimediaManager multimediaManager = MultimediaManagerFactory.GetSingleton();
            multimediaManager.ChannelMode = OMCS.Passive.ChannelMode.P2PDisabled;
            Application.Run(new login(multimediaManager));
        }
    }
}
