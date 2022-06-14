using System.ComponentModel.DataAnnotations;

namespace BellurbisProjectApi.Models
{
    public class RestaurantModel
    {
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string HoursOfOperation { get; set; }

       
    }
}
