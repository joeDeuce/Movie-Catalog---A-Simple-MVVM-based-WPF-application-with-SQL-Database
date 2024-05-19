using System.Windows;
using System.Windows.Controls;

namespace CountTime
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private Frame Frame;
        CountTimeViewModel MovieVM;

        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(Frame frame1, CountTimeViewModel movieVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.MovieVM = movieVM;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new Search(this.Frame, this.MovieVM));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new AddPage(this.Frame, this.MovieVM));

        }
    }
}
