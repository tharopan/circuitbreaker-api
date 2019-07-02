using System.Runtime.Serialization;

namespace OLO.API.Models
{
    [DataContract]
    public class FulfillmentDetails
    {
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "car_type")]
        public string CarType { get; set; }

        [DataMember(Name = "car_color")]
        public string CarColor { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "delivery_address")]
        public DeliveryAddress DeliveryAddress { get; set; }

        [DataMember(Name = "car_description")]
        public string CarDescription { get; set; }

        [DataMember(Name = "is_pickup_only")]
        public bool IsPickUpOnly { get; set; }
    }
}
