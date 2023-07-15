namespace TestingProject.DTO.Customer
{
    public class CustomerDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        public string store_Name { get; set; }

        public double special_Discount_Perc { get; set; }

        public double refused_Order_Perc { get; set; }

        public bool available { get; set; }

        public string role_Name { get; set; }
        public string branch { get; set; }

        public int? branch_Id { get; set; }
    }
}
