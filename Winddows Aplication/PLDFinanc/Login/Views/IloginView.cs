using PLDFinanc.Login.Controllers;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.Login.View;

public interface IloginView
{
    public void SetController(LoginController controller);
    public MetroTextBox User { get; set; }
    public MetroTextBox Pass{ get; set; }
    public MetroCheckBox CheckPass { get; set; }
    public MetroButton BtnLogin { get; set; }

    event EventHandler LogarApp;
}
