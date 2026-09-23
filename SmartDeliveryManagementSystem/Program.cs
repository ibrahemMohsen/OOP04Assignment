using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

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
            Console.WriteLine();
            deliveryCenter.PrintAllShipments();


            Console.WriteLine($"{standardShipment.GetTrackingStatus()}\n");
            Console.WriteLine($"{expressShipment.GetTrackingStatus()}\n");
            Console.WriteLine($"{internationalShipment.GetTrackingStatus()}\n");
            Console.WriteLine();

            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine("Standard Shipment Insurance: " + standardShipment.CalculateInsurance());
            Console.WriteLine();
            Console.WriteLine("Express Shipment Insurance: " + expressShipment.CalculateInsurance());
            Console.WriteLine();
            Console.WriteLine("International Shipment Insurance: " + internationalShipment.CalculateInsurance());
            Console.WriteLine();

            Console.WriteLine("=============================");
            Console.WriteLine();
            ITrackable[] shipments = [standardShipment, expressShipment, internationalShipment];
            deliveryCenter.PrintTrackingStatuses(shipments);

            Console.WriteLine("=============================");
            Console.WriteLine();
            IInsurable[] shipments2 = [standardShipment, expressShipment, internationalShipment];
            foreach(IInsurable shipment in shipments2)
            {
                Console.WriteLine(shipment.CalculateInsurance());
            }



        }


    }
}
