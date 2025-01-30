using PLDFinanc.Home.Models;
using PLDFinanc.Home.Views;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.Home.Controllers
{
    public class HomeController
    {
        IHomeView view;
        HomeModel model;
        public HomeController(IHomeView view, HomeModel model)
        {
            this.view = view;
            this.model = model;
            view.SetController(this);
            CarregaComponent();
        }

        private void CarregaComponent()
        {
            int anos = 2;
            int meses = 12;
            for (int i = 1; i <= anos; i++)
            {
                var titulo = new MetroLabel();
                titulo.Text = i.ToString();

                FlowLayoutPanel group = new FlowLayoutPanel();
                group.AutoSize = true;

                view.Panael.Controls.Add(titulo);

                for (int j = 1; j <= meses; j++)
                {

                    MetroButton btn = new MetroButton();
                    btn.Text = $"Mês {j.ToString()} - Ano: {i.ToString()}";
                    btn.Size = new Size(width: 100, height: 100);

                    btn.Click += (sender, e) =>
                    {
                       System.Windows.Forms.TabPage page = new System.Windows.Forms.TabPage();
                        page.Text = $"{btn.Text} {i.ToString()}" ;

                        view.Page.TabPages.Add(page);
                    };

                    if (anos > 1)
                    {
                        group.Controls.Add(btn);
                        view.Panael.Controls.Add(group);
                    }
                    else
                    {
                        view.Panael.Controls.Add(btn);
                    }
                }
            }
        }
    }
}
