using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdate
{
    public partial class FrmAlertUpdate : Form
    {
        public FrmAlertUpdate()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmAlertUpdate_Load);
        }

        void FrmAlertUpdate_Load(object sender, EventArgs e)
        {
            button1.Focus();
        }
    }
}
