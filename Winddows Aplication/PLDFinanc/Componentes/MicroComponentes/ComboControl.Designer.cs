namespace PLDFinanc.Componentes.MicroComponentes
{
    partial class ComboControl
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
            metroComboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // metroLabelTipo
            // 
            metroLabelTipo.Font = new Font("Microsoft Sans Serif", 10F);
            metroLabelTipo.IsDerivedStyle = true;
            metroLabelTipo.Location = new Point(1, 2);
            metroLabelTipo.Name = "metroLabelTipo";
            metroLabelTipo.Size = new Size(43, 19);
            metroLabelTipo.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroLabelTipo.StyleManager = null;
            metroLabelTipo.TabIndex = 6;
            metroLabelTipo.Text = "Tipo:";
            metroLabelTipo.ThemeAuthor = "Taiizor";
            metroLabelTipo.ThemeName = "MetroLight";
            // 
            // metroComboBox1
            // 
            metroComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            metroComboBox1.FormattingEnabled = true;
            metroComboBox1.Location = new Point(87, 0);
            metroComboBox1.Name = "metroComboBox1";
            metroComboBox1.Size = new Size(159, 23);
            metroComboBox1.TabIndex = 7;
            // 
            // ComboControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(metroComboBox1);
            Controls.Add(metroLabelTipo);
            Name = "ComboControl";
            Size = new Size(266, 36);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MetroLabel metroLabelTipo;
        private ComboBox metroComboBox1;
    }
}
