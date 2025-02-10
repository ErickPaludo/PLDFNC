namespace PLDFinanc.CadastroGastos.Views
{
    partial class CadastroView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboControlCombo = new Componentes.MicroComponentes.ComboControl();
            dataControlData = new Componentes.MicroComponentes.DataControl();
            imputControlTitulo = new Componentes.MicroComponentes.InputControl();
            imputControlValor = new Componentes.MicroComponentes.InputControl();
            imputControlDescricao = new Componentes.MicroComponentes.InputControl();
            metroButtoncadastrar = new ReaLTaiizor.Controls.MetroButton();
            imputControlParcelas = new Componentes.MicroComponentes.InputControl();
            SuspendLayout();
            // 
            // comboControlCombo
            // 
            comboControlCombo.Location = new Point(298, 13);
            comboControlCombo.Margin = new Padding(3, 4, 3, 4);
            comboControlCombo.Name = "comboControlCombo";
            comboControlCombo.Size = new Size(280, 32);
            comboControlCombo.TabIndex = 0;
            // 
            // dataControlData
            // 
            dataControlData.Location = new Point(298, 85);
            dataControlData.Margin = new Padding(3, 4, 3, 4);
            dataControlData.Name = "dataControlData";
            dataControlData.Size = new Size(149, 79);
            dataControlData.TabIndex = 2;
            // 
            // imputControlTitulo
            // 
            imputControlTitulo.Location = new Point(12, 13);
            imputControlTitulo.Margin = new Padding(3, 4, 3, 4);
            imputControlTitulo.Name = "imputControlTitulo";
            imputControlTitulo.Size = new Size(280, 29);
            imputControlTitulo.TabIndex = 3;
            // 
            // imputControlValor
            // 
            imputControlValor.Location = new Point(12, 50);
            imputControlValor.Margin = new Padding(3, 4, 3, 4);
            imputControlValor.Name = "imputControlValor";
            imputControlValor.Size = new Size(280, 32);
            imputControlValor.TabIndex = 4;
            // 
            // imputControlDescricao
            // 
            imputControlDescricao.Location = new Point(12, 90);
            imputControlDescricao.Margin = new Padding(3, 4, 3, 4);
            imputControlDescricao.Name = "imputControlDescricao";
            imputControlDescricao.Size = new Size(280, 35);
            imputControlDescricao.TabIndex = 5;
            // 
            // metroButtoncadastrar
            // 
            metroButtoncadastrar.DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
            metroButtoncadastrar.DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
            metroButtoncadastrar.DisabledForeColor = Color.Gray;
            metroButtoncadastrar.Font = new Font("Microsoft Sans Serif", 10F);
            metroButtoncadastrar.HoverBorderColor = Color.FromArgb(95, 207, 255);
            metroButtoncadastrar.HoverColor = Color.FromArgb(95, 207, 255);
            metroButtoncadastrar.HoverTextColor = Color.White;
            metroButtoncadastrar.IsDerivedStyle = true;
            metroButtoncadastrar.Location = new Point(92, 121);
            metroButtoncadastrar.Margin = new Padding(3, 4, 3, 4);
            metroButtoncadastrar.Name = "metroButtoncadastrar";
            metroButtoncadastrar.NormalBorderColor = Color.FromArgb(65, 177, 225);
            metroButtoncadastrar.NormalColor = Color.FromArgb(65, 177, 225);
            metroButtoncadastrar.NormalTextColor = Color.White;
            metroButtoncadastrar.PressBorderColor = Color.FromArgb(35, 147, 195);
            metroButtoncadastrar.PressColor = Color.FromArgb(35, 147, 195);
            metroButtoncadastrar.PressTextColor = Color.White;
            metroButtoncadastrar.Size = new Size(195, 27);
            metroButtoncadastrar.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroButtoncadastrar.StyleManager = null;
            metroButtoncadastrar.TabIndex = 17;
            metroButtoncadastrar.Text = "Cadastrar";
            metroButtoncadastrar.ThemeAuthor = "Taiizor";
            metroButtoncadastrar.ThemeName = "MetroLight";
            // 
            // imputControlParcelas
            // 
            imputControlParcelas.Location = new Point(298, 50);
            imputControlParcelas.Margin = new Padding(3, 4, 3, 4);
            imputControlParcelas.Name = "imputControlParcelas";
            imputControlParcelas.Size = new Size(280, 35);
            imputControlParcelas.TabIndex = 18;
            // 
            // CadastroView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(674, 166);
            Controls.Add(comboControlCombo);
            Controls.Add(dataControlData);
            Controls.Add(imputControlParcelas);
            Controls.Add(metroButtoncadastrar);
            Controls.Add(imputControlDescricao);
            Controls.Add(imputControlValor);
            Controls.Add(imputControlTitulo);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CadastroView";
            Text = "Cadastrar Gasto";
            ResumeLayout(false);
        }

        #endregion

        private Componentes.MicroComponentes.ComboControl comboControlCombo;
        private Componentes.MicroComponentes.DataControl  dataControl1;
        private Componentes.MicroComponentes.DataControl  dataControlData;
        private Componentes.MicroComponentes.InputControl imputControlTitulo;
        private Componentes.MicroComponentes.InputControl imputControlValor;
        private Componentes.MicroComponentes.InputControl imputControlDescricao;
        private ReaLTaiizor.Controls.MetroButton          metroButtoncadastrar;
        private Componentes.MicroComponentes.InputControl imputControlParcelas;
    }
}