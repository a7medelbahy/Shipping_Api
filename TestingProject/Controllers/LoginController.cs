using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestingProject.DTO.Login;
using TestingProject.Models;
using TestingProject.Repository.AdminRepo;
using TestingProject.Repository.CustomerRepo;
using TestingProject.Repository.DeliveryRepo;
using TestingProject.Repository.EmployeeRepo;


namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IAdminRepositrory AdminRebo;
        IEmployeeRepository EmpRebo;
        ICustomerRepository CustomerRebo;
        IDeliveryRepository DeliveryRebo;

        public LoginController(IAdminRepositrory _admin,IEmployeeRepository emp,ICustomerRepository cust,IDeliveryRepository delv)
        {
            this.AdminRebo = _admin;
            this.EmpRebo = emp;
            this.CustomerRebo=cust;
            this.DeliveryRebo = delv;
        }

        [HttpPost]
        public IActionResult GetAll(UserDataDTO _AllDto)
        {
            List<Employee> emp = EmpRebo.getAll();
            List<Delivery> deliveries = DeliveryRebo.GetAllDeleveries();
            List<Customer> customer = CustomerRebo.GetAllCustomer();
            List<Admin> admins = AdminRebo.GetAdmin();
            List<UserDataSentDTO> ListAll = new List<UserDataSentDTO>();
            for (int i = 0; i < emp.Count; i++)
            {
                UserDataSentDTO allDTO = new UserDataSentDTO()
                {
                    email = emp[i].Email,
                    password = emp[i].Password,
                    id = emp[i].Id,
                    role_Name = emp[i].Role.Name,
                    role_Id = emp[i].Role_Id,
                    branch_Id = emp[i].Branch_Id,
                    name = emp[i].Name,
                    available = emp[i].Available,
                };
                ListAll.Add(allDTO);
            }

            for (int i = 0; i < deliveries.Count; i++)
            {
                UserDataSentDTO allDTO = new UserDataSentDTO()
                {
                    email = deliveries[i].Email,
                    password = deliveries[i].Password,

                    id = deliveries[i].Id,
                    role_Name = deliveries[i].Role.Name,
                    role_Id = deliveries[i].Role_Id,
                    branch_Id = deliveries[i].Branch_Id,
                    name = deliveries[i].Name,
                    available = deliveries[i].Available
                };
                ListAll.Add(allDTO);
            }

            for (int i = 0; i < customer.Count; i++)
            {
                UserDataSentDTO allDTO = new UserDataSentDTO()
                {
                    email = customer[i].Email,
                    password = customer[i].Password,
                    id = customer[i].Id,
                    role_Name = customer[i].Role.Name,
                    role_Id = customer[i].Role_Id,
                    branch_Id = customer[i].Branch_Id,
                    name = customer[i].Name,
                    available = customer[i].Available
                };
                ListAll.Add(allDTO);
            }

            for (int i = 0; i < admins.Count; i++)
            {
                UserDataSentDTO allDTO = new UserDataSentDTO()
                {
                    email = admins[i].Email,
                    password = admins[i].Password,
                    role_Id = admins[i].Role_Id,
                    id = admins[i].Id,
                    role_Name = admins[i].Role.Name,
                    branch_Id = null,
                    name = admins[i].Name,
                    available=true
                };
                ListAll.Add(allDTO);
            }

            for (int i = 0; i < ListAll.Count; i++)
            {
                if (ListAll[i].email == _AllDto.email) {
                    if (ListAll[i].available == true) {
                        if (ListAll[i].password == _AllDto.password) {
                            #region define claims
                            List<Claim> UserDataDTO = new List<Claim>();
                            UserDataDTO.Add(new Claim("email", _AllDto.email));
                            UserDataDTO.Add(new Claim("password", _AllDto.password));
                            UserDataDTO.Add(new Claim(ClaimTypes.Role, ListAll[i].role_Name));
                            #endregion

                            #region secret key
                            string key = "Our Final Project this is developers team";
                            var secertKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                            #endregion

                            #region create token
                            var signcer = new SigningCredentials(secertKey, SecurityAlgorithms.HmacSha256);
                            var token = new JwtSecurityToken(

                                claims: UserDataDTO,
                                signingCredentials: signcer,
                                expires: DateTime.Now.AddDays(1));

                            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
                            #endregion
                            UserDataSentDTO nEWDTO = new UserDataSentDTO()
                            {
                                id = ListAll[i].id,
                                email = ListAll[i].email,
                                name = ListAll[i].name,
                                branch_Id = ListAll[i].branch_Id,
                                role_Name = ListAll[i].role_Name,
                                role_Id = ListAll[i].role_Id,
                                token = stringToken
                            };

                            return Ok(nEWDTO);

                        }
                        else {
                            MessDTO nEWDTO = new MessDTO();
                            nEWDTO.mess = "Incorrect Password";
                            return Ok(nEWDTO);
                        }
                    }
                    else {
                        MessDTO nEWDTO = new MessDTO();
                        nEWDTO.mess = "Your Account Is Deactivaed, Connect Admin";
                        return Ok(nEWDTO);
                    }
                }

            }
            MessDTO nEWDT = new MessDTO();
            nEWDT.mess = "E-Mail Not Found";
            return Ok(nEWDT);
        }
    }
}
