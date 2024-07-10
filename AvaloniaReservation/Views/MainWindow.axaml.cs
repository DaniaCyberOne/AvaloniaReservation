using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MVCPatternAvalonia.Controllers;
using MVCPatternAvalonia.Models;
using System;

namespace MVCPatternAvalonia.Views
{
    public partial class MainWindow : Window
    {
        private ReservationController controller;

        public MainWindow()
        {
            InitializeComponent();
            var model = new ReservationModel();
            controller = new ReservationController(model, this);
            controller.LoadReservations();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            NameTextBox = this.FindControl<TextBox>("NameTextBox");
            DateDatePicker = this.FindControl<DatePicker>("DateDatePicker");
            NumberOfPeopleNumericUpDown = this.FindControl<NumericUpDown>("NumberOfPeopleNumericUpDown");
            ReservationListBox = this.FindControl<ListBox>("ReservationListBox");
        }

        private void AddReservation_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox == null || DateDatePicker == null || NumberOfPeopleNumericUpDown == null)
            {
                throw new Exception("One or more input fields are not initialized.");
            }

            controller.AddReservation(NameTextBox.Text, DateDatePicker.SelectedDate.Value, (int)NumberOfPeopleNumericUpDown.Value);
            NameTextBox.Text = string.Empty;
            DateDatePicker.SelectedDate = null;
            NumberOfPeopleNumericUpDown.Value = 0;
        }
    }
}
