namespace ReservationWorkplace.DataTransferObjects
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }

        public int WorkplaceId { get; set; }
        public WorkplaceDto Workplace { get; set; }
    }
}
