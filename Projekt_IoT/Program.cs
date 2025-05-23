using Microsoft.Azure.Devices.Client;
using Projekt_IoT_Device;


string deviceConnectionString = "<your_connection_string>";
using var deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString, TransportType.Mqtt);
await deviceClient.OpenAsync();
var device = new VirtualDevice(deviceClient);

await device.InitializeHandlers();
await device.UpdateTwinAsync();

Console.WriteLine($"Connection success!");

await device.SendMessages(10, 1000);

Console.WriteLine("Finished! Press Enter to close...");
Console.ReadLine();