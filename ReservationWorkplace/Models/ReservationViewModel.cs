namespace ReservationWorkplace.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int EmployeeId { get; set; }
        public int WorkplaceId { get; set; }
        /*
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }
        */
    }
}
