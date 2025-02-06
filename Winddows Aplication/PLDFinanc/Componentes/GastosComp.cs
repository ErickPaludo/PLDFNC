using PLDFinanc.Componentes.MicroComponentes;
using ReaLTaiizor.Child.Metro;
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

namespace PLDFinanc.Componentes
{
    public partial class GastosComp : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ForeverTabPage Panel { get { return metroTabControl; } set { metroTabControl = value; } }

        public GastosComp()
        {
            InitializeComponent();
        }
    }
}
