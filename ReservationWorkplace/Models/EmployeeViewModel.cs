using System.ComponentModel.DataAnnotations;
using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Models
{
    public class EmployeeViewModel
    {
        public List<EmployeeDto> Employees { get; set; }
        public EmployeeDto Employee { get; set; }


    }
}
