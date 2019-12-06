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

    public sealed partial class TubewormPage : Page
    {
        public FoulingDataEntry data_entry;
        public WJDataEntry wj_data_entry;
        public TubewormPage()
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
                TubewormTitle.Text = title;
                pcal.Text = this.data_entry.tubeworms.pcal_perc;
                psed.Text = this.data_entry.tubeworms.psed_perc;
            }
            else if (e.Parameter != null && (e.Parameter is WJDataEntry))
            {
                this.wj_data_entry = (WJDataEntry)e.Parameter;
                string title = $"{this.wj_data_entry.data_info.batch.batch_name} {field_date} - Fouling Panel {this.wj_data_entry.data_info.panel_id} - {this.wj_data_entry.psi} psi";
                TubewormTitle.Text = title;
                pcal.Text = this.wj_data_entry.data_info.tubeworms.pcal_perc;
                psed.Text = this.wj_data_entry.data_info.tubeworms.psed_perc;
            }

            base.OnNavigatedTo(e);
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (this.data_entry != null)
            {
                this.data_entry.tubeworms.pcal_perc = pcal.Text;
                this.data_entry.tubeworms.psed_perc = psed.Text;
                this.Frame.Navigate(typeof(FoulingDataPage), this.data_entry);
            }
            else if(this.wj_data_entry != null)
            {
                this.wj_data_entry.data_info.tubeworms.pcal_perc = pcal.Text;
                this.wj_data_entry.data_info.tubeworms.psed_perc = psed.Text;
                this.Frame.Navigate(typeof(WJDataPage), this.wj_data_entry);
            }
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BatchHome));
        }
    }
}
