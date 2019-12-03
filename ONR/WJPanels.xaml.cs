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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ONR
{
    public class PanelWJ
    {
        public string panel_id;
        public PanelWJ(string id)
        {
            this.panel_id = id;
        }
    }

    public class WJDataEntry
    {
        public string panel_id;
        public string batch_name;
        public int psi;
        public WJDataEntry(string id, string batch)
        { 
            this.panel_id = id;
            this.batch_name = batch;
            this.psi = 0;
        }

        public void next_psi()
        {
            if(this.psi < 120)
            {
                this.psi += 40;
            }
            else if(this.psi == 120)
            {
                this.psi = 180;
            }
            else if(this.psi == 180)
            {
                this.psi = 240;
            }
        }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WJPanels : Page
    {
        public string batch_name;
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
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                this.batch_name = e.Parameter.ToString();
                WJTitle.Text = $"{e.Parameter.ToString()} {field_date} - Water Jet Panels";
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
            this.Frame.Navigate(typeof(FoulingPanels), this.batch_name);
        }

        private void to_waterjet(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To waterjet");
            this.Frame.Navigate(typeof(WJPanels), this.batch_name);
        }

        private void to_push(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To push");
            this.Frame.Navigate(typeof(PushPanels), this.batch_name);
        }

        private void select_WJPanel(object sender, SelectionChangedEventArgs e)
        {
            PanelWJ panel = _WJPanels_.SelectedItem as PanelWJ;
            WJDataEntry data = new WJDataEntry(panel.panel_id, this.batch_name);
            this.Frame.Navigate(typeof(WJDataPage), data);
        }
    }
}
