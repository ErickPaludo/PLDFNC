using PLDFinanc.Home.Controllers;
using PLDFinanc.Home.Models;
using PLDFinanc.Home.Views;
using PLDFinanc.Login.Models;
using PLDFinanc.Login.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLDFinanc.Login.Controllers
{
    public class LoginController
    {
        IloginView view;
        LoginModel model;
        public LoginController(IloginView view, LoginModel model)
        {
            this.view = view;
            this.model = model;
            view.SetController(this);
            view.LogarApp += OnLogarApp;
        }
        private void OnLogarApp(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(view.User.Text) || string.IsNullOrWhiteSpace(view.Pass.Text))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            
                HomeView homeview = new HomeView();
                HomeModel homemodel = new HomeModel();
                HomeController controller = new HomeController(homeview, homemodel);
                homeview.ShowDialog();
           
        }
    }
}
