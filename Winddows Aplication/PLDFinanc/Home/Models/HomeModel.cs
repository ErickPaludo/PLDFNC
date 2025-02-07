using Newtonsoft.Json;
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
        public async Task<dynamic> ExecutaRec(string metodo, string path, object obj = null, int id = 0)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri("https://financ.requestcatcher.com");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = new HttpResponseMessage();
                    switch (metodo)
                    {
                        case "GET":
                            response = await client.GetAsync(path);
                            var retorno = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<dynamic>(retorno);
                            break;
                        case "POST":
                            response = await client.PostAsJsonAsync(path, obj);
                            retorno = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<dynamic>(retorno);
                            break;
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }

        }
    }
}
