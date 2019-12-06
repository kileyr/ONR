using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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

    public sealed partial class BatchHome : Page
    {
        public Batch selected_batch;
        public BatchHome()
        {
            this.InitializeComponent();
            this.selected_batch = null;

        }

        private ObservableCollection<Batch> _batches = new ObservableCollection<Batch>();

        public ObservableCollection<Batch> Batches
        {
            get { return this._batches; }
        }

        // This method should be defined within your main page class.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // buttons not enabled to start
            add_panel_btn.IsEnabled = false;
            rec_data_btn.IsEnabled = false;
            depl_retrv.IsEnabled = false;

            /* TODO:
             * Read in batches from table and populate list
             */
            Batches.Add(new Batch("DW#5", "02/02/2019"));
            Batches.Add(new Batch("TS#3", "03/05/2017"));
            Batches.Add(new Batch("TP#6", "06/21/2013"));
            Batches.Add(new Batch("DW#5", "02/02/2019"));
            Batches.Add(new Batch("TS#3", "03/05/2017"));
            Batches.Add(new Batch("TP#6", "06/21/2013"));
            Batches.Add(new Batch("DW#5", "02/02/2019"));
            Batches.Add(new Batch("TS#3", "03/05/2017"));
            Batches.Add(new Batch("TP#6", "06/21/2013"));
        }

        private void check_nav_path(object sender, RoutedEventArgs e)
        {
            /* TODO:
             * Check to see if a field day is created, if so go to RecordHome, if not go to FieldDay
             */
            this.Frame.Navigate(typeof(FieldDay), this.selected_batch);
        }
        private void nav_to_FieldDay(object sender, RoutedEventArgs e)
        {
            // if field day not in table do field day page else do recordPage
            Debug.WriteLine("To field day");
            this.Frame.Navigate(typeof(FieldDay), this.selected_batch);
        }

        private void nav_to_FieldDay_menu(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To field day");
            this.Frame.Navigate(typeof(FieldDay));
        }

        private void nav_to_AddPanels(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To add panels");
            this.Frame.Navigate(typeof(AddPanel), this.selected_batch);
        }

        private void nav_to_DR(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DeployRetrieve), this.selected_batch);
        }

        private void new_batch(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddBatch));
        }

        private void BatchPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Batch batch = BatchPanel.SelectedItem as Batch;
            if (batch != null)
            {
                this.selected_batch = batch;
                add_panel_btn.IsEnabled = true;
                rec_data_btn.IsEnabled = true;
                depl_retrv.IsEnabled = true;
            }
            else
            {
                add_panel_btn.IsEnabled = false;
                rec_data_btn.IsEnabled = false;
                depl_retrv.IsEnabled = false;
            }
        }
    }
}
