//using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestingProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
        
        public double Weight { get; set; }

        [ForeignKey("Order")]
        public int? order_Id { get; set; }

        [JsonIgnore]
        public virtual Order? Order { get; set; }
    }
}
