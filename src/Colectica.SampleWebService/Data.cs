using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colectica.SampleWebService.Data
{
    public class ItemRequest
    {
        public string ItemIdentifier { get; set; }
    }

    public partial class BasketRequest
    {
        [JsonProperty("Citation", NullValueHandling = NullValueHandling.Ignore)]
        public Citation Citation { get; set; }

        [JsonProperty("ItemIdentifers", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ItemIdentifers { get; set; }
    }

    public partial class Citation
    {
        [JsonProperty("Title")]
        public Title Title { get; set; }
    }

    public partial class Title
    {
        [JsonProperty("en-US")]
        public string EnglishUS { get; set; }
    }

    public class ApiResponse
    {
        public string Message { get; set; }
        public string RedirectUrl { get; set; }
    }

}
