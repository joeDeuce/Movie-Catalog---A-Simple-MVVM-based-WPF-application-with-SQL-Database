using System;
using System.Windows;
using System.Windows.Controls;

namespace CountTime
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private Frame Frame;
        private CountTimeViewModel CountVM;
        private CurrentRoster CurRoster;

        public EditPage()
        {
            InitializeComponent();
        }

        public EditPage(Frame frame, CountTimeViewModel CountTimeVM, CurrentRoster CurrentRoster)
        {
            InitializeComponent();
            this.Frame = frame;
            this.CountVM = CountTimeVM;
            this.CurRoster = CurrentRoster;
                                                            // Loading Record into TextBoxes
            this.Title_TBox.Text = CurrentRoster.GDCNum.ToString();
            this.Genre_TBox.Text = CurrentRoster.FirstName;
            this.duration_TBox.Text = CurrentRoster.LastUpdate.ToString();
            this.ReleaseYear_TBox.Text = CurrentRoster.LastName;
            this.UpdateBtn.IsEnabled = false;           // Diable the update button
        }

        /*
         * Function: Event Handler for Update Button
         * Updates the record in Collection
         */
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentRoster tempRoster = new CurrentRoster();
            tempRoster.GDCNum = CurRoster.GDCNum;
            tempRoster.FirstName = Title_TBox.Text;
            tempRoster.FirstName = Genre_TBox.Text;
            tempRoster.LastUpdate = DateTime.Parse(duration_TBox.Text.ToString());
            tempRoster.LastName = ReleaseYear_TBox.Text.ToString();
            CountVM.UpdateRecordInRepo(tempRoster);
            MessageBox.Show("The record is updated", "Update");
        }

        /*
         * Function: Event Handler for Back Button
         * Navigates to previous container, in this case Page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        /* 
         * Function: Event Handler for TextBox
         * Enable update button if text is edited in Box
         */
        private void LostFocus_TextBox(object sender, RoutedEventArgs e)
        {
            if (!(this.CurRoster.GDCNum.Equals(this.Title_TBox.Text)
                && this.CurRoster.FirstName.Equals(this.Genre_TBox.Text)
                && this.CurRoster.GDCNum.Equals(int.Parse(this.duration_TBox.Text))
                && this.CurRoster.GDCNum.Equals(int.Parse(this.ReleaseYear_TBox.Text))))
            {
                UpdateBtn.IsEnabled = true;
            }
        }
    }
}
