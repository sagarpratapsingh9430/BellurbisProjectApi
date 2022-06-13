using System.ComponentModel.DataAnnotations;

namespace BellurbisProjectApi.Models
{
    public class PlayerModel
    {
        [Key]
        public int PlayerId { get; set; }
        public string? Name { get; set; }
        public string? DOB { get; set; }
        public string? PrimaryAddress { get; set; }
        public string? AlternateAddress { get; set; }
        public string? OfficeAddress { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public string? DriversLicense { get; set; }
        public string? Passport { get; set; }
        public string? StreetNumber { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Postal { get; set; }
        public string? Country { get; set; }

        public static implicit operator PlayerModel(List<PlayerModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
