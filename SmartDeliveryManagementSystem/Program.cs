using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver("Ahmed Mohamed");
            DeliveryCenter deliveryCenter = new DeliveryCenter("Assiut Delivery Center");
            deliveryCenter.Driver = driver;
            DeliveryAddress standardDeliveryDestination = new("Assiut", "Alsalam", 123);
            StandardShipment standardShipment = new StandardShipment("SH001", "Laptop", 3, 80m, standardDeliveryDestination);
            
            DeliveryAddress expressDeliveryDestination = new("Assiut", "Alsalam", 123);
            ExpressShipment expressShipment = new ExpressShipment("SH001", "Laptop", 2, 60m, expressDeliveryDestination, 30);
            
            DeliveryAddress internationalDeliveryDestination = new("Assiut", "Alsalam", 123);
            InternationalShipment internationalShipment = new InternationalShipment("SH001", "Telivision", 8, 120m, expressDeliveryDestination, "Germany", 100m);

            deliveryCenter.AddShipment(standardShipment);
            deliveryCenter.AddShipment(expressShipment);
            deliveryCenter.AddShipment(internationalShipment);

            deliveryCenter.PrintAllShipments();

            DeliveryHelper.PrintShipmentDetails(standardShipment);
            DeliveryHelper.PrintShipmentDetails(expressShipment);
            DeliveryHelper.PrintShipmentDetails(internationalShipment);


            Console.WriteLine($"Original Weight: {standardShipment.Weight}");
            standardShipment.UpdateWeight(10);
            Console.WriteLine($"Updated Weight: {standardShipment.Weight}");
            standardShipment.UpdateWeight(7);
            Console.WriteLine($"Updated Weight: {standardShipment.Weight}");


            Shipment[] shipments = { standardShipment, expressShipment, internationalShipment };
            foreach(Shipment shipment in shipments)
            {
                shipment.PrintShipment();
            }


        }


    }
}
