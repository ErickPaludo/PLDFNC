namespace PLDFinanc.Componentes.MicroComponentes
{
    partial class CheckControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            metroLabelTipo = new ReaLTaiizor.Controls.MetroLabel();
            metroCheckBox1 = new ReaLTaiizor.Controls.MetroCheckBox();
            SuspendLayout();
            // 
            // metroLabelTipo
            // 
            metroLabelTipo.Font = new Font("Microsoft Sans Serif", 10F);
            metroLabelTipo.IsDerivedStyle = true;
            metroLabelTipo.Location = new Point(4, 2);
            metroLabelTipo.Name = "metroLabelTipo";
            metroLabelTipo.Size = new Size(57, 19);
            metroLabelTipo.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroLabelTipo.StyleManager = null;
            metroLabelTipo.TabIndex = 8;
            metroLabelTipo.Text = "Tipo:";
            metroLabelTipo.ThemeAuthor = "Taiizor";
            metroLabelTipo.ThemeName = "MetroLight";
            // 
            // metroCheckBox1
            // 
            metroCheckBox1.BackColor = Color.Transparent;
            metroCheckBox1.BackgroundColor = Color.White;
            metroCheckBox1.BorderColor = Color.FromArgb(155, 155, 155);
            metroCheckBox1.Checked = false;
            metroCheckBox1.CheckSignColor = Color.FromArgb(65, 177, 225);
            metroCheckBox1.CheckState = ReaLTaiizor.Enum.Metro.CheckState.Unchecked;
            metroCheckBox1.DisabledBorderColor = Color.FromArgb(205, 205, 205);
            metroCheckBox1.Font = new Font("Microsoft Sans Serif", 10F);
            metroCheckBox1.IsDerivedStyle = true;
            metroCheckBox1.Location = new Point(67, 3);
            metroCheckBox1.Name = "metroCheckBox1";
            metroCheckBox1.SignStyle = ReaLTaiizor.Enum.Metro.SignStyle.Sign;
            metroCheckBox1.Size = new Size(195, 16);
            metroCheckBox1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroCheckBox1.StyleManager = null;
            metroCheckBox1.TabIndex = 9;
            metroCheckBox1.Text = "metroCheckBox1";
            metroCheckBox1.ThemeAuthor = "Taiizor";
            metroCheckBox1.ThemeName = "MetroLight";
            // 
            // CheckControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(metroCheckBox1);
            Controls.Add(metroLabelTipo);
            Name = "CheckControl";
            Size = new Size(262, 25);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MetroLabel metroLabelTipo;
        private ReaLTaiizor.Controls.MetroCheckBox metroCheckBox1;
    }
}
