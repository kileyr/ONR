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

    public sealed partial class BarnaclePage : Page
    {
        public FoulingDataEntry data_entry;
        public WJDataEntry wj_data_entry;
        public BarnaclePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            this.data_entry = null;
            this.wj_data_entry = null;
            // If its foulding fill in the information
            if (e.Parameter != null && (e.Parameter is FoulingDataEntry))
            {
                this.data_entry = (FoulingDataEntry)e.Parameter;
                string title = $"{this.data_entry.batch.batch_name} {field_date} - Fouling Panel {this.data_entry.panel_id}";
                BarnacleTitle.Text = title;
                barn_perc.Text = this.data_entry.barnacle.barn_perc;
                barn_num.Text = this.data_entry.barnacle.barn_num;
                barn_size.Text = this.data_entry.barnacle.barn_size;
            }
            else if(e.Parameter != null && (e.Parameter is WJDataEntry))
            {
                this.wj_data_entry = (WJDataEntry)e.Parameter;
                string title = $"{this.wj_data_entry.data_info.batch.batch_name} {field_date} - Fouling Panel {this.wj_data_entry.data_info.panel_id} - {this.wj_data_entry.psi} psi";
                BarnacleTitle.Text = title;
                barn_perc.Text = this.wj_data_entry.data_info.barnacle.barn_perc;
                barn_num.Text = this.wj_data_entry.data_info.barnacle.barn_num;
                barn_size.Text = this.wj_data_entry.data_info.barnacle.barn_size;
            }

            base.OnNavigatedTo(e);
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (this.data_entry != null)
            {
                this.data_entry.barnacle.barn_perc = barn_perc.Text;
                this.data_entry.barnacle.barn_size = barn_size.Text;
                this.data_entry.barnacle.barn_num = barn_num.Text;
                this.Frame.Navigate(typeof(FoulingDataPage), this.data_entry);
            }
            else if(this.wj_data_entry != null)
            {
                this.wj_data_entry.data_info.barnacle.barn_perc = barn_perc.Text;
                this.wj_data_entry.data_info.barnacle.barn_size = barn_size.Text;
                this.wj_data_entry.data_info.barnacle.barn_num = barn_num.Text;
                this.Frame.Navigate(typeof(WJDataPage), this.wj_data_entry);
            }
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BatchHome));
        }
    }
}
