using System;
using System.Diagnostics;
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
     *  This is the record data page for push information that would be recorded for a panel in the field.
     *  User can save and add new to write the information to the table and record for a new organism on 
     *  the same panel. This page takes a PushDataEntry object that contains batch info, panel id.
     */
    public sealed partial class PushDataPage : Page
    {
        public PushDataEntry data_entry;
        public PushDataPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write push title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            if (e.Parameter != null)
            {
                this.data_entry = (PushDataEntry)e.Parameter;
                string title = $"{this.data_entry.batch.batch_name} {field_date} - Push Panel {this.data_entry.panel_id}";
                PushDataTitle.Text = title;
            }

            base.OnNavigatedTo(e);
        }

        /* NOTE: The push table has a linear length and linear width field as well as a circular 
         * width and circular length field and only one is used for each organism depending on the shape
         * Write to the fields given whether the user checked linear or circular
         */
        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BatchHome));
        }

        private void save_and_exit(object sender, RoutedEventArgs e)
        {
            /**
             * TODO: Write contents of textBoxes to database here
             **/

            this.Frame.Navigate(typeof(PushPanels), this.data_entry.batch);
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PushPanels), this.data_entry.batch);
        }

        private void save_and_new(object sender, RoutedEventArgs e)
        {
            /**
             * TODO: Write contents of textBoxes to database here 
             **/

            this.Frame.Navigate(typeof(PushDataPage), this.data_entry);
        }

        private void handle_check(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Name == "circular")
            {
                linear.IsChecked = false;
            }
            else if (cb.Name == "linear")
            {
                circular.IsChecked = false;
            }
        }
    }
}
