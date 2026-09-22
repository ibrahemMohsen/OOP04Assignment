using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal class StandardShipment : Shipment
    {
        // I already call the base class constructor from the last task
        public StandardShipment(string TrackingCode) : base(TrackingCode)
        {

        }
        public StandardShipment(
                string trackingCode,
                string description,
                double weight,
                decimal deliveryFee,
                DeliveryAddress destination
            ) : base(trackingCode, description, weight, deliveryFee, destination)
        {

        }
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (decimal)Weight * 5;
            }
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
