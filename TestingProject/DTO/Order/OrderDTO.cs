using TestingProject.Models;

namespace TestingProject.DTO.Order
{
    public class OrderDTO
    {
        public int id { get; set; }
        public string client_Name { get; set; }

        public string client_Phone { get; set; }

        public string client_Email { get; set; }

        public string? client_Village { get; set; }

        public string order_Type { get; set; }

        public string charge_Type { get; set; }

        public string payment_Type { get; set; }

        public string status { get; set; }

        public DateTime order_Date { get; set; }

        public double total_Weight { get; set; }

        public double total_Price { get; set; }

        public string customer_Name { get; set; }
        public string customer_Phone { get; set; }

        public string branch_Name { get; set; }

        public int branch_Id { get; set; }
        public string governorate_Name { get; set; }

        public int governorate_Id { get; set; }

        public string city_Name { get; set; }

        public int city_Id { get; set; }

        public string? delivery_Name { get; set; }

        public string? delivery_Phone { get; set; }

        public List<Product>? products { get; set; }
    }
}
