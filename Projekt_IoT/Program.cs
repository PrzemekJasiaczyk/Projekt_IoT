using Microsoft.Azure.Devices;
using Projekt_IoT;
using System;
string conString = "HostName=projekt-iot.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=C+4U1vEcfGiqt3tj7+LRdvmOtsOkaSxagAIoTKwRW+Y=";
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("[Controller] Azure Conntecting String Loaded");

using var serviceClient = ServiceClient.CreateFromConnectionString(conString);
using var registryManager = RegistryManager.CreateFromConnectionString(conString);

var manager = new Projekt_IoT.IotHubManager(serviceClient, registryManager);

int input;
do
{
    FeatureSelector.PrintMenu();
    input = FeatureSelector.ReadInput();
    await FeatureSelector.Execute(input, manager);
} while (input != 0);


Console.WriteLine("[Controller] Controller End Working");
Console.WriteLine("-------------------------------------------------");