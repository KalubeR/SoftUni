using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProductShop.Dtos.Export
{
    public class UserDto
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [JsonProperty(PropertyName = "soldProducts")]
        public List<ProductDto> SoldProducts { get; set; }
    }
}