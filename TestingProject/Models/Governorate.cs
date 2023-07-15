using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingProject.Models
{
    public class Governorate
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,25}$", ErrorMessage = "Name Must Be Between 3 to 25 charchters")]
        public string Name { get; set; }
        public bool Available { get; set; } = true;

        [ForeignKey("Branch")]
        public int? Branch_Id { get; set; }
        public virtual Branch? Branch { get; set; }

        public virtual List<City>? Cities { get; set; }
        public virtual List<Order>? Orders { get; set; }

    }
}
