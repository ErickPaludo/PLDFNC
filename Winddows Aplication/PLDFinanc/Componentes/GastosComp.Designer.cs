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
            tabPage3 = new TabPage();
            filtrosComp1 = new FiltrosComp();
            tabPage1 = new TabPage();
            filtrosComp2 = new FiltrosComp();
            tabPage2 = new TabPage();
            filtrosComp3 = new FiltrosComp();
            metroTabControl.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // metroTabControl
            // 
            metroTabControl.ActiveColor = Color.FromArgb(65, 177, 225);
            metroTabControl.ActiveFontColor = Color.White;
            metroTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            metroTabControl.BaseColor = Color.White;
            metroTabControl.BGColor = Color.White;
            metroTabControl.Controls.Add(tabPage3);
            metroTabControl.Controls.Add(tabPage1);
            metroTabControl.Controls.Add(tabPage2);
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
            // tabPage3
            // 
            tabPage3.BackColor = Color.White;
            tabPage3.Controls.Add(filtrosComp1);
            tabPage3.Location = new Point(4, 44);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(969, 517);
            tabPage3.TabIndex = 1;
            tabPage3.Text = "Geral";
            // 
            // filtrosComp1
            // 
            filtrosComp1.Location = new Point(3, 3);
            filtrosComp1.Name = "filtrosComp1";
            filtrosComp1.Size = new Size(579, 191);
            filtrosComp1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(filtrosComp2);
            tabPage1.Location = new Point(4, 44);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(969, 517);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Débito";
            // 
            // filtrosComp2
            // 
            filtrosComp2.Location = new Point(3, 3);
            filtrosComp2.Name = "filtrosComp2";
            filtrosComp2.Size = new Size(579, 191);
            filtrosComp2.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(filtrosComp3);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(969, 517);
            tabPage2.TabIndex = 3;
            tabPage2.Text = "Crédito";
            // 
            // filtrosComp3
            // 
            filtrosComp3.Location = new Point(3, 3);
            filtrosComp3.Name = "filtrosComp3";
            filtrosComp3.Size = new Size(579, 191);
            filtrosComp3.TabIndex = 0;
            // 
            // GastosComp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(metroTabControl);
            Name = "GastosComp";
            Size = new Size(980, 571);
            metroTabControl.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.ForeverTabPage metroTabControl;
        private TabPage tabPage3;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private FiltrosComp filtrosComp1;
        private FiltrosComp filtrosComp2;
        private FiltrosComp filtrosComp3;
    }
}
