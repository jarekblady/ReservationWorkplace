using System.ComponentModel.DataAnnotations;
using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Models
{
    public class WorkplaceViewModel
    {
        public List<WorkplaceDto> Workplaces { get; set; }
        public WorkplaceDto Workplace { get; set; }
    }
}
