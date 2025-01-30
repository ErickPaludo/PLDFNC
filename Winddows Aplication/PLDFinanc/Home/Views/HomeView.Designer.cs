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
            flowLayoutPanel1 = new FlowLayoutPanel();
            metroTabControl = new ReaLTaiizor.Controls.MetroTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            metroTabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(777, 385);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // metroTabControl
            // 
            metroTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            metroTabControl.AnimateEasingType = ReaLTaiizor.Enum.Metro.EasingType.CubeOut;
            metroTabControl.AnimateTime = 200;
            metroTabControl.BackgroundColor = Color.White;
            metroTabControl.Controls.Add(tabPage1);
            metroTabControl.Controls.Add(tabPage2);
            metroTabControl.ControlsVisible = true;
            metroTabControl.IsDerivedStyle = true;
            metroTabControl.ItemSize = new Size(100, 38);
            metroTabControl.Location = new Point(5, 1);
            metroTabControl.MCursor = Cursors.Hand;
            metroTabControl.Name = "metroTabControl";
            metroTabControl.SelectedIndex = 0;
            metroTabControl.SelectedTextColor = Color.White;
            metroTabControl.Size = new Size(791, 437);
            metroTabControl.SizeMode = TabSizeMode.Fixed;
            metroTabControl.Speed = 100;
            metroTabControl.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroTabControl.StyleManager = null;
            metroTabControl.TabIndex = 0;
            metroTabControl.ThemeAuthor = "Taiizor";
            metroTabControl.ThemeName = "MetroLight";
            metroTabControl.UnselectedTextColor = Color.Gray;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(flowLayoutPanel1);
            tabPage1.Location = new Point(4, 42);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(783, 391);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 42);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(783, 391);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // HomeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(metroTabControl);
            Name = "HomeView";
            Text = "HomeView";
            metroTabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.MetroTabControl metroTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}