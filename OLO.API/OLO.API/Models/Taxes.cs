using System.Runtime.Serialization;

namespace OLO.API.Models
{
    [DataContract]
    public class Taxes
    {
        [DataMember(Name = "SalesTax")]
        public decimal SalesTax { get; set; }
    }
}
