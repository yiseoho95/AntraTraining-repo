using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.UI.Dashboard
{
    public class CastDashboard : IDashboard
    {
        public void ShowDashboard()
        {
            ManageCast manageCast = new ManageCast();
            manageCast.Run();
        }
    }
}
