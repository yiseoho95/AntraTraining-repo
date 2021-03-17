using System;
using System.Collections.Generic;
using System.Text;

namespace ClassReview031621.UI
{
    class Dashboard
    {
        public void ShowDashboard()
        {
            ManageDepartment manageDepartment = new ManageDepartment();
            manageDepartment.Run();
        }
    }
}
