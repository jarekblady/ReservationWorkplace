﻿namespace ReservationWorkplace.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
