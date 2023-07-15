namespace TestingProject.DTO.Admin
{
    public class AdminDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public string password { get; set; }

        public int? role_Id { get; set; }

        public string role_Name { get; set; }

    }
}
