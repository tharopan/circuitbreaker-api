using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OLO.API.Models
{
    [DataContract]
    public class Cart
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "order_number")]
        public int OrderNumber { get; set; }

        [DataMember(Name = "valid_actions")]
        public List<string> ValidActions { get; set; } = new List<string>();

        [IgnoreDataMember]
        [DataMember(Name = "locationCode")]
        public string LocationCode { get; set; }

        [DataMember(Name = "restaurant_id")]
        public string RestaurantId { get; set; }

        [DataMember(Name = "menu_type")]
        public string MenuType { get; set; }

        [DataMember(Name = "fulfillment_date")]
        public DateTime? FulfillmentDate { get; set; }

        [DataMember(Name = "fulfillment_type")]
        public string FulfillmentType { get; set; }

        [DataMember(Name = "discount_amount")]
        public decimal DiscountAmount { get; set; }

        [DataMember(Name = "subtotal")]
        public decimal Subtotal { get; set; }

        [DataMember(Name = "grand_total")]
        public decimal GrandTotal { get; set; }

        [DataMember(Name = "tip")]
        public decimal Tip { get; set; }

        [DataMember(Name = "delivery_fee")]
        public decimal DeliveryFee { get; set; }

        [DataMember(Name = "taxes")]
        public Taxes Taxes { get; set; } = new Taxes();

        [DataMember(Name = "lead_time")]
        public int? LeadTime { get; set; }

        [DataMember(Name = "payment_attempt_failures")]
        public int? PaymentAttemptFailures { get; set; }

        [DataMember(Name = "gift_card_check_balance_attempt_failures")]
        public int GiftCardCheckBalanceAttemptFailures { get; set; }

        [DataMember(Name = "setup_complete")]
        public bool SetupComplete { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "fulfillment_details")]
        public FulfillmentDetails FulfillmentDetails { get; set; } = new FulfillmentDetails();

        //[DataMember(Name = "order_items")]
        //public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        [DataMember(Name = "accepted_payment_types")]
        public List<string> AcceptedPaymentTypes { get; set; } = new List<string>();

        //[DataMember(Name = "available_rewards")]
        //public List<Reward> AvailableRewards { get; set; }

        //[DataMember(Name = "complimentary_items")]
        //public List<ComplimentaryItem> ComplimentaryItems { get; set; }

        //[DataMember(Name = "invalid_menu_items")]
        //public List<InvalidItem> InvalidItems { get; set; } = new List<InvalidItem>();

        //[DataMember(Name = "totals")]
        //public Total Total { get; set; } = new Total();

        //[DataMember(Name = "discounts")]
        //public List<Discount> Discounts { get; set; } = new List<Discount>();

        [DataMember(Name = "loyaltyCardNumber")]
        public string LoyaltyCardNumber { get; set; }

        //[DataMember(Name = "service_time")]
        //[JsonProperty("service_time", NullValueHandling = NullValueHandling.Include)]
        //public ServiceTime ServiceTime { get; set; }

        [DataMember(Name = "isExpressLocation")]
        public bool IsExpressLocation { get; set; }

        [DataMember(Name = "isAsap")]
        public bool IsAsap { get; set; }

        [DataMember(Name = "max_productLeadtime")]
        public int MaxProductLeadTime { get; set; }
    }
}
