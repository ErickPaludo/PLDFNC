using PLDFinanc.CadastroGastos.Controllers;
using PLDFinanc.Componentes.MicroComponentes;
using PLDFinanc.Home.Controllers;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.CadastroGastos.Views
{
    public interface ICadastroView
    {
        public void SetController(CadastroController controller);
        public InputControl Titulo { get; set; }
        public InputControl Valor { get; set; }
        public InputControl Descricao { get; set; }
        public ComboControl Tipo { get; set; }
        public InputControl Parcelas { get; set; }
        public DataControl Vencimento { get; set; }
        public MetroButton Cadastrar { get; set; }
    }
}
