namespace TestingProject.DTO.City
{
    public class CityDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public double charge_Regular { get; set; }

        public double charge_24Hour { get; set; }

        public double charge_15Days { get; set; }

        public double charge_89Days { get; set; }

        public string governorate_Name { get; set; }

        public int? governorate_Id { get; set; }

        public string branch_Name { get; set; }

        public bool available { get; set; }


    }
}
