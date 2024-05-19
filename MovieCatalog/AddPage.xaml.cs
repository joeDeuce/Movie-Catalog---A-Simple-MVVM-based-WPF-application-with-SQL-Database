using System.Windows;
using System.Windows.Controls;

namespace CountTime
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        CountTimeViewModel MovieVM;
        Frame Frame;
        public AddPage()
        {
            InitializeComponent();
        }

        public AddPage(Frame frame1, CountTimeViewModel movieVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.MovieVM = movieVM;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            duration_TBox.Text = "";
            duration_TBox.FontStyle = FontStyles.Normal;
            duration_TBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void Title_TBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Title_TBox.Text = "";
            Title_TBox.FontStyle = FontStyles.Normal;
            Title_TBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void Genre_TBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Genre_TBox.Text = "";
            Genre_TBox.FontStyle = FontStyles.Normal;
            Genre_TBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void ReleaseYear_TBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ReleaseYear_TBox.Text = "";
            ReleaseYear_TBox.FontStyle = FontStyles.Normal;
            ReleaseYear_TBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for Add Button
         * Adds the entered data to the Collection and Database
         */
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentRoster currentRoster = new CurrentRoster();
            currentRoster.GDCNum = int.Parse(Title_TBox.Text);
            currentRoster.LastName = ReleaseYear_TBox.Text;
            currentRoster.FirstName = Genre_TBox.Text;
            currentRoster.Dorm = int.Parse(duration_TBox.Text);

            MovieVM.AddRecordToRepo(currentRoster);
        }

        /*
         * Function: Event Handler for back button
         * Navigates to back page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }
    }
}
