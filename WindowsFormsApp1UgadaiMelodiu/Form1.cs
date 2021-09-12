﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1UgadaiMelodiu
{
    public partial class fMain : Form
    {
        fParam fp = new fParam();
        FGame fg = new FGame();
 
        public fMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnParams_Click(object sender, EventArgs e)
        {
            fp.ShowDialog();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            fg.ShowDialog();
        }
    }
}
