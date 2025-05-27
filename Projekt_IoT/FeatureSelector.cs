using Microsoft.Azure.Devices.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_IoT
{
    internal class FeatureSelector
    {
        public static void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(@"      ------ MENU ------
      1 - C2D - Cloud to Device 
      2 - Device Twin
      3 - Direct Method - Send Message
      4 - Direct Method - Emergency STOP
      5 - Direct Method - Reset Errors
      6 - Increase Production Rate by 10
      7 - Decrease Production Rate by 10
      8 - Set Production Rate
      0 - Exit"
            );
        }

        public static async Task Execute(int feature, Projekt_IoT.IotHubManager manager)
        {
            switch (feature)
            {
                case 1:
                    {
                        System.Console.WriteLine("\nWrite your message text and click enter: ");
                        string messageText = System.Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Enter your Azure ID device and click enter: ");
                        string devideID = System.Console.ReadLine() ?? string.Empty;

                        await manager.SendMessage(messageText, devideID);
                        Console.WriteLine("Message sent!");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("\nEnter your Azure ID device and click enter: ");
                        string devideID = System.Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Enter your property Name:");
                        string propertyName = Console.ReadLine() ?? string.Empty;

                        var random = new Random();
                        await manager.UpdateDesiredTwin(devideID, propertyName, random.Next());
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("\nEnter your Azure ID device and click enter");
                        string devideID = System.Console.ReadLine() ?? string.Empty;
                        try
                        {
                            var result = await manager.ExecuteDeviceMethod("SendMessages", devideID);
                            Console.WriteLine($"[Controller] Method Executed with: {result}");
                        }
                        catch (DeviceNotFoundException)
                        {
                            Console.WriteLine("Device not found !");
                        }

                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("\nEnter your Azure ID device and click enter: ");
                        string devideID = System.Console.ReadLine() ?? string.Empty;

                        var result = await manager.ExecuteDeviceMethod("EmergencyStop", devideID);
                        Console.WriteLine($"[Controller] Method Executed with: {result}");
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine("\nEnter your Azure ID device and click enter: ");
                        string devideID = System.Console.ReadLine() ?? string.Empty;

                        var result = await manager.ExecuteDeviceMethod("ClearErrors", devideID);
                        Console.WriteLine($"[Controller] Method Executed with: {result}");
                    }
                    break;
                case 6:
                    {
                        Console.WriteLine("\nEnter your Azure ID device and click enter: ");
                        string devideID = System.Console.ReadLine() ?? string.Empty;

                        var result = await manager.ExecuteDeviceMethod("ChangeProdRateUP", devideID);
                        Console.WriteLine($"[Controller] Method Executed with: {result}");
                    }
                    break;
                case 7:
                    {
                        Console.WriteLine("\nEnter your Azure ID device and click enter: ");
                        string devideID = System.Console.ReadLine() ?? string.Empty;

                        var result = await manager.ExecuteDeviceMethod("ChangeProdRateDOWN", devideID);
                        Console.WriteLine($"[Controller] Method Executed with: {result}");
                    }
                    break;
                case 8:
                    {
                        Console.WriteLine("\nEnter your Azure ID device and click enter: ");
                        string deviceID = System.Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Enter property name:");
                        string propertyName = System.Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Enter a property value:");
                        string propertyValue = System.Console.ReadLine() ?? string.Empty;

                        await manager.UpdateDesiredTwin(deviceID, propertyName, propertyValue);

                    }
                    break;
                default:
                    break;
            }

        }
        internal static int ReadInput()
        {
            var keyPressed = Console.ReadKey();
            var isParsed = int.TryParse(keyPressed.KeyChar.ToString(), out int value);
            return isParsed ? value : -1;
        }


    }


}
