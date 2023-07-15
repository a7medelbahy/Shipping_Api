using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingProject.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{5,25}$", ErrorMessage = "Name Must Be Between 5 to 25 charchters")]
        public string Name { get; set; }

        [RegularExpression(@"[a-zA-Z0-9]{1,20}@[a-zA-Z]{1,7}.com", ErrorMessage = "Enter valid E-Mail Address")]
        public string Email { get; set; }

        [MinLength(8)]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [RegularExpression(@"^01[012][0-9]{8}$", ErrorMessage = "Enter Valid Phone Number")]
        public string Phone { get; set; }

        [Range(20, 60)]
        public int Age { get; set; }

        [MinLength(5)]
        [MaxLength(25)]
        public string Address { get; set; }

        [ForeignKey("Role")]
        public int? Role_Id { get; set; } = 1;
        public virtual Role? Role { get; set; }
    }
}
