using ReaLTaiizor.Controls;
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
    public partial class DataControl : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Label { get { return metroLabel1.Text; } set { metroLabel1.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PoisonDateTime Date { get { return poisonDateTime1; } set { poisonDateTime1 = value; } }
        public DataControl()
        {
            InitializeComponent();
        }
    }
}
