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
            metroTextBox1 = new ReaLTaiizor.Controls.MetroTextBox();
            SuspendLayout();
            // 
            // metroLabelTipo
            // 
            metroLabelTipo.Font = new Font("Microsoft Sans Serif", 10F);
            metroLabelTipo.IsDerivedStyle = true;
            metroLabelTipo.Location = new Point(2, 9);
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
            metroTextBox1.AutoCompleteCustomSource = null;
            metroTextBox1.AutoCompleteMode = AutoCompleteMode.None;
            metroTextBox1.AutoCompleteSource = AutoCompleteSource.None;
            metroTextBox1.BorderColor = Color.FromArgb(155, 155, 155);
            metroTextBox1.DisabledBackColor = Color.FromArgb(204, 204, 204);
            metroTextBox1.DisabledBorderColor = Color.FromArgb(155, 155, 155);
            metroTextBox1.DisabledForeColor = Color.FromArgb(136, 136, 136);
            metroTextBox1.Font = new Font("Microsoft Sans Serif", 10F);
            metroTextBox1.HoverColor = Color.FromArgb(102, 102, 102);
            metroTextBox1.Image = null;
            metroTextBox1.IsDerivedStyle = true;
            metroTextBox1.Lines = null;
            metroTextBox1.Location = new Point(84, 3);
            metroTextBox1.MaxLength = 32767;
            metroTextBox1.Multiline = false;
            metroTextBox1.Name = "metroTextBox1";
            metroTextBox1.ReadOnly = false;
            metroTextBox1.Size = new Size(146, 30);
            metroTextBox1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroTextBox1.StyleManager = null;
            metroTextBox1.TabIndex = 9;
            metroTextBox1.Text = "metroTextBox1";
            metroTextBox1.TextAlign = HorizontalAlignment.Left;
            metroTextBox1.ThemeAuthor = "Taiizor";
            metroTextBox1.ThemeName = "MetroLight";
            metroTextBox1.UseSystemPasswordChar = false;
            metroTextBox1.WatermarkText = "";
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
        }

        #endregion

        private ReaLTaiizor.Controls.MetroLabel metroLabelTipo;
        private ReaLTaiizor.Controls.MetroTextBox metroTextBox1;
    }
}
