using PLDFinanc.Login.Controllers;
using PLDFinanc.Login.View;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System.ComponentModel;

namespace PLDFinanc
{
    public partial class LoginView : LostForm, IloginView
    {
        public LoginView()
        {
            InitializeComponent();
            BtnLogin.Click += (sender, e) => LogarApp?.Invoke(this, EventArgs.Empty);
        }
        private LoginController _controller;

        public event EventHandler LogarApp;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroTextBox User { get => metroTextBoxUser; set => metroTextBoxUser = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroTextBox Pass { get => metroTextBoxUser; set => metroTextBoxUser = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroCheckBox CheckPass { get => metroCheckBoxLogin; set => metroCheckBoxLogin = value;  }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroButton BtnLogin { get => metroButtonLogin; set => metroButtonLogin = value; }

        public void SetController(LoginController controller)
        {
            _controller = controller;
        }
    }
}
