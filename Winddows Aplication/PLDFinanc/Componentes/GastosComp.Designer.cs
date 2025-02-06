namespace PLDFinanc.Componentes
{
    partial class GastosComp
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
            metroTabControl = new ReaLTaiizor.Controls.ForeverTabPage();
            SuspendLayout();
            // 
            // metroTabControl
            // 
            metroTabControl.ActiveColor = Color.FromArgb(65, 177, 225);
            metroTabControl.ActiveFontColor = Color.White;
            metroTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            metroTabControl.BaseColor = Color.White;
            metroTabControl.BGColor = Color.White;
            metroTabControl.DeactiveFontColor = Color.DimGray;
            metroTabControl.Font = new Font("Segoe UI", 10F);
            metroTabControl.ItemSize = new Size(120, 40);
            metroTabControl.Location = new Point(0, 3);
            metroTabControl.Name = "metroTabControl";
            metroTabControl.SelectedIndex = 0;
            metroTabControl.Size = new Size(977, 565);
            metroTabControl.SizeMode = TabSizeMode.Fixed;
            metroTabControl.TabIndex = 4;
            // 
            // GastosComp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(metroTabControl);
            Name = "GastosComp";
            Size = new Size(980, 571);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.ForeverTabPage metroTabControl;
    }
}
