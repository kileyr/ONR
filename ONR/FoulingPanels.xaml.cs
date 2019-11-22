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
    public class PanelFouling
    {
        public string panel_id;
        public PanelFouling(string id)
        { 
            this.panel_id = id;
        }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FoulingPanels : Page
    {
        public string batch_name;
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
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                this.batch_name = e.Parameter.ToString();
                foulingTitle.Text = $"{e.Parameter.ToString()} {field_date} - Fouling Panels";
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
    }
}
