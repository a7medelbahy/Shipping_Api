using System.ComponentModel;
using TestingProject.Models;

namespace TestingProject.DTO.Order
{
    public class OrderAddDtocs
    {
        public int id { get; set; }

        public string client_Name { get; set; }
        public string client_Email { get; set; }
        public string client_Phone { get; set; }

        public string client_Village { get; set; }

        public string order_Type { get; set; }

        public string charge_Type { get; set; }

        public string payment_Type { get; set; }

        [DefaultValue("new")]
        public string status { get; set; }

        public DateTime order_Date { get; set; }

        public double total_Weight { get; set; }

        public double total_Price { get; set; }

        public int? customer_Id { get; set; }

        public int? delivery_Id { get; set; }

        public int branch_Id { get; set; }
        public int governorate_Id { get; set; }
        public int city_Id { get; set; }

        public List<Product> products { get; set; }

    }
}
