using PLDFinanc.CadastroGastos.Controllers;
using PLDFinanc.Componentes.MicroComponentes;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLDFinanc.CadastroGastos.Views
{
    public partial class CadastroView : CrownForm , ICadastroView
    {
        public CadastroView()
        {
            InitializeComponent();
        }

        CadastroController _controller;
        public void SetController(CadastroController controller)
        {
            _controller = controller;
        }

        InputControl ICadastroView.Titulo { get => imputControlTitulo; set => imputControlTitulo = value; }
        InputControl ICadastroView.Valor { get => imputControlValor; set => imputControlValor = value; }
        InputControl ICadastroView.Descricao { get => imputControlDescricao; set => imputControlDescricao = value; }
        ComboControl ICadastroView.Tipo { get => comboControlCombo; set => comboControlCombo = value; }
        InputControl ICadastroView.Parcelas { get => imputControlParcelas; set => imputControlParcelas = value; }
        DataControl ICadastroView.Vencimento { get => dataControlData; set => dataControlData = value; }
        MetroButton ICadastroView.Cadastrar { get => metroButtoncadastrar; set => metroButtoncadastrar = value; }

    }
}
