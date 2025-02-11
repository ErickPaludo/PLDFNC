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

                    btn.Click += async (sender, e) =>
                    {
                        System.Windows.Forms.TabPage page = new System.Windows.Forms.TabPage();
                        page.Text = $"{btn.Text}";

                        if (view.Page.TabPages.Cast<System.Windows.Forms.TabPage>()
                       .FirstOrDefault(tp => tp.Text == page.Text) == null)
                        {
                            view.Page.TabPages.Add(page);

                            MetroButton btnsair = new MetroButton();
                            MetroButton btnhome = new MetroButton();
                            #region Botão sair
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
                            #endregion
                            #region Botão home
                            btnhome.Text = "Início";
                            btnhome.Size = new Size(80, 30);
                            btnhome.Location = new Point(page.Width - 180, 10);
                            btnhome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                            btnhome.Click += (s, ev) =>
                            {
                                view.Page.SelectedTab = view.Page.TabPages[0];
                            };
                            page.Controls.Add(btnhome);
                            #endregion
                            page.Controls.Add(await ObtemCategorias());

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
        private async Task<GastosComp> ObtemCategorias()
        {
            var a = new List<string> { "Débito", "Crédito" }; //Aqui o client deverá obter as categorias
            GastosComp gastospage = new GastosComp();
            gastospage.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            gastospage.Location = new Point(0, 0);
            foreach (var categorias in a)
            {
                var ft = new FiltrosComp();
                foreach (var obj in a)
                {
                    ft.Tipo.Combo.Items.Add(obj);
                    ft.CadCombo.Combo.Items.Add(obj);
                }
                ft.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;

                System.Windows.Forms.TabPage categoriaPage = new System.Windows.Forms.TabPage();
                categoriaPage.Text = categorias.ToString();
                ft.Tipo.Combo.SelectedItem = categorias;
                ft.Tipo.Combo.Enabled = categorias.Equals("Todos") ? true : false;
                ft.Status.Visible = categorias.Equals("Crédito") ? true : false;
                ft.ButtonPesquisa.Click += async (s, ev) =>
                {
                    if (ft.Tipo.Combo.SelectedItem.Equals("Débito"))
                    {
                        ft.Datagrid.DataSource = await model.ExecutaRec<List<Debito>>("GET", "/retornadebitos");
                    }
                    else if (ft.Tipo.Combo.SelectedItem.Equals("Crédito"))
                    {
                        ft.Datagrid.DataSource = await model.ExecutaRec<List<Credito>>("GET", "/retornacreditos");
                    }


                    ft.Datagrid.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;
                    ft.Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                };
                ft.ButtonCadastrar.Click += async (s, ev) =>
                {
                    ft.Filtro.Visible = false;
                    ft.Cadastrar.Visible = true;
                };

                ft.CadButtonCancel.Click += async (s, ev) =>
                {
                    ft.Filtro.Visible = true;
                    ft.Cadastrar.Visible = false;
                };
                ft.CadCombo.Combo.SelectedItem = categorias;
                ft.CadCombo.Combo.Enabled = false;
                if (!categorias.Equals("Crédito"))
                {
                    ft.CadParcelas.Visible = false;
                }
                ft.CadButonCad.Click += async (s, sv) =>
                {
                    if (!string.IsNullOrWhiteSpace(ft.CadTitulo.Input.Text) && !string.IsNullOrWhiteSpace(ft.CadValor.Input.Text))
                    {
                        if (categorias.Equals("Crédito"))
                        {
                            if (!string.IsNullOrWhiteSpace(ft.CadParcelas.Input.Text) && Convert.ToInt32(ft.CadParcelas.Input.Text) > 0)
                            {
                                try
                                {
                                    var retorno = await model.ExecutaRec<dynamic>("POST", "/cadastracredito", new Credito
                                    {
                                        Titulo = ft.CadTitulo.Input.Text,
                                        Descricao = ft.CadDesc.Input.Text,
                                        Valor = Convert.ToDecimal(ft.CadValor.Input.Text),
                                        ParcelaTotal = Convert.ToInt32(ft.CadParcelas.Input.Text),
                                        DataCompra = Convert.ToDateTime(ft.CadData.Date.Text),
                                        UserId = 1,
                                    });
                                    if (retorno is not null)
                                    {
                                        ft.CadTitulo.Input.Text = string.Empty;
                                        ft.CadParcelas.Input.Text = string.Empty;
                                        ft.CadDesc.Input.Text = string.Empty;
                                        ft.CadValor.Input.Text = string.Empty;
                                        ft.CadData.Date.Text = DateTime.Now.ToString();

                                        ft.Filtro.Visible = true;
                                        ft.Cadastrar.Visible = false;

                                        ft.Datagrid.DataSource = await model.ExecutaRec<List<Credito>>("GET", "/retornacreditos");
                                    }
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Parcela deve ser maior que 0!", "Informações Inválidas");
                            }
                        }
                        else
                        {
                            //await model.ExecutaRec<Debito>("POST", "/cadastradebito", new Debito
                            //{
                            //    Descricao = "Enviado da Aplicação windows",
                            //    Valor = 25.5m,
                            //    UserId = 6,
                            //});
                        }
                    }
                    else
                    {
                        MessageBox.Show("É necessário realizar o preenchimento de todos os campos!","Informações Inválidas");
                    }                 
                };

                categoriaPage.Controls.Add(ft);

                gastospage.Panel.TabPages.Add(categoriaPage);
            }
            return gastospage;
        }
    }
}
