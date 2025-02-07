using PLDFinanc.Componentes;
using PLDFinanc.Home.Models;
using PLDFinanc.Home.Views;
using PLDFinanc.ModelObjects;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                        page.Text = $"{btn.Text}";

                        if (view.Page.TabPages.Cast<System.Windows.Forms.TabPage>()
                       .FirstOrDefault(tp => tp.Text == page.Text) == null)
                        {
                            view.Page.TabPages.Add(page);

                            MetroButton btnsair = new MetroButton();
                            btnsair.Text = "Fechar";
                            btnsair.Size = new Size(80, 30);
                            btnsair.Location = new Point(page.Width - 90, 10); 
                            btnsair.Anchor = AnchorStyles.Top | AnchorStyles.Right; 
                            btnsair.Click += (s, ev) =>
                            {                              
                                view.Page.TabPages.Remove(page);                             
                                view.Page.SelectedTab = view.Page.TabPages[0];
                            };
                            page.Controls.Add(btnsair);

                            MetroButton btnhome = new MetroButton();
                            btnhome.Text = "Início";
                            btnhome.Size = new Size(80, 30);
                            btnhome.Location = new Point(page.Width - 180, 10); 
                            btnhome.Anchor = AnchorStyles.Top | AnchorStyles.Right; 
                            btnhome.Click += (s, ev) =>
                            {
                                view.Page.SelectedTab = view.Page.TabPages[0];
                            };
                            page.Controls.Add(btnhome);

                            GastosComp gastospage = new GastosComp();
                            gastospage.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                            gastospage.Location = new Point(0, 0);
                          
                           var a = new List<string> { "Todos", "Débito", "Crédito" }; //Aqui o client deverá obter as categorias
                           

                            foreach (var categorias in a)
                            {
                                var ft = new FiltrosComp();

                               ft.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;

                                System.Windows.Forms.TabPage categoriaPage = new System.Windows.Forms.TabPage();
                                categoriaPage.Text = categorias.ToString();
                                ft = new FiltrosComp();
                                ft.Tipo.Combo.SelectedItem = categorias;
                                ft.Tipo.Combo.Enabled = categorias.Equals("Todos") ? true : false;

                                ft.ButtonCad.Click += async (s, ev) => 
                                {
                                    await model.ExecutaRec<Debito>("POST", "/cadastradebito", new Debito
                                    {
                                        Descricao = "Enviado da Aplicação windows",
                                        Valor = 25.5m,
                                        UserId = 6,
                                    });
                                    var debito = await model.ExecutaRec<List<Debito>>("GET", "/retornadebitos");

                                    
                                    ft.Datagrid.DataSource = debito;
                                    ft.Datagrid.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;
                                    ft.Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                };
                                categoriaPage.Controls.Add(ft);

                                gastospage.Panel.TabPages.Add(categoriaPage);
                            }
                         
                            page.Controls.Add(gastospage);

                        }
                        view.Page.SelectedTab = view.Page.TabPages[view.Page.TabPages.Count - 1];

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
