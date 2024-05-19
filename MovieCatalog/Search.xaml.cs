using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CountTime
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        readonly CountTimeViewModel MovieVM;
        readonly Frame Frame;

        public Search()
        {
            InitializeComponent();
        }

        public Search(Frame frame, CountTimeViewModel movieVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.MovieVM = movieVM;

            this.Loaded += SearchPage_Loaded;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;

            Search_Click(this, null);
        }

        private void SearchPage_Loaded(object sender, RoutedEventArgs e)
        {
            SearchBox.Focusable = true;
            Keyboard.Focus(SearchBox);
        }

        /*
         * Function: Event Handler for Search Button
         */
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "")
            {
                WarningSearchLabel.Visibility = Visibility.Visible;
                //return;
            }

            WarningSearchLabel.Visibility = Visibility.Hidden;
            ////gridTable.DataContext = MovieVM.getActive();
            //gridTable.ItemsSource = MovieVM.getActive();
            GridTable.ItemsSource = MovieVM.GetActive();
            ////gridTable.Columns[0].Visibility = Visibility.Hidden;        // Hides the first column i.e. ID

            if (GridTable.SelectedCells.Count == 0)         // Disanle the Edit and Delete Button if no row selected
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
            }
            else
            {
                EditBtn.IsEnabled = true;
                DelBtn.IsEnabled = true;
            }
        }

        /*
         * Function: Event Handler for Search Box GotFocus
         * Removes text from Search Box
         */
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            SearchBox.FontStretch = FontStretches.Normal;
            SearchBox.FontStyle = FontStyles.Normal;
            SearchBox.Foreground = Brushes.Black;
        }

        /*
         * Function: Event Handler for Delete Button
         * Delete the Selected Record from Database
         */
        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentRoster movie = (CurrentRoster) GridTable.SelectedItem;
            MovieVM.DeleteRecordFromRepo(movie.GDCNum);
            GridTable.DataContext = MovieVM.GetActive();     // Updating the DataTable
            GridTable.Columns[0].Visibility = Visibility.Hidden;
        }

        /*
         * Function: Event Hanlder for Edit Button
         */
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentRoster tempMovie = (CurrentRoster) GridTable.SelectedItem;
            Frame.Navigate(new EditPage(Frame, MovieVM, tempMovie));
        }

        private void GridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridTable.SelectedCells.Count == 0)
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
                return;
            }
            EditBtn.IsEnabled = true;
            DelBtn.IsEnabled = true;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new HomePage(Frame, MovieVM));
        }
    }
}
