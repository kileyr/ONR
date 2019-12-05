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
     *  This is a placeholder page while the user decides is they want to record water jet, push or fouling
     *  data to record for the batch. On navigation takes as argument a Batch object with the batch name and id
     */
    public sealed partial class RecordHome : Page
    {
        public Batch selected_batch;

        public RecordHome()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            if (e.Parameter != null)
            {
                this.selected_batch = (Batch)e.Parameter;
                RecordTitle.Text = $"{this.selected_batch.batch_name} {field_date}";
            }
            base.OnNavigatedTo(e);
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To batch home");
            this.Frame.Navigate(typeof(BatchHome));
        }

        private void to_fouling(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To fouling");
            this.Frame.Navigate(typeof(FoulingPanels), this.selected_batch);
        }

        private void to_waterjet(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To waterjet");
            WaterJet wj = new WaterJet(this.selected_batch, 0);
            this.Frame.Navigate(typeof(WJPanels), wj);
        }

        private void to_push(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To push");
            this.Frame.Navigate(typeof(PushPanels), this.selected_batch);
        }
    }
}
