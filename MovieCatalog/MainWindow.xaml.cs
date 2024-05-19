using System.Windows;
using System.Windows.Controls;

namespace CountTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CountTimeViewModel MovieVM { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MovieVM = new CountTimeViewModel();
            Frame.Navigate(new HomePage(Frame,MovieVM));
        }
    }
}
