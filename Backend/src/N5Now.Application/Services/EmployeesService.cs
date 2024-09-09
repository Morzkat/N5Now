using AutoMapper;
using N5Now.Domain;
using N5Now.Domain.DTOs;
using N5Now.Domain.Entities;
using N5Now.Domain.Services;
using N5Now.Domain.Common.Exceptions;

namespace N5Now.Application.Services
{
    public class EmployeesService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> AddEmployee(Employee employee)
        {
            var exists = await _unitOfWork.EmployeeRepository.ExistAsync(x => x.Id == employee.Id);
            if (exists)
                throw new ConflictException("The employee already exist.");

            await _unitOfWork.EmployeeRepository.AddAsync(employee);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var exists = await _unitOfWork.EmployeeRepository.ExistAsync(x => x.Id == employeeId);
            if (!exists)
                throw new NotFoundException("The employee doesn't exist.");

            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(employeeId);
            await _unitOfWork.EmployeeRepository.DeleteAsync(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task<EmployeeDto> GetEmployee(int employeeId)
        {
            var exists = await _unitOfWork.EmployeeRepository.ExistAsync(x => x.Id == employeeId);
            if (!exists)
                throw new NotFoundException("The employee doesn't exist.");

            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(employeeId);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return employeeDto;
        }

        public async Task<EmployeeDto> UpdateEmployee(Employee employee)
        {
            var exists = await _unitOfWork.EmployeeRepository.ExistAsync(x => x.Id == employee.Id);
            if (!exists)
                throw new ConflictException("The employee doesn't exist.");

            await _unitOfWork.EmployeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
