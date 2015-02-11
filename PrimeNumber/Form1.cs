using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
namespace PrimeNumber
{
    public partial class Form1 : Form
    {
        //private thread variable
        private Thread primeNumberThread;

        public Form1()
        {
            InitializeComponent();
            //让他允许不安全调用
            Control.CheckForIllegalCrossThreadCalls = false;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //let's create a new thread
            primeNumberThread = new Thread(new ThreadStart(GeneratePrimeNumbers));

            //give a name
            primeNumberThread.Name = "show";
            primeNumberThread.Priority = ThreadPriority.BelowNormal;

            btnPause.Enabled = true;
            btnStart.Enabled = false;

            primeNumberThread.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (primeNumberThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    //停止
                    primeNumberThread.Suspend();
                    btnPause.Enabled = false;
                    btnStart.Enabled = true;
                    btnResume.Enabled = true;
                }
            }
            catch (ThreadStateException ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            try
            {
                if (primeNumberThread.ThreadState == System.Threading.ThreadState.Suspended || primeNumberThread.ThreadState== System.Threading.ThreadState.SuspendRequested)
                {
                    //停止
                    primeNumberThread.Resume();
                    btnResume.Enabled = false;
                    btnPause.Enabled = true;
                    
                }
            }
            catch (ThreadStateException ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }
        public void GeneratePrimeNumbers()
        {
            for (int i = 0; i < 20; i++)
            {
                listPrime.Items.Add(i);
                System.Threading.Thread.Sleep(100);
            }
            btnStart.Enabled = true;
            btnPause.Enabled = false;
        }
    }
}
