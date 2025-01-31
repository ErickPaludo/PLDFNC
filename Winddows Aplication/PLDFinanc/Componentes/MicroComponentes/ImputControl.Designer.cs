namespace PLDFinanc.Componentes.MicroComponentes
{
    partial class ImputControl
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
            metroTextBox1 = new TextBox();
            SuspendLayout();
            // 
            // metroLabelTipo
            // 
            metroLabelTipo.Font = new Font("Microsoft Sans Serif", 10F);
            metroLabelTipo.IsDerivedStyle = true;
            metroLabelTipo.Location = new Point(2, 5);
            metroLabelTipo.Name = "metroLabelTipo";
            metroLabelTipo.Size = new Size(43, 19);
            metroLabelTipo.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroLabelTipo.StyleManager = null;
            metroLabelTipo.TabIndex = 8;
            metroLabelTipo.Text = "Tipo:";
            metroLabelTipo.ThemeAuthor = "Taiizor";
            metroLabelTipo.ThemeName = "MetroLight";
            // 
            // metroTextBox1
            // 
            metroTextBox1.Location = new Point(71, 0);
            metroTextBox1.Name = "metroTextBox1";
            metroTextBox1.Size = new Size(171, 23);
            metroTextBox1.TabIndex = 9;
            metroTextBox1.KeyPress += VerifyIsNumber;
            // 
            // ImputControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(metroTextBox1);
            Controls.Add(metroLabelTipo);
            Name = "ImputControl";
            Size = new Size(245, 39);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.MetroLabel metroLabelTipo;
        private TextBox metroTextBox1;
    }
}
