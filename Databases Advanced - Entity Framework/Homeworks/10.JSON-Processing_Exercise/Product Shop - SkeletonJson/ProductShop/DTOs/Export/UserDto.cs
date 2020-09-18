
namespace ProductShop.DTOs.Export
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class UserDto
    {
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public List<UserSoldProductsDto> SoldProducts { get; set; }
    }
}
