using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public BatchHome()
        {
            this.InitializeComponent();

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
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
        //    this.Frame.Navigate(typeof(AddBatch), name.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
