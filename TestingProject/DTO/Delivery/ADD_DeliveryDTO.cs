using System.ComponentModel;
using TestingProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingProject.DTO.Delivery
{
    public class ADD_DeliveryDTO
    {
        [RegularExpression(@"^[a-zA-Z_ ]{5,25}$", ErrorMessage = "Name Must Be Between 5 to 25 charchters")]
        public string name { get; set; }

        [RegularExpression(@"[a-zA-Z0-9]{1,20}@[a-zA-Z]{1,7}.com", ErrorMessage = "Enter valid E-Mail Address")]
        public string email { get; set; }

        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Enter Valid Phone Number")]
        public string phone { get; set; }

        [MinLength(5)]
        [MaxLength(25)]
        public string address { get; set; }

        [Range(0, 100)]
        public double company_Perc { get; set; }

        [DefaultValue(true)]
        public bool available { get; set; }

        [DefaultValue(4)]
        public int role_Id { get; set; }

        public int? branch_Id { get; set; }
    }
}
