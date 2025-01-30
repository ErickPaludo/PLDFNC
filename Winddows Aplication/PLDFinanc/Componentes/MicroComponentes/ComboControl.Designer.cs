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
            metroComboBox1 = new ReaLTaiizor.Controls.MetroComboBox();
            SuspendLayout();
            // 
            // metroLabelTipo
            // 
            metroLabelTipo.Font = new Font("Microsoft Sans Serif", 10F);
            metroLabelTipo.IsDerivedStyle = true;
            metroLabelTipo.Location = new Point(3, 7);
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
            metroComboBox1.AllowDrop = true;
            metroComboBox1.ArrowColor = Color.FromArgb(150, 150, 150);
            metroComboBox1.BackColor = Color.Transparent;
            metroComboBox1.BackgroundColor = Color.FromArgb(238, 238, 238);
            metroComboBox1.BorderColor = Color.FromArgb(150, 150, 150);
            metroComboBox1.CausesValidation = false;
            metroComboBox1.DisabledBackColor = Color.FromArgb(204, 204, 204);
            metroComboBox1.DisabledBorderColor = Color.FromArgb(155, 155, 155);
            metroComboBox1.DisabledForeColor = Color.FromArgb(136, 136, 136);
            metroComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            metroComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            metroComboBox1.Font = new Font("Microsoft Sans Serif", 11F);
            metroComboBox1.FormattingEnabled = true;
            metroComboBox1.IsDerivedStyle = true;
            metroComboBox1.ItemHeight = 20;
            metroComboBox1.Location = new Point(86, 3);
            metroComboBox1.Name = "metroComboBox1";
            metroComboBox1.SelectedItemBackColor = Color.FromArgb(65, 177, 225);
            metroComboBox1.SelectedItemForeColor = Color.White;
            metroComboBox1.Size = new Size(169, 26);
            metroComboBox1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroComboBox1.StyleManager = null;
            metroComboBox1.TabIndex = 5;
            metroComboBox1.ThemeAuthor = "Taiizor";
            metroComboBox1.ThemeName = "MetroLight";
            // 
            // ComboControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(metroLabelTipo);
            Controls.Add(metroComboBox1);
            Name = "ComboControl";
            Size = new Size(266, 36);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MetroLabel metroLabelTipo;
        private ReaLTaiizor.Controls.MetroComboBox metroComboBox1;
    }
}
