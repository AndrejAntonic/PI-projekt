﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purchase_Assistant
{
    public partial class FrmPrikaz : Form
    {
        public FrmPrikaz()
        {
            InitializeComponent();
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            new FrmStvaranje().ShowDialog();
        }
    }
}
