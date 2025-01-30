using PLDFinanc.Home.Controllers;
using PLDFinanc.Login.Controllers;
using ReaLTaiizor.Child.Metro;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLDFinanc.Home.Views
{
    public partial class HomeView : Form, IHomeView
    {
        public HomeView()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroTabControl Page { get => metroTabControl; set => metroTabControl = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FlowLayoutPanel Panael { get => flowLayoutPanel1; set => flowLayoutPanel1 = value; }

        HomeController _controller;
        public void SetController(HomeController controller)
        {
           _controller = controller;    
        }
    }
}
