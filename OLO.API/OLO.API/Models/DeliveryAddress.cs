using System.Runtime.Serialization;

namespace OLO.API.Models
{
    public class DeliveryAddress
    {
        [DataMember(Name = "address1")]
        public string Address { get; set; }

        [DataMember(Name = "address2")]
        public string Address2 { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "zip_code")]
        public string ZipCode { get; set; }
    }
}
