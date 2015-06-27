using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace AppTrabalhoG2.Pages
{
    public partial class SobreAppPage : PhoneApplicationPage
    {
        public SobreAppPage()
        {
            InitializeComponent();
        }

        private void appbarLike_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }
    }
}