using System;
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
        public string batch_name;
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
                this.batch_name = e.Parameter.ToString();
                // FieldDayTitle.Text = $"{e.Parameter.ToString()} {field_date} Field Day";
            }
            else
            {
                // batch_name text box is blank
                // FieldDayTitle.Text = "Invalid Field Day";
            }
            base.OnNavigatedTo(e);
        }
    }
}
