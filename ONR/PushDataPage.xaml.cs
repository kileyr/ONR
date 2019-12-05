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
    }
}
