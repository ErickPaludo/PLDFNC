﻿using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLDFinanc.Componentes.MicroComponentes
{
    public partial class CheckControl : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Label { get { return metroLabelTipo.Text; } set { metroLabelTipo.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroCheckBox Check { get { return metroCheckBox1; } set { metroCheckBox1 = value; } }

        public CheckControl()
        {
            InitializeComponent();
        }
    }
}
