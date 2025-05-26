using Microsoft.Azure.Devices;
using Projekt_IoT;
using System;
string conString = "HostName=projekt-iot.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=C+4U1vEcfGiqt3tj7+LRdvmOtsOkaSxagAIoTKwRW+Y=";
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("[Controller] Azure Conntecting String Loaded");

using var serviceClient = ServiceClient.CreateFromConnectionString(conString);
using var registryManager = RegistryManager.CreateFromConnectionString(conString);

var manager = new Projekt_IoT.IotHubManager(serviceClient, registryManager);

//do while ...

Console.WriteLine("[Controller] Controller End Working");
Console.WriteLine("-------------------------------------------------");