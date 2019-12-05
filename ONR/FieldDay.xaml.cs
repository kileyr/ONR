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
     *  Field day page - before recording a field day entry must be made in the foulding field day 
     *  and water jet field data tables, this page collects the information needed to make these entries.
     *  This page is navigated to with a Batch object with the batch name and id. It is navigated to after 
     *  the user chooses to record for a batch but only after checking to see if a field day already exists for it
     *  and navigate to it if one does not. 
     */
    public sealed partial class FieldDay : Page
    {
        public Batch selected_batch;
        public FieldDay()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // write field day title
            string field_date = DateTime.Today.ToString("MM.dd.yyyy");
            FieldDayTitle.Text = $"Create New Field Day - {field_date}";
            this.selected_batch = null;
            if (e.Parameter != null)
            {
                // set contents of batch_name text box
                this.selected_batch = (Batch)e.Parameter;
                batch_box.Text = this.selected_batch.batch_name;
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
            /* TODO:
             * save field day to both waterjet and fouling field day tables
             */
            Debug.WriteLine("Saving...");
            string batch = batch_box.Text;
            if(this.selected_batch == null)
            {
                /* TODO:
                 *  if batch is not chosen from the batch list, perfrom query 
                 *  to get id and date of batch
                 */
                this.selected_batch = new Batch(batch, "temp data");
            }
            if(!string.IsNullOrWhiteSpace(batch))
            {
                this.Frame.Navigate(typeof(RecordHome), this.selected_batch);
            }    
        }

        private void save(object sender, RoutedEventArgs e)
        {
            /* TODO:
             * Create field day in waterjet and fouling tables
             */
            this.Frame.Navigate(typeof(BatchHome));
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
