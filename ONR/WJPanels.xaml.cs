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
     *   This page displays all panels for the given batch that can have data recorded for water jet - 
     *   user must also specify from the drop down menu what psi they will be recording panels under
     *   This page will take a WJRecord object, which will specify the name of the batch, id, current psi, etc.
     */
   
    public sealed partial class WJPanels : Page
    {
        public WaterJet wj_info;
        private ObservableCollection<PanelWJ> _wjPanels = new ObservableCollection<PanelWJ>();

        public WJPanels()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<PanelWJ> wj_panels
        {
            get { return this._wjPanels; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write field day title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            if (e.Parameter != null)
            {
                this.wj_info = (WaterJet)e.Parameter;
                WJTitle.Text = $"{this.wj_info.batch.batch_name} {field_date} - Water Jet Panels";
                psiVal.Text = $"{this.wj_info.psi} psi";
                // if the psi is 240 there is no next icon
                if(this.wj_info.psi == 240)
                {
                    next_button.Visibility = Visibility.Collapsed;
                }
                else if(this.wj_info.psi == 0)
                {
                    back_button.Visibility = Visibility.Collapsed;
                }
            }

            wj_panels.Add(new PanelWJ("1234"));
            wj_panels.Add(new PanelWJ("1235"));
            wj_panels.Add(new PanelWJ("1236"));
            wj_panels.Add(new PanelWJ("1237"));
            wj_panels.Add(new PanelWJ("1238"));
            base.OnNavigatedTo(e);
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BatchHome));
        }

        private void to_fouling(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To fouling");
            this.Frame.Navigate(typeof(FoulingPanels), this.wj_info.batch);
        }

        private void to_waterjet(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To waterjet");
           // this.Frame.Navigate(typeof(WJPanels), this.wj_info.batch);
        }

        private void to_push(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To push");
            this.Frame.Navigate(typeof(PushPanels), this.wj_info.batch);
        }

        private void next_psi(object sender, RoutedEventArgs e)
        {
            if (this.wj_info.psi < 120)
            {
                this.wj_info.psi += 40;
            }
            else if (this.wj_info.psi == 120)
            {
                this.wj_info.psi = 180;
            }
            else if (this.wj_info.psi == 180)
            {
                this.wj_info.psi = 240;
            }
            psiVal.Text = $"{this.wj_info.psi} psi";
            if (this.wj_info.psi > 0 && this.wj_info.psi < 240)
            {
                next_button.Visibility = Visibility.Visible;
                back_button.Visibility = Visibility.Visible;
            }
            else
            {
                next_button.Visibility = Visibility.Collapsed;
            }
        }

        private void back_psi(object sender, RoutedEventArgs e)
        {
            if (this.wj_info.psi <= 120 && this.wj_info.psi > 0)
            {
                this.wj_info.psi -= 40;
            }
            else if (this.wj_info.psi == 180)
            {
                this.wj_info.psi = 120;
            }
            else if (this.wj_info.psi == 240)
            {
                this.wj_info.psi = 180;
            }
            psiVal.Text = $"{this.wj_info.psi} psi";
            if (this.wj_info.psi > 0 && this.wj_info.psi < 240)
            {
                next_button.Visibility = Visibility.Visible;
                back_button.Visibility = Visibility.Visible;
            }
            else
            {
                back_button.Visibility = Visibility.Collapsed;
            }
        }

        private void select_WJPanel(object sender, SelectionChangedEventArgs e)
        {
            /* TODO:
             *  A read should be performed to the waterjet information table here for the
             *  batch_field day identifier and the panel and psi. If there is data recorded initialize organisms with that
             *  info, other wise empty inititalization
            */
            PanelWJ panel = _WJPanels_.SelectedItem as PanelWJ;

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

            FoulingDataEntry data_info = new FoulingDataEntry(panel.panel_id, this.wj_info.batch, barnacle,
                molluscs, tubeworms, bryozoans, hydroids, anenomes, tunicates, amphipods, sponges, aglae,
                unknown, incipient, biofilm);
            WJDataEntry data = new WJDataEntry(data_info, this.wj_info.psi);
            this.Frame.Navigate(typeof(WJDataPage), data);
        }

        private void specify_panel(object sender, RoutedEventArgs e)
        {
            /* TODO:
             *  A read should be performed to the waterjet information table here for the
             *  batch_field day identifier and the panel and psi. If there is data recorded initialize organisms with that
             *  info, other wise empty inititalization
            */
            string panel_id = panel.Text;
            if(string.IsNullOrEmpty(panel_id)) { return; }

            PanelWJ p = new PanelWJ(panel_id);
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

            FoulingDataEntry data_info = new FoulingDataEntry(p.panel_id, this.wj_info.batch, barnacle,
                molluscs, tubeworms, bryozoans, hydroids, anenomes, tunicates, amphipods, sponges, aglae,
                unknown, incipient, biofilm);
            WJDataEntry data = new WJDataEntry(data_info, this.wj_info.psi);
            this.Frame.Navigate(typeof(WJDataPage), data);
        }
    }
}
