﻿namespace ReservationWorkplace.Entities
{
    public class Workplace
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }
    }
}
