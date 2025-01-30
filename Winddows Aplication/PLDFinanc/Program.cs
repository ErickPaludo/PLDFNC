using PLDFinanc.Login.Controllers;
using PLDFinanc.Login.Models;

namespace PLDFinanc
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginView view = new LoginView();
            LoginModel model = new LoginModel();
            LoginController controller = new LoginController(view, model);

            Application.Run(view);
        }
    }
}