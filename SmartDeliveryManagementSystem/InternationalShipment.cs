using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        public string DestinationCountry
        {
            get;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    field = value;
                }
                else
                {
                    throw new Exception("DestinationCountry Cannot be null, empty, or whitespaces");
                }
            }
        }
        public decimal CustomsFee
        {
            get;
            set
            {
                if (value >= 0)
                {
                    field = value;
                }
                else
                {
                    throw new Exception("CustomsFee Cannot be negative");
                }
            }
        }

        // I already call the base class constructor from the last task
        public InternationalShipment(
            string trackingCode,
            string destinationCountry,
            decimal customsFee)
            : base(trackingCode)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public InternationalShipment(
                string trackingCode,
                string description,
                double weight,
                decimal deliveryFee,
                DeliveryAddress destination,
                string destinationCountry,
                decimal customsFee
            ) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        // Already implemented in the last Assignemnt
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (decimal)(Weight * 5) + CustomsFee;
            }
        }
        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has been delivered";
        }
        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Decription: {Description}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"DeliveryAddress: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee: {CustomsFee}");
        }
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("This is the International Shipment Customs Report");
        }

        public decimal CalculateInsurance()
        {
            return 0.12m * EstimatedCost;
        }
    }
}
