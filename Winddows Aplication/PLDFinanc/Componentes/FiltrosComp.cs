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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImputControl Id { get { return inputId; } set { inputId = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImputControl Titulo { get { return inputTitulo; } set { inputTitulo = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImputControl Desc { get { return inputDesc; } set { inputDesc = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CheckControl Status { get { return checkControl1; } set { checkControl1 = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImputControl Valor { get { return inputValor; } set { inputValor = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataControl Dataini { get { return dataIni; } set { dataIni = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataControl Datafim { get { return dataFim; } set { dataFim = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboControl Tipo { get { return comboTipo; } set { comboTipo = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public PoisonDataGridView Datagrid { get { return poisonDataGridView1; } set { poisonDataGridView1 = value; } } 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroButton ButtonCad { get { return metroButtoncadastrar; } set { metroButtoncadastrar = value; } }
        public FiltrosComp()
        {
            InitializeComponent();

            Id.Label = "ID";
            Id.Input.Text = "";

            Titulo.Label = "Titulo";
            Titulo.Input.Text = "";

            Desc.Label = "Descrição";
            Desc.Input.Text = "";

            Status.Label = "Pago";
            Status.Check.Text = "";

            dataIni.Label = "Data ini";
            Datafim.Label = "Data fim";

            Valor.Label = "Valor";
            Valor.Input.Text = "";
            Valor.IsNumber = true;

            Tipo.Combo.BackColor = Color.White;
            Tipo.Combo.Items.Add("Todos");
            Tipo.Combo.Items.Add("Débito");
            Tipo.Combo.Items.Add("Crédito");
        }
    }
}
