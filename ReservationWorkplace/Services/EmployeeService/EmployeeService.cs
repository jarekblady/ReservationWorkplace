using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Repositories.EmployeeRepository;

namespace ReservationWorkplace.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
    

        public List<EmployeeDto> GetAllEmployee()
        {
            var employees = _employeeRepository.EmployeeGetAll();
            var result = _mapper.Map<List<EmployeeDto>>(employees);
            return result;
        }

        public EmployeeDto GetByIdEmployee(int id)
        {
            var employee = _employeeRepository.EmployeeGetById(id);
            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }


        public void CreateEmployee(EmployeeDto dto)
        {
            var employee = new Employee()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
            _employeeRepository.CreateEmployee(employee);
        }

        public void UpdateEmployee(EmployeeDto dto)
        {
            var employee = new Employee()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
            _employeeRepository.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeRepository.EmployeeGetById(id);
            _employeeRepository.DeleteEmployee(employee);
        }


    }
}
