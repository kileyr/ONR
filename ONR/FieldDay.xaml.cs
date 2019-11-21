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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ONR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FieldDay : Page
    {
        public string selected_batch;
        public FieldDay()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write field day title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            FieldDayTitle.Text = $"Create New Field Day - {field_date}";
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                // set contents of batch_name text box
                batch_box.Text = e.Parameter.ToString();
                // FieldDayTitle.Text = $"{e.Parameter.ToString()} {field_date} Field Day";
            }
            base.OnNavigatedTo(e);
        }

        private void nav_to_BatchHome(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("To batch home");
            this.Frame.Navigate(typeof(BatchHome));
        }

        private void save_and_nav_to_record(object sender, RoutedEventArgs e)
        {
            // first save field day and then navigate to recording
            Debug.WriteLine("Saving...");
            string batch = batch_box.Text;
            if(!string.IsNullOrWhiteSpace(batch))
            {
                this.selected_batch = batch;
                this.Frame.Navigate(typeof(RecordHome), this.selected_batch);
            }    
        }

        /**
        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            fouling_cb.IsChecked = wj_cb.IsChecked = push_cb.IsChecked = true;
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            fouling_cb.IsChecked = wj_cb.IsChecked = push_cb.IsChecked = false;
        }

        private void handle_check(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if(cb.Name == "fouling_cb")
            {
                Debug.WriteLine("set fouling");
                // set fouling
            } 
            else if(cb.Name == "wj_cb")
            {
                Debug.WriteLine("set water jet");
                // set wj
            }
            else
            {
                Debug.WriteLine("set push");
                // set push
            }
        }

        private void handle_uncheck(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Name == "fouling_cb")
            {
                Debug.WriteLine("unset fouling");
                // unset fouling
            }
            else if (cb.Name == "wj_cb")
            {
                Debug.WriteLine("unset water jet");
                // unset wj
            }
            else
            {
                Debug.WriteLine("unset push");
                // unset push
            }

            if(select_all.IsChecked == true)
            {
                select_all.Unchecked -= SelectAll_Unchecked;
                select_all.IsChecked = false;
                select_all.Unchecked += SelectAll_Unchecked;
            }
        } **/
    }
}
