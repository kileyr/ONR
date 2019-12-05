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
/** Description: Page for submitting deploy or retrival dates for a selected batch. If the 
 * batch has already been deployed the date field for deploy should be filled with query results
 **/
    public sealed partial class DeployRetrieve : Page
    {
        public Batch selected_batch;
        public DeployRetrieve()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*
            * TODO: Read from Batch table to see if there is a deploy date 
            * if there is fill in that box 
            */

            if (e.Parameter != null)
            {
                this.selected_batch = (Batch)e.Parameter;
                DRTitle.Text = $"Deploy or Retrieve {this.selected_batch.batch_name}";
            }
            base.OnNavigatedTo(e);
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
          
            this.Frame.Navigate(typeof(BatchHome));
        }

        private void save(object sender, RoutedEventArgs e)
        {
            /*
             * TODO: Write contents of textBoxes to database
             * Write either deploy or retrieve date to Batch table for the batch id 
             */
            this.Frame.Navigate(typeof(BatchHome));
        }
    }
}
