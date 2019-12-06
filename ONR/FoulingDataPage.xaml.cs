using System;
using System.Diagnostics;
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



namespace ONR
{
    /* Description:
     *  Page for recording fouling data for a panel in the field. Takes as argument on navigation a 
     *  FoulingDataEntry object, which specifies batch info and panel id. When user saves the data is written 
     *  to the foulding data information table with the field day tag as a unique identifier. 
     */
    public sealed partial class FoulingDataPage : Page
    {
        public FoulingDataEntry data_entry;
        public float total_macro_count = 0;
        public FoulingDataPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write fouling title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            if (e.Parameter != null)
            {
                this.data_entry = (FoulingDataEntry)e.Parameter;
                string title = $"{this.data_entry.batch.batch_name} {field_date} - Fouling Panel {this.data_entry.panel_id}";
                FoulingDataTitle.Text = title;
                update_total_macro();
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
             
            this.Frame.Navigate(typeof(FoulingPanels), this.data_entry.batch);
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FoulingPanels), this.data_entry.batch);
        }

        private void to_barnacle(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BarnaclePage), this.data_entry);
        }

        private void to_molluscs(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MolluscsPage), this.data_entry);
        }

        private void to_tubeworms(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TubewormPage), this.data_entry);
        }

        private void to_bryozoans(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BryozoansPage), this.data_entry);
        }

        private void to_hydroids(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HydroidsPage), this.data_entry);
        }

        private void to_anenomes(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AnenomesPage), this.data_entry);
        }

        private void to_tunicates(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TunicatesPage), this.data_entry);
        }

        private void to_amphipods(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AmphipodsPage), this.data_entry);
        }

        private void to_sponges(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SpongesPage), this.data_entry);
        }

        private void to_aglae(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AglaePage), this.data_entry);
        }

        private void to_unknownsoft(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UnknownSoftPage), this.data_entry);
        }

        private void to_incipient(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(IncipientPage), this.data_entry);
        }

        private void to_biofilm(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BiofilmPage), this.data_entry);
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

        private float read_int(string number)
        {
            float val = 0;
            if (number != "")
            {
                try
                {
                    val = float.Parse(number, CultureInfo.InvariantCulture);

                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse");
                }
            }
            return val;
        }

        private void update_total_macro()
        {

            float val1 = read_int(this.data_entry.barnacle.barn_perc);
            float val2 = read_int(this.data_entry.molluscs.mol_perc);
            float val3 = read_int(this.data_entry.tubeworms.pcal_perc);
            float val4 = read_int(this.data_entry.tubeworms.psed_perc);
            float val5 = read_int(this.data_entry.bryozoans.eb);
            float val6 = read_int(this.data_entry.bryozoans.wsp);
            float val7 = read_int(this.data_entry.bryozoans.br);
            float val8 = read_int(this.data_entry.hydroids.cn);
            float val9 = read_int(this.data_entry.anenomes.cn);
            float val10 = read_int(this.data_entry.tunicates.ct);
            float val11 = read_int(this.data_entry.tunicates.pcal);
            float val12 = read_int(this.data_entry.amphipods.cor);
            float val13 = read_int(this.data_entry.sponges.sp);
            float val14 = read_int(this.data_entry.aglae.pcal);
            float val15 = read_int(this.data_entry.unknownsoft.us_perc);
            float val16 = read_int(this.data_entry.incipient.IF);
            this.total_macro_count = val1 + val2 + val3 + val4 + val5 + val6 + val7 + val8 + val9 + val10 + val11 + val12 + val13 + val14 + val15 + val16;
            string val = (this.total_macro_count).ToString("N2");
            total_macro.Text = val;
        }

    }
}
