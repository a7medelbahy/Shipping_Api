using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestingProject.DTO.Employee;
using TestingProject.Models;
using TestingProject.Repository.EmployeeRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeRepository employeeRepo;
        public EmployeesController(IEmployeeRepository _empRepo)
        {
            this.employeeRepo = _empRepo;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllEmployee()
        {
            List<Employee> emps = employeeRepo.getAll();
            if (emps == null)
            {
                return NotFound();
            }
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            for (int i = 0; i < emps.Count; i++)
            {
                EmployeeDTO empDTO = new EmployeeDTO()
                {
                    id = emps[i].Id,
                    name = emps[i].Name,
                    age = emps[i].Age,
                    address = emps[i].Address,
                    phone = emps[i].Phone,
                    email = emps[i].Email,
                    password = emps[i].Password,
                    branch_Name = emps[i].Branch.Name,
                    available = emps[i].Available,
                    role_Name = emps[i].Role.Name
                };
                employeeDTOs.Add(empDTO);
            }
            return Ok(employeeDTOs);
        }

        [HttpGet]
        [Route("Id/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Id(int id)
        {
            Employee Emp = employeeRepo.GetById(id);
            if (Emp == null)
            {
                return NotFound();
            }

            EmployeeDTO empDTO = new EmployeeDTO()
            {
                id = Emp.Id,
                name = Emp.Name,
                age = Emp.Age,
                address = Emp.Address,
                phone = Emp.Phone,
                password = Emp.Password,
                email = Emp.Email,
                branch_Name = Emp.Branch.Name,
                branch_Id = Emp.Branch_Id,
                role_Name = Emp.Role.Name,
                role_Id = Emp.Role_Id,
                available = Emp.Available
            };
            return Ok(empDTO);
        }

        [HttpGet]
        [Route("Name/{name}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetEmployeeByName(string name)
        {
            List<Employee> emps = employeeRepo.GetByName(name);
            if (emps == null)
            {
                return NotFound();
            }
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            for (int i = 0; i < emps.Count; i++)
            {
                EmployeeDTO empDTO = new EmployeeDTO()
                {
                    id = emps[i].Id,
                    name = emps[i].Name,
                    age = emps[i].Age,
                    address = emps[i].Address,
                    password = emps[i].Password,
                    email = emps[i].Email,
                    branch_Name = emps[i].Branch.Name,
                    role_Name = emps[i].Role.Name,
                    available = emps[i].Available
                };
                employeeDTOs.Add(empDTO);
            }
            return Ok(employeeDTOs);
        }

        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddEmployee(EmployeeAddEdit_DTO empDto)
        {
            if (empDto == null)
            {
                return BadRequest();
            }

            Employee emp = new Employee()
            {
                Email = empDto.email,
                Name = empDto.name,
                Address = empDto.address,
                Age = empDto.age,
                Available = empDto.available,
                Branch_Id = empDto.branch_Id,
                Role_Id = empDto.role_Id,
                Phone = empDto.phone,
                Password = empDto.password
            };

            employeeRepo.Add(emp);
            employeeRepo.Save();

            return Ok(emp);
        }

        [HttpPut]
        [Route("edit/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult editEmployee(EmployeeAddEdit_DTO empDto, int id)
        {
            if (empDto == null && !ModelState.IsValid)
            {
                return BadRequest();
            }
            Employee empl = employeeRepo.GetById(id);
            empl.Name = empDto.name;
            empl.Address = empDto.address;
            empl.Password = empDto.password;
            empl.Phone = empDto.phone;
            empl.Email = empDto.email;
            empl.Age = empDto.age;
            empl.Branch_Id = empDto.branch_Id;
            empl.Role_Id = empDto.role_Id;
            employeeRepo.Edit(empl);
            employeeRepo.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (employeeRepo.GetById(id) == null)
            {
                return BadRequest();
            }
            employeeRepo.Delete(id);
            employeeRepo.Save();
            return Ok();
        }

        [HttpPut]
        [Route("softdelete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult SoftDelete(EmployeeAddEdit_DTO EmpDto, int id)
        {
            Employee emp = employeeRepo.GetById(id);
            if (emp == null) return NotFound();
            employeeRepo.SoftDelete(emp);
            employeeRepo.Save();
            return Ok();
        }

        [HttpGet]
        [Route("Available")]
        public ActionResult GetEmployeesAvailable() {
            List<Employee> emps = employeeRepo.getAvailableEmployees();
            if (emps == null)
            {
                return NotFound();
            }
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            for (int i = 0; i < emps.Count; i++)
            {
                EmployeeDTO empDTO = new EmployeeDTO()
                {
                    id = emps[i].Id,
                    name = emps[i].Name,
                    age = emps[i].Age,
                    address = emps[i].Address,
                    phone = emps[i].Phone,
                    email = emps[i].Email,
                    password = emps[i].Password,
                    branch_Name = emps[i].Branch.Name,
                    available = emps[i].Available,
                    role_Name = emps[i].Role.Name
                };
                employeeDTOs.Add(empDTO);
            }
            return Ok(employeeDTOs);
        }
    }
}
