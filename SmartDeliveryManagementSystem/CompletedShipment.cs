using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal sealed class CompletedShipment: Shipment
    {
        public CompletedShipment(string trackingCode): base(trackingCode)
        {

        }
        public CompletedShipment(
                string trackingCode,
                string description,
                double weight,
                decimal deliveryFee,
                DeliveryAddress destination
            ): base(trackingCode, description, weight, deliveryFee, destination)
        {

        }

        public override decimal EstimatedCost {
            get
            {
                return DeliveryFee + (decimal)Weight * 5;
            }
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Ready";
        }

        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Decription: {Description}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"DeliveryAddress: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
        }
    }
}
