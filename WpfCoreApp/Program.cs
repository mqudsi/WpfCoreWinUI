using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoreApp
{
    public class Program
    {
        [System.STAThreadAttribute()]
        public static void Main()
        {
            using (new UwpApp.App())
            {
                var app = new WpfCoreApp.App();
                app.InitializeComponent();
                app.Run();
            }
        }
    }
}
