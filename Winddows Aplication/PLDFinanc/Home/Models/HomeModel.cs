using Newtonsoft.Json;
using PLDFinanc.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.Home.Models
{
    public class HomeModel
    {
        public async Task<T> ExecutaRec<T>(string metodo, string path, object obj = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://25.2.220.24:5102");
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
                    else
                    {
                        throw new ArgumentException("Método HTTP inválido.");
                    }

                    response.EnsureSuccessStatusCode(); // Verifica se a requisição foi bem-sucedida.

                    var retorno = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(retorno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na requisição: {ex.Message}");
                return default; // Retorna o valor padrão de T (null para classes, 0 para números, etc.)
            }
        }
    }
}
