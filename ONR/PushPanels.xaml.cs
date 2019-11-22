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
    public class PanelPush
    {
        public string panel_id;
        public PanelPush(string id)
        {
            this.panel_id = id;
        }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PushPanels : Page
    {
        public string batch_name;
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
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                this.batch_name = e.Parameter.ToString();
                PushTitle.Text = $"{e.Parameter.ToString()} {field_date} - Push Panels";
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
