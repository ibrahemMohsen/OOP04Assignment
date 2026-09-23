using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        private decimal _extraFee;
        public decimal ExtraFee
        {
            get
            {
                return _extraFee;
            }
            set
            {
                if (value > 0)
                {
                    _extraFee = value;
                }
            }
        }
        // I already call the base class constructor from the last task
        public ExpressShipment(string TrackingCode, decimal extraFee) : base(TrackingCode)
        {
            ExtraFee = extraFee;
        }
        public ExpressShipment(
                string trackingCode,
                string description,
                double weight,
                decimal deliveryFee,
                DeliveryAddress destination,
                decimal extraFee
            ) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        // Already implemented in the last Assignemnt
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (decimal)(Weight * 5) + ExtraFee;
            }
        }
        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Out for delivery";
        }
        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Decription: {Description}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"DeliveryAddress: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            Console.WriteLine($"Extra Fee: {ExtraFee}");
        }

        public decimal CalculateInsurance()
        {
            return 0.08m * EstimatedCost;
        }
    }
}
