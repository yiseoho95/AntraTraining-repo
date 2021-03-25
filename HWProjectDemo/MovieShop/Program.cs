using System;
using MovieShop.UI;
using System.Linq;
using MovieShop.UI.Dashboard;

namespace MovieShop
{
    class Program
    {
        static void Main(string[] args)
        {
            IDashboard dashboard = new MainDashboard();
            dashboard.ShowDashboard();

        }
    }
}
