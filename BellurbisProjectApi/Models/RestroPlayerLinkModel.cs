using System.ComponentModel.DataAnnotations;

namespace BellurbisProjectApi.Models
{
    public class RestroPlayerLinkModel
    {
        [Key]
        public int Id { get; set; }
        public int ?RestaurantId { get; set; }
        public int ?PlayerId { get; set; }
        public bool Fav { get; set; }

    }
}
