using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLDFinanc.Componentes.MicroComponentes
{
    public partial class InputControl : UserControl
    {

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroLabel Label { get { return metroLabelTipo; } set { metroLabelTipo = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Windows.Forms.TextBox Input { get { return metroTextBox1; } set { metroTextBox1 = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNumber { get; set; }

        public InputControl()
        {
            InitializeComponent();
        }

        private void VerifyIsNumber(object sender, KeyPressEventArgs e)
        {
            if (IsNumber)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == ',' && metroTextBox1.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
