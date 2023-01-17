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
            String QQnum = GetClientUin(GetTIMpid());
            MessageBox.Show("By sysR@M\nQQ号:"+QQnum);
            if (checkBox1.Checked) {
                textBox1.Text = QQnum;
            }
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
            String CK = GetClientKey(GetTIMpid());
            MessageBox.Show("By sysR@M\nClientKey:" + CK);
            //if (checkBox1.Checked) {
            //    textBox2.Text = CK;
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String HK = GetHttpKey(GetTIMpid());
            MessageBox.Show("By sysR@M\nHttpKey:"+HK);
            if (checkBox1.Checked) {
                textBox2.Text = HK;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ptlogin2.qq.com/jump?clientuin="+textBox1.Text+ "&clientkey="+textBox2.Text+ "&keyindex=9&pt_aid=549000912&u1=http%3A%2F%2Fqzs.qq.com%2Fqzone%2Fv5%2Floginsucc.html%3Fpara%3Dizone");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ptlogin2.qq.com/jump?clientuin="+textBox1.Text+ "&clientkey="+textBox2.Text+ "&keyindex=9&u1=https://mail.qq.com/cgi-bin/login?vt=passport&vm=wpt&ft=ptlogin");
        }
    }
}
