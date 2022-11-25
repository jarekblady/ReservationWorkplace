namespace ReservationWorkplace.DataTransferObjects
{
    public class EquipmentForWorkplaceDto
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int WorkplaceId { get; set; }
        public WorkplaceDto Workplace { get; set; }

        public int EquipmentId { get; set; }
        public EquipmentDto Equipment { get; set; }
    }
}
