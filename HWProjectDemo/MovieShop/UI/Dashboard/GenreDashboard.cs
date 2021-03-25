using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.UI.Dashboard
{
    public class GenreDashboard : IDashboard
    {
        public void ShowDashboard()
        {
            ManageGenre manageGenre = new ManageGenre();
            manageGenre.Run();
        }
    }
}
