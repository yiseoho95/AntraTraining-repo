using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.UI.Dashboard
{
    public class MovieDashboard : IDashboard
    {
        public void ShowDashboard()
        {
            ManageMovie manageMovie = new ManageMovie();
            manageMovie.Run();
        }
    }
}
