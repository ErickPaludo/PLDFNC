using Newtonsoft.Json;
using PLDFinanc.ModelObjects;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace PrototipoFNCForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //   LoadTaable();
        }

        public async Task<T> ExecutaRec<T>(string metodo, string path, object obj = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5102");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response;

                    if (metodo == "GET")
                    {
                        response = await client.GetAsync(path);
                    }
                    else if (metodo == "POST")
                    {
                        response = await client.PostAsJsonAsync(path, obj);
                    }
                    else if (metodo == "PATCH")
                    {
                        var payload = JsonConvert.SerializeObject(obj, Formatting.Indented);
                        Console.WriteLine(payload);

                        response = await client.PatchAsJsonAsync(path, obj);
                    }
                    else if (metodo == "DELETE")
                    {
                        response = await client.DeleteAsync(path);
                    }
                    else
                    {
                        throw new ArgumentException("Método HTTP inválido.");
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        // Tenta capturar a mensagem de erro retornada pela API
                        var erroMsg = await response.Content.ReadAsStringAsync();
                        var erro = JsonConvert.DeserializeObject<dynamic>(erroMsg);
                        var teste = erro.errors;
                        throw new HttpRequestException($"Erro {response.StatusCode}: {teste.ToString()}");
                    }

                    if (metodo == "GET")
                    {
                        var retorno = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(retorno);
                    }
                    else
                    {
                        return default;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Erro na requisição: {ex.Message}");
                return default;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
                return default;
            }
        }

        private async Task LoadTaable()
        {
            DateTime dtini = Convert.ToDateTime(dateTimePicker2.Value);
            DateTime dtfim = Convert.ToDateTime(dateTimePicker3.Value);

            // Desabilita o botão enquanto carrega os dados
            button2.Enabled = false;

            // Realiza a requisição para buscar os dados
            var retorno = await ExecutaRec<List<Geral>>("GET", $"/geral/retorno?PageNumber=1&PageSize=50&DataIni={Uri.EscapeDataString(dtini.ToString("MM/dd/yyyy HH:mm:ss"))}&DataFim={Uri.EscapeDataString(dtfim.ToString("MM/dd/yyyy HH:mm:ss"))}");

            // Verifica se há retorno
            if (retorno.Count > 0)
            {
                // Limpa completamente o DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Configura a fonte de dados
                dataGridView1.DataSource = retorno;

                // Ajusta automaticamente o tamanho da última coluna
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Adiciona a coluna "Pagar" como a primeira
                DataGridViewButtonColumn buttonColumnPagar = new DataGridViewButtonColumn
                {
                    HeaderText = "Pagar",
                    Name = "Botao",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Insert(0, buttonColumnPagar);

                // Adiciona a coluna "Excluir" como a segunda
                DataGridViewButtonColumn buttonColumnExcluir = new DataGridViewButtonColumn
                {
                    HeaderText = "Excluir",
                    Name = "Excluir",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Insert(1, buttonColumnExcluir);

                // Evento para clique no botão "Pagar"
                dataGridView1.CellClick += async (s, e) =>
                {
                    if (e.ColumnIndex == dataGridView1.Columns["Botao"].Index && e.RowIndex >= 0)
                    {
                        var categoria = dataGridView1.Rows[e.RowIndex].Cells["Categoria"].Value?.ToString();
                        dataGridView1.Enabled = false;
                        if (categoria == "Débito")
                        {
                            await ExecutaRec<dynamic>("PATCH", $"/debito/alterar/{Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString())}", new List<UpClass>
                    {
                        new UpClass
                        {
                            OperationType = 2,
                            Path = "/status",
                            Op = "replace",
                            From = null,
                            Value = "S"
                        }
                    });
                        }
                        else if (categoria == "Crédito")
                        {
                            await ExecutaRec<dynamic>("PATCH", $"/credito/pagamento/{Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString())}", new List<UpClass>
                    {
                        new UpClass
                        {
                            OperationType = 2,
                            Path = "/status",
                            Op = "replace",
                            From = null,
                            Value = "S"
                        }
                    });
                        }
                        else if (categoria == "Saldo")
                        {
                            await ExecutaRec<dynamic>("PATCH", $"/saldo/alterar/{Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString())}", new List<UpClass>
                    {
                        new UpClass
                        {
                            OperationType = 2,
                            Path = "/status",
                            Op = "replace",
                            From = null,
                            Value = "R"
                        }
                    });
                        }
                        await LoadTaable();
                        dataGridView1.Enabled = true;

                    }
                };

                // Evento para clique no botão "Excluir"
                dataGridView1.CellClick += async (s, e) =>
                {
                    if (e.ColumnIndex == dataGridView1.Columns["Excluir"].Index && e.RowIndex >= 0)
                    {
                        dataGridView1.Enabled = false;

                        var categoria = dataGridView1.Rows[e.RowIndex].Cells["Categoria"].Value?.ToString();
                        if (categoria == "Débito")
                        {
                            await ExecutaRec<dynamic>("DELETE", $"/debito/deleta/{Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString())}");
                            await LoadTaable();
                        }
                        else if (categoria == "Crédito")
                        {
                            await ExecutaRec<dynamic>("DELETE", $"/credito/deleta/{Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString())}");
                        }
                        
                        else if (categoria == "Saldo")
                        {
                            await ExecutaRec<dynamic>("DELETE", $"/saldo/deleta/{Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString())}");
                        }
                            await LoadTaable();
                        dataGridView1.Enabled = true;

                    }
                };

                // Habilita o botão novamente após terminar
                button2.Enabled = true;
            }
            else
            {
                // Caso não haja retorno, limpa a tabela
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                button2.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxValorInteiro.Enabled = comboBox1.Text.Equals("Crédito") ? true : false;
            textBoxParcelas.Enabled = comboBox1.Text.Equals("Crédito") ? true : false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text.Equals("Crédito"))
                {
                    groupBox1.Enabled = false;
                    await ExecutaRec<List<Geral>>("POST", $"/credito/cadastro", new Credito
                    {
                        userId = Convert.ToInt32(textBoxUser.Text),
                        DataVencimento = DateTime.Now,
                        titulo = textBoxTitulo.Text,
                        descricao = textBoxDescricao.Text,
                        TotalParcelas = Convert.ToInt32(textBoxParcelas.Text),
                        status = "N",
                        valor = Convert.ToDouble(textBoxValor.Text),
                        ValorIntegral = Convert.ToDouble(textBoxValorInteiro.Text),
                        dthrReg = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-ddThh:mm:ss"))
                    });
                }
                else if (comboBox1.Text.Equals("Débito"))
                {
                    groupBox1.Enabled = false;
                    await ExecutaRec<List<dynamic>>("POST", $"/debito/cadastro", new Debito
                    {
                        userId = Convert.ToInt32(textBoxUser.Text),
                        titulo = textBoxTitulo.Text,
                        descricao = textBoxDescricao.Text,
                        status = "N",
                        valor = Convert.ToDouble(textBoxValor.Text),
                        dthrReg = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-ddThh:mm:ss"))
                    });
                }
                else
                {
                    groupBox1.Enabled = false;
                    await ExecutaRec<List<dynamic>>("POST", $"/saldo/cadastro", new Saldo
                    {
                        userId = Convert.ToInt32(textBoxUser.Text),
                        titulo = textBoxTitulo.Text,
                        descricao = textBoxDescricao.Text,
                        status = "N",
                        valor = Convert.ToDouble(textBoxValor.Text),
                        dthrReg = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-ddThh:mm:ss"))
                    });
                }
                groupBox1.Enabled = true;
                LoadTaable();
                Clear();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadTaable();
        }
        private void Clear()
        {
            textBoxTitulo.Text = string.Empty;
            textBoxDescricao.Text = string.Empty;
            textBoxValor.Text = string.Empty;
            textBoxValorInteiro.Text = string.Empty;
            textBoxParcelas.Text = string.Empty;
        }
    }
}
