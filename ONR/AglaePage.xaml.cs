using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace ONR
{
    public sealed partial class AglaePage : Page
    {
        public FoulingDataEntry data_entry;

        public AglaePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            // If its foulding fill in the information
            if (e.Parameter != null && (e.Parameter is FoulingDataEntry))
            {
                this.data_entry = (FoulingDataEntry)e.Parameter;
                string title = $"{this.data_entry.batch.batch_name} {field_date} - Fouling Panel {this.data_entry.panel_id}";
                AglaeTitle.Text = title;
                type.Text = this.data_entry.aglae.type;
                pcal.Text = this.data_entry.aglae.pcal;
            }

            base.OnNavigatedTo(e);
        }

        private void save(object sender, RoutedEventArgs e)
        {
            this.data_entry.aglae.type = type.Text;
            this.data_entry.aglae.pcal = pcal.Text;
            this.Frame.Navigate(typeof(FoulingDataPage), this.data_entry);
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BatchHome));
        }
    }
}
