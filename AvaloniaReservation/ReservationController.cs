using AvaloniaReservation.Views;
using MVCPatternAvalonia.Models;
using MVCPatternAvalonia.Views;
using System;
using System.Linq;

namespace MVCPatternAvalonia.Controllers
{
    public class ReservationController
    {
        private ReservationModel model;
        private MainWindow view;

        public ReservationController(ReservationModel model, MainWindow view)
        {
            this.model = model;
            this.view = view;
        }

        public void AddReservation(string name, DateTime date, int numberOfPeople)
        {
            var newReservation = new Reservation
            {
                Id = model.GetReservations().Count + 1,
                Name = name,
                Date = date,
                NumberOfPeople = numberOfPeople
            };
            model.AddReservation(newReservation);
            LoadReservations();
        }

        public void RemoveReservation(int id)
        {
            model.RemoveReservation(id);
            LoadReservations();
        }

        public void EditReservation(int id, string name, DateTime date, int numberOfPeople)
        {
            model.EditReservation(id, name, date, numberOfPeople);
            LoadReservations();
        }

        public void LoadReservations()
        {
            LoadReservations(view);
        }

        public void LoadReservations(MainWindow view)
        {
            if (view.ReservationListBox != null)
            {
                view.ReservationListBox.Items = model.GetReservations().Select(res => $"{res.Name} - {res.Date.ToShortDateString()} - {res.NumberOfPeople} people").ToList();
            }
        }

        internal void AddReservation(string? text, DateTimeOffset value1, int value2)
        {
            throw new NotImplementedException();
        }
    }
}
