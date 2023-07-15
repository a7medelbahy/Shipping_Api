using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestingProject.DTO.Governroate
{
    public class GovernroateAddDTO
    {
        public int id { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,25}$", ErrorMessage = "Name Must Be Between 3 to 25 charchters")]
        public string name { get; set; }

        [DefaultValue(true)]
        public bool available { get; set; } = true;
        public int branch_Id { get; set; }
    }
}
