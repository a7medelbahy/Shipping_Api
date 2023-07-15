
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestingProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{5,25}$", ErrorMessage = "Name Must Be Between 5 to 25 charchters")]
        public string Client_Name { get; set; }

        [RegularExpression(@"[a-zA-Z0-9]{1,20}@[a-zA-Z]{1,7}.com", ErrorMessage = "Enter valid E-Mail Address")]
        public string Client_Email { get; set; }

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Enter Valid Phone Number")]
        public string Client_Phone { get; set; }


        [RegularExpression(@"^[a-zA-Z_ ]{3,25}$", ErrorMessage = "Enter Valid Village Name")]
        public string? Client_Village { get; set; }

        public string Order_Type { get; set; }

        public string Charge_Type { get; set; }

        public string Payment_Type { get; set; }

        [DefaultValue("new")]
        public string Status { get; set; }

        public DateTime Order_Date { get; set; }

        public double Total_Weight { get; set; }

        public double Total_Price { get; set; }

        [ForeignKey("Customer")]
        public int? Customer_Id { get; set; }
        public virtual Customer? Customer { get; set; }

        [ForeignKey("Delivery")]
        public int? Delivery_Id { get; set; }
        public virtual Delivery? Delivery { get; set; }

        [ForeignKey("Branch")]
        public int? Branch_Id { get; set; }
        public virtual Branch? Branch { get; set; }

        [ForeignKey("Governorate")]
        public int? Governorate_Id { get; set; }
        public virtual Governorate? Governorate { get; set; }

        [ForeignKey("City")]
        public int? City_Id { get; set; }
        public virtual City? City { get; set; }

        public virtual List<Product>? Products { get; set; }
    }
}
