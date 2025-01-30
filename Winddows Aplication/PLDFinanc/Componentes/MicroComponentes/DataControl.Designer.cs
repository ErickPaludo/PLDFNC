namespace PLDFinanc.Componentes.MicroComponentes
{
    partial class DataControl
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
            metroLabel1 = new ReaLTaiizor.Controls.MetroLabel();
            poisonDateTime1 = new ReaLTaiizor.Controls.PoisonDateTime();
            SuspendLayout();
            // 
            // metroLabel1
            // 
            metroLabel1.Font = new Font("Microsoft Sans Serif", 10F);
            metroLabel1.IsDerivedStyle = true;
            metroLabel1.Location = new Point(3, 0);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(100, 23);
            metroLabel1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroLabel1.StyleManager = null;
            metroLabel1.TabIndex = 0;
            metroLabel1.Text = "metroLabel1";
            metroLabel1.ThemeAuthor = "Taiizor";
            metroLabel1.ThemeName = "MetroLight";
            // 
            // poisonDateTime1
            // 
            poisonDateTime1.Format = DateTimePickerFormat.Short;
            poisonDateTime1.Location = new Point(3, 26);
            poisonDateTime1.MinimumSize = new Size(0, 29);
            poisonDateTime1.Name = "poisonDateTime1";
            poisonDateTime1.Size = new Size(119, 29);
            poisonDateTime1.TabIndex = 1;
            // 
            // DataControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(poisonDateTime1);
            Controls.Add(metroLabel1);
            Name = "DataControl";
            Size = new Size(130, 59);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MetroLabel metroLabel1;
        private ReaLTaiizor.Controls.PoisonDateTime poisonDateTime1;
    }
}
