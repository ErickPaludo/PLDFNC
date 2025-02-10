namespace PLDFinanc.Componentes.MicroComponentes
{
    partial class InputControl
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
            metroLabelTipo.Location = new Point(2, 7);
            metroLabelTipo.Name = "metroLabelTipo";
            metroLabelTipo.Size = new Size(73, 25);
            metroLabelTipo.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroLabelTipo.StyleManager = null;
            metroLabelTipo.TabIndex = 8;
            metroLabelTipo.Text = "Tipo:";
            metroLabelTipo.ThemeAuthor = "Taiizor";
            metroLabelTipo.ThemeName = "MetroLight";
            // 
            // metroTextBox1
            // 
            metroTextBox1.Location = new Point(81, 0);
            metroTextBox1.Margin = new Padding(3, 4, 3, 4);
            metroTextBox1.Name = "metroTextBox1";
            metroTextBox1.Size = new Size(195, 27);
            metroTextBox1.TabIndex = 9;
            metroTextBox1.KeyPress += VerifyIsNumber;
            // 
            // ImputControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(metroTextBox1);
            Controls.Add(metroLabelTipo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ImputControl";
            Size = new Size(280, 52);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.MetroLabel metroLabelTipo;
        private TextBox metroTextBox1;
    }
}
