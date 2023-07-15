namespace TestingProject.DTO.Delivery
{
    public class DeliveryDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public bool available { get; set; }
        public string password { get; set; }
        public string branch_name { get; set; }

        public string role_Name { get; set; }

        public int? branch_Id { get; set; }

        public double companyPercentage { get; set; }
    }
}
