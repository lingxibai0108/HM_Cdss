using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HM_Cdss;
namespace Dome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private frmMayson frm = null;
        private void Form1_Load(object sender, EventArgs e)
        {
             frm = new frmMayson();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            frm.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm.Send();
        }
    }
}
