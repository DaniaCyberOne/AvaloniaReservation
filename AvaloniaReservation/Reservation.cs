using System.Collections.Generic;
using System;
using System.Linq;

namespace MVCPatternAvalonia.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
    }

    public class ReservationModel
    {
        private List<Reservation> reservations = new List<Reservation>();

        public List<Reservation> GetReservations()
        {
            return reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public void RemoveReservation(int id)
        {
            reservations.RemoveAll(r => r.Id == id);
        }

        public void EditReservation(int id, string name, DateTime date, int numberOfPeople)
        {
            var reservation = reservations.FirstOrDefault(r => r.Id == id);
            if (reservation != null)
            {
                reservation.Name = name;
                reservation.Date = date;
                reservation.NumberOfPeople = numberOfPeople;
            }
        }
    }
}

