using PLDFinanc.Home.Controllers;
using PLDFinanc.Login.Controllers;
using ReaLTaiizor.Child.Metro;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.Home.Views
{
    public interface IHomeView
    {
        public void SetController(HomeController controller);
        public MetroTabControl Page { get; set; }
        public FlowLayoutPanel Panael { get; set; }
    }
}
