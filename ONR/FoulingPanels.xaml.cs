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
     *  This page displays all panels in the selected batch. Selecting a panel will take a user to the foulding
     *  data information. Navigation to this page takes as an argument a Batch object, specifying the name and id 
     *  of the batch. 
     */
    public sealed partial class FoulingPanels : Page
    {
        public Batch selected_batch;
        private ObservableCollection<PanelFouling> _foulingPanels = new ObservableCollection<PanelFouling>();
       
        public FoulingPanels()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<PanelFouling> fouling_panels
        {
            get { return this._foulingPanels; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write field day title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            if (e.Parameter != null)
            {
                this.selected_batch = (Batch)e.Parameter;
                foulingTitle.Text = $"{this.selected_batch.batch_name} {field_date} - Fouling Panels";
            }
            fouling_panels.Add(new PanelFouling("1234"));
            fouling_panels.Add(new PanelFouling("1235"));
            fouling_panels.Add(new PanelFouling("1236"));
            fouling_panels.Add(new PanelFouling("1237"));
            fouling_panels.Add(new PanelFouling("1238"));

            base.OnNavigatedTo(e);
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BatchHome));
        }

        private void to_fouling(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To fouling");
            //this.Frame.Navigate(typeof(FoulingPanels), this.selected_batch);
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

        private void select_FoulingPanel(object sender, SelectionChangedEventArgs e)
        {
            /* TODO:
             *  A read should be performed to the fouling information table here for the
             *  batch_field day identifier and the panel. If there is data recorded initialize organisms with that
             *  info, other wise empty inititalization
             */
            PanelFouling panel = FoulingPanel.SelectedItem as PanelFouling;
            Barnacle barnacle = new Barnacle();
            Molluscs molluscs = new Molluscs();
            Tubeworms tubeworms = new Tubeworms();
            Bryozoans bryozoans = new Bryozoans();
            Hydroids hydroids = new Hydroids();
            Anenomes anenomes = new Anenomes();
            Tunicates tunicates = new Tunicates();
            Amphipods amphipods = new Amphipods();
            Sponges sponges = new Sponges();
            Aglae aglae = new Aglae();
            UnknownSoft unknown = new UnknownSoft();
            Incipient incipient = new Incipient();
            Biofilm biofilm = new Biofilm();

            FoulingDataEntry data = new FoulingDataEntry(panel.panel_id, this.selected_batch, barnacle,
                molluscs, tubeworms, bryozoans, hydroids, anenomes, tunicates, amphipods, sponges, aglae, 
                unknown, incipient, biofilm);
            this.Frame.Navigate(typeof(FoulingDataPage), data);
        }

        private void specify_panel(object sender, RoutedEventArgs e)
        {
            /* TODO:
             *  A read should be performed to the fouling information table here for the
             *  batch_field day identifier and the panel. If there is data recorded initialize organisms with that
             *  info, other wise empty inititalization
             */
            string panel_id = panel.Text;
            if (string.IsNullOrEmpty(panel_id)) { return; }

            PanelFouling p = new PanelFouling(panel_id);

            Barnacle barnacle = new Barnacle();
            Molluscs molluscs = new Molluscs();
            Tubeworms tubeworms = new Tubeworms();
            Bryozoans bryozoans = new Bryozoans();
            Hydroids hydroids = new Hydroids();
            Anenomes anenomes = new Anenomes();
            Tunicates tunicates = new Tunicates();
            Amphipods amphipods = new Amphipods();
            Sponges sponges = new Sponges();
            Aglae aglae = new Aglae();
            UnknownSoft unknown = new UnknownSoft();
            Incipient incipient = new Incipient();
            Biofilm biofilm = new Biofilm();

            FoulingDataEntry data = new FoulingDataEntry(p.panel_id, this.selected_batch, barnacle,
                molluscs, tubeworms, bryozoans, hydroids, anenomes, tunicates, amphipods, sponges, aglae,
                unknown, incipient, biofilm);
            this.Frame.Navigate(typeof(FoulingDataPage), data);
        }
    }
}
