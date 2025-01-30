using PLDFinanc.Componentes.MicroComponentes;
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
        public FiltrosComp Todos { get { return filtrosComp1; } set { filtrosComp1 = value; } }  
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FiltrosComp Debito { get { return filtrosComp2; } set { filtrosComp2 = value; } }  
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FiltrosComp Credito { get { return filtrosComp3; } set { filtrosComp2 = value; } }
        public GastosComp()
        {
            InitializeComponent();
        }
    }
}
