using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingProject.Models
{
    public class City
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,25}$", ErrorMessage = "Name Must Be Between 3 to 25 charchters")]
        public string Name { get; set; }
        
        public double Charge_Regular { get; set; }

        public double Charge_24Hour { get; set; }

        public double Charge_15Days { get; set; }

        public double Charge_89Days { get; set; }

        public bool Available { get; set; } = true;

        [ForeignKey("Governorate")]
        public int? Governorate_Id { get; set; }
        public virtual Governorate? Governorate { get; set; }
        public virtual List<Order>? Orders { get; set; }

    }
}
