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
    public class Batch
    {
        public string batch_name;
        public string date_added;
        public Batch(string name, string date_added)
        {
            this.batch_name = name;
            this.date_added = date_added;
        }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
            add_panel_btn.Style = (Style)Application.Current.Resources["disabled_btn"];
            rec_data_btn.Style = (Style)Application.Current.Resources["disabled_btn"];

            // Instead of hard coded items, the data will be pulled from DB
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
        private void nav_to_FieldDay(object sender, RoutedEventArgs e)
        {
            // if field day not in table do field day page else do recordPage
            Debug.WriteLine("To field day");
            this.Frame.Navigate(typeof(FieldDay), this.selected_batch.batch_name);
        }

        private void nav_to_FieldDay_menu(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To field day");
            this.Frame.Navigate(typeof(FieldDay));
        }

        private void nav_to_AddPanels(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To add panels");
            this.Frame.Navigate(typeof(AddBatch)); //, name.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BatchPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Batch batch = BatchPanel.SelectedItem as Batch;
            if (batch != null)
            {
                this.selected_batch = batch;
                add_panel_btn.IsEnabled = true;
                rec_data_btn.IsEnabled = true;
                add_panel_btn.Style = (Style)Application.Current.Resources["enabled_btn"];
                rec_data_btn.Style = (Style)Application.Current.Resources["enabled_btn"];
            }
            else
            {
                add_panel_btn.IsEnabled = false;
                rec_data_btn.IsEnabled = false;
                add_panel_btn.Style = (Style)Application.Current.Resources["disabled_btn"];
                rec_data_btn.Style = (Style)Application.Current.Resources["disabled_btn"];
            }
        }
    }
}
