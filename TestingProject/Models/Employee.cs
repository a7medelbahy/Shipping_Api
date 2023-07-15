using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingProject.Models
{
    public class Employee
    {

        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{5,25}$",ErrorMessage = "Name Must Be Between 5 to 25 charchters")]
        public string Name { get; set; }

        [RegularExpression(@"[a-zA-Z0-9]{1,20}@[a-zA-Z]{1,7}.com", ErrorMessage = "Enter valid E-Mail Address")]
        public string Email { get; set; }

        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Enter Valid Phone Number")]
        public string Phone { get; set; }

        [Range(20,60)]
        public int Age { get; set; }

        [MinLength(5)]
        [MaxLength(25)]
        public string Address { get; set; }

        [DefaultValue(true)]
        public bool Available { get; set; }

        [ForeignKey("Role")]
        [DefaultValue(2)]

        public int? Role_Id { get; set; }
        public virtual Role? Role { get; set; }

        [ForeignKey("Branch")]
        public int? Branch_Id { get; set; }

        public virtual Branch? Branch { get; set; }
    }
}
