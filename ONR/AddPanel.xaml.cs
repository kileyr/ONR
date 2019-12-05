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
    /* Description:
     *  Page to add a new panel to a batch - provides the fields needed to fill out in order to add an entry
     *  to either the water jet panel or fouling panel database for the addition of a new panel
     */
    public sealed partial class AddPanel : Page
    {
        public Batch selected_batch;
        public AddPanel()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write field day title

            if (e.Parameter != null)
            {
                this.selected_batch = (Batch)e.Parameter;
                newPanelTitle.Text = $"Add Panel to Batch {this.selected_batch.batch_name}";
            }
            base.OnNavigatedTo(e);
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BatchHome));
        }

        private void save_and_exit(object sender, RoutedEventArgs e)
        {
            /*
             * TODO: Write contents of textBoxes to database here
             */

            this.Frame.Navigate(typeof(BatchHome));
        }

        private void save_and_new(object sender, RoutedEventArgs e)
        { 
            /*
             * TODO: Write contents of textBoxes to database here
             */

            this.Frame.Navigate(typeof(AddPanel), this.selected_batch);
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BatchHome));
        }
    }
}
