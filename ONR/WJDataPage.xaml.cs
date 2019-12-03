using System;
using System.Globalization;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ONR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WJDataPage : Page
    {
        public WJDataEntry data_entry;
        public float total_macro_count = 0;
        public WJDataPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
            // write wj title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            if (e.Parameter != null)
            {
                this.data_entry = (WJDataEntry)e.Parameter;
                // if the psi is 240 there is no next icon
                if(this.data_entry.psi == 240)
                {
                    next_button.Visibility = Visibility.Collapsed;
                }
                string title = $"{this.data_entry.batch_name} {field_date} - Panel {this.data_entry.panel_id}"; 
                WJDataTitle.Text = title;
                psiTitle.Text = $"{this.data_entry.psi} psi";
            }

            base.OnNavigatedTo(e);
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BatchHome));
        }

        private void save_and_exit(object sender, RoutedEventArgs e)
        {
            /**
             * TODO: Write contents of textBoxes to database here
             **/

            this.Frame.Navigate(typeof(WJPanels), this.data_entry.batch_name);
        }
        
        private void save_and_next(object sender, RoutedEventArgs e)
        {
            /**
             * TODO: Write contents of textBoxes to database here
             **/
            this.data_entry.next_psi();
            this.Frame.Navigate(typeof(WJDataPage), this.data_entry);
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WJPanels), this.data_entry.batch_name);
        }

        private void toggle_total_macro(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {

                    total_macro.Visibility = Visibility.Visible;
                }
                else
                {

                    total_macro.Visibility = Visibility.Collapsed;
                }
            }
        }

        private float read_int(TextBox name)
        {
            float val = 0;
            try
            {
                string t = name.Text;
                val = float.Parse(t, CultureInfo.InvariantCulture);

            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse");
            }
            return val;
        }

        private void update_total_macro(object sender, RoutedEventArgs e)
        {

            float val1 = read_int(barn_perc);
            float val2 = read_int(moll_perc);
            float val3 = read_int(psed_perc);
            float val4 = read_int(pcal_perc);
            float val5 = read_int(eb_perc);
            float val6 = read_int(wsp_perc);
            float val7 = read_int(br_perc);
            float val8 = read_int(hyd_perc);
            float val9 = read_int(anen_perc);
            float val10 = read_int(tun_ct);
            float val11 = read_int(tun_pcal);
            float val12 = read_int(amph_cor);
            float val13 = read_int(sp_perc);
            float val14 = read_int(alg_pcal);
            float val15 = read_int(if_field);
            float val16 = read_int(biofilm_si);
            this.total_macro_count = val1 + val2 + val3 + val4 + val5 + val6 + val7 + val8 + val9 + val10 + val11 + val12 + val13 + val14 + val15 + val16;
            string val = (this.total_macro_count).ToString("N2");
            total_macro.Text = val;
        }
    }
}
