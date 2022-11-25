﻿namespace ReservationWorkplace.DataTransferObjects
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ReservationDto> Reservations { get; set; }
    }
}
