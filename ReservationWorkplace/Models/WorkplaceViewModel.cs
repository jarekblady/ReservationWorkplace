﻿using System.ComponentModel.DataAnnotations;

namespace ReservationWorkplace.Models
{
    public class WorkplaceViewModel
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }

        public string WorkplaceName { get; set; }
        public ICollection<ReservationViewModel> Reservations { get; set; }
        public ICollection<EquipmentForWorkplaceViewModel> EquipmentForWorkplaces { get; set; }
    }
}
