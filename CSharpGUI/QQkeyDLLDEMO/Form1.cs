using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection; 
using System.Reflection.Emit;
using System.Diagnostics;

namespace QQkeyDLLDEMO
{
    public partial class Form1 : Form
    {
        
        string DLLpath = Path.Combine(Application.StartupPath, @"BigJB.dll");
        public Form1()
        {
            if (!File.Exists(DLLpath))
            {
                File.WriteAllBytes(DLLpath, Properties.Resources.QQkeyDll);
            }
            InitializeComponent();
        }
        [DllImport("BigJB.dll", EntryPoint = "GetClientUin")]
        static extern string GetClientUin(int pid);
        [DllImport("BigJB.dll", EntryPoint = "GetCookies")]
        static extern string GetCookies(int qqnum,string qqkey);
        [DllImport("BigJB.dll", EntryPoint = "GetClientKey")]
        static extern string GetClientKey(int pid);
        [DllImport("BigJB.dll", EntryPoint = "GetClientName")]
        static extern string GetClientName(long qqnum,int pid);
        [DllImport("BigJB.dll", EntryPoint = "GetHttpKey")]
        static extern string GetHttpKey(int pid);
        public static int GetTIMpid() {
            Process[] all = Process.GetProcessesByName("TIM");
            int pid;
            pid = all[0].Id;
            return pid;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("By sysR@M\n QQ号:"+GetClientUin(7072)+" QQ名:"+GetClientName(Convert.ToInt32(GetClientUin(7072)),7072)+"\nQQClientKey:"+GetClientKey(7072)+"\nQQHttpKey:"+GetHttpKey(7072));
            //MessageBox.Show(GetOnepid("TIM.exe").ToString());
            MessageBox.Show("By sysR@M\nQQ号:"+GetClientUin(GetTIMpid()));
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            File.Delete(DLLpath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By sysR@M\nQQ名:"+ GetClientName(long.Parse(GetClientUin(GetTIMpid())), GetTIMpid()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By sysR@M\nClientKey:"+GetClientKey(GetTIMpid()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By sysR@M\nHttpKey:"+GetHttpKey(GetTIMpid()));
        }
    }
}
