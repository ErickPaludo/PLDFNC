using PLDFinanc.CadastroGastos.Models;
using PLDFinanc.CadastroGastos.Views;
using PLDFinanc.Home.Models;
using PLDFinanc.Home.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.CadastroGastos.Controllers
{
    public class CadastroController
    {
        ICadastroView view;
        CadastroModel model;

        public CadastroController(ICadastroView view, CadastroModel model)
        {
            this.view = view;
            this.model = model;
            view.SetController(this);
        }
    }
}
