using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal class DeliveryReport
    {
        public void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }
        public void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine(shipment.CalculateInsurance());
        }
    }
}
