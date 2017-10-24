using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelAccounting
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            var data = new AccountingModel();
            var wnd = new MainWindow();
            wnd.DataContext = data;
            new Application().Run(wnd);
        }
    }
}
