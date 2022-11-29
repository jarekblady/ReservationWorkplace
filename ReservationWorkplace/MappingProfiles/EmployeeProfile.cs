using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(m => m.FullName, c => c.MapFrom(s => s.FirstName + " " + s.LastName));
            CreateMap<EmployeeDto, Employee>();

        }
    }
}
