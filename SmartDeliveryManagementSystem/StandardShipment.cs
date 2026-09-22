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
        public override void PrintShipment()
        {
            base.PrintShipment();
        }
    }
}
