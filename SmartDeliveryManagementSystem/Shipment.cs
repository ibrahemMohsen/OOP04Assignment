using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    abstract class Shipment
    {
        private string _trackingCode;
        private string _description;
        private double _weight;
        private decimal _deliveryFee;
        public DeliveryAddress Destination { get; set; }

        public string TrackingCode
        {
            get => _trackingCode;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _trackingCode = value;
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _description = value;
                }
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value > 0)
                {
                    _weight = value;
                }
            }
        }
        public decimal DeliveryFee
        {
            get => _deliveryFee;
            private set
            {
                if (value > 0)
                {
                    _deliveryFee = value;
                }
            }
        }
        // I made it virtual in the last task because I forgot we didn't cover the topic yet.
        public virtual decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (decimal)Weight * 5;
            }
        }
        public Shipment(string trackingCode) :
            this(trackingCode, "Unknown", 1, 50m, default)

        {
        }
        public Shipment(
                string trackingCode,
                string description,
                double weight,
                decimal deliveryFee,
                DeliveryAddress destination
            )
        {
            _trackingCode = "Unknown";
            _description = "Unknown";
            _weight = 1;
            _deliveryFee = 50m;

            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }


        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        public void UpdateWeight(double weight)
        {
            Weight = weight;
        }
        public void UpdateWeight(double weight, double extraPackagingWeight)
        {
            Weight = weight + extraPackagingWeight;
        }
        public virtual void PrintShipment()
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
