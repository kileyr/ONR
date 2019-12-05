using System;
using System.Diagnostics;
using System.Collections.ObjectModel;
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
     *  This page displays panels for recording push information from the selected batch. Selecting a panel 
     *  will take the user to the panel data entry page. Naviagation to this page takes as an argument a Batch
     *  object that specifies the batch name and id. 
     */
    public sealed partial class PushPanels : Page
    {
        public Batch selected_batch;
        private ObservableCollection<PanelPush> _pushPanels = new ObservableCollection<PanelPush>();

        public PushPanels()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<PanelPush> push_panels
        {
            get { return this._pushPanels; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write field day title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            if (e.Parameter != null)
            {
                this.selected_batch = (Batch)e.Parameter;
                PushTitle.Text = $"{this.selected_batch.batch_name} {field_date} - Push Panels";
            }

            push_panels.Add(new PanelPush("1234"));
            push_panels.Add(new PanelPush("1235"));
            push_panels.Add(new PanelPush("1236"));
            push_panels.Add(new PanelPush("1237"));
            push_panels.Add(new PanelPush("1238"));

            base.OnNavigatedTo(e);
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
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

        private void select_PushPanel(object sender, SelectionChangedEventArgs e)
        {
            PanelPush panel = _PushPanels_.SelectedItem as PanelPush;
            PushDataEntry data = new PushDataEntry(panel.panel_id, this.selected_batch);
            this.Frame.Navigate(typeof(PushDataPage), data);
        }
    }
}
