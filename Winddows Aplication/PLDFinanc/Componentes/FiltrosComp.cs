using PLDFinanc.Componentes.MicroComponentes;
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
    public partial class FiltrosComp : UserControl
    {
        #region Filtro
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Windows.Forms.GroupBox Filtro { get { return groupBoxFiltro; } set { groupBoxFiltro = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputControl Id { get { return inputId; } set { inputId = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputControl Titulo { get { return inputTitulo; } set { inputTitulo = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputControl Desc { get { return inputDesc; } set { inputDesc = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CheckControl Status { get { return checkControl1; } set { checkControl1 = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputControl Valor { get { return inputValor; } set { inputValor = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataControl Dataini { get { return dataIni; } set { dataIni = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataControl Datafim { get { return dataFim; } set { dataFim = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboControl Tipo { get { return comboTipo; } set { comboTipo = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public PoisonDataGridView Datagrid { get { return poisonDataGridView1; } set { poisonDataGridView1 = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroButton ButtonPesquisa { get { return metroButtonpesquisar; } set { metroButtonpesquisar = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroButton ButtonCadastrar { get { return metroButtonCadastrar; } set { metroButtonCadastrar = value; } }
        #endregion
        #region Cadastro
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Windows.Forms.GroupBox Cadastrar { get { return groupBoxCad; } set { groupBoxCad = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputControl CadTitulo { get { return imputControlTitulo; } set { imputControlTitulo = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputControl CadValor { get { return imputControlValor; } set { imputControlValor = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputControl CadDesc { get { return imputControlDescricao; } set { imputControlDescricao = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboControl CadCombo { get { return comboControlCombo; } set { comboControlCombo = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputControl CadParcelas { get { return imputControlParcelas; } set { imputControlParcelas = value; } } 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataControl CadData { get { return dataControlData; } set { dataControlData = value; } } 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroButton CadButonCad { get { return metroButtonCad; } set { metroButtonCad = value; } }   
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroButton CadButtonCancel { get { return metroButtonCancelar; } set { metroButtonCancelar = value; } }
        #endregion
        public FiltrosComp()
        {
            InitializeComponent();

            Id.Label.Text = "ID";
            Id.Input.Text = "";
            Id.IsNumber = true;

            Titulo.Label.Text = "Titulo";
            Titulo.Input.Text = "";
            Titulo.Input.MaxLength = 50;

            Desc.Label.Text = "Descrição";
            Desc.Input.Text = "";
            Desc.Input.MaxLength = 255;

            Status.Label = "Pago";
            Status.Check.Text = "";

            dataIni.Label = "Data ini";
            Datafim.Label = "Data fim";

            Valor.Label.Text = "Valor";
            Valor.Input.Text = "";
            Valor.Input.PlaceholderText = "R$ 00,00";
            Valor.IsNumber = true;      

            Dataini.Date.Text = DateTime.Now.AddDays(-30).ToString();

            CadTitulo.Label.Text = "Título:";
            CadTitulo.Input.MaxLength = 50;
            CadValor.Label.Text = "Valor:";
            CadValor.Input.PlaceholderText = "R$ 00,00";
            CadValor.IsNumber = true;
            CadDesc.Label.Text = "Descrição:";
            CadDesc.Input.MaxLength = 255;
            CadCombo.Label = "Tipo:";
            CadParcelas.Label.Text = "Parcelas:";
            CadData.Label = "Data Gasto";
        }
    }
}
