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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ONR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
                string title = $"{this.data_entry.batch_name} {field_date} - Push Panel {this.data_entry.panel_id}";
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

            this.Frame.Navigate(typeof(PushPanels), this.data_entry.batch_name);
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PushPanels), this.data_entry.batch_name);
        }

        private void save_and_new(object sender, RoutedEventArgs e)
        {
            /**
             * TODO: Write contents of textBoxes to database here 
             **/
            coating.Text = "";
            length.Text = "";
            width.Text = "";
            force.Text = "";
            bpr.Text = "";
            notes.Text = "";
        }
    }
}
