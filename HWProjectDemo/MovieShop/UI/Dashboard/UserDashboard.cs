using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.UI.Dashboard
{
    public class UserDashboard : IDashboard
    {
        public void ShowDashboard()
        {
            ManageUser manageUser = new ManageUser();
            manageUser.Run();
        }
    }
}
