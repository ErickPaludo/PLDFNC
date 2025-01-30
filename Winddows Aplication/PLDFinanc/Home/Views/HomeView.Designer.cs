namespace PLDFinanc.Home.Views
{
    partial class HomeView
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
            metroTabControl = new ReaLTaiizor.Controls.ForeverTabPage();
            tabPage3 = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            metroTabControl.SuspendLayout();
            tabPage3.SuspendLayout();
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
            metroTabControl.DeactiveFontColor = Color.DimGray;
            metroTabControl.Font = new Font("Segoe UI", 10F);
            metroTabControl.ItemSize = new Size(120, 40);
            metroTabControl.Location = new Point(0, 3);
            metroTabControl.Name = "metroTabControl";
            metroTabControl.SelectedIndex = 0;
            metroTabControl.Size = new Size(958, 443);
            metroTabControl.SizeMode = TabSizeMode.Fixed;
            metroTabControl.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.White;
            tabPage3.Controls.Add(flowLayoutPanel1);
            tabPage3.Location = new Point(4, 44);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(950, 395);
            tabPage3.TabIndex = 1;
            tabPage3.Text = "Início";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(944, 389);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // HomeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 450);
            Controls.Add(metroTabControl);
            Name = "HomeView";
            Text = "HomeView";
            metroTabControl.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ReaLTaiizor.Controls.ForeverTabPage metroTabControl;
        private TabPage tabPage3;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}