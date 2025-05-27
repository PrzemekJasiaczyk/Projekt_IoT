# Projekt_IoT
# IoT Agent – Dokumentacja Techniczna

## Spis treści

1. [Opis projektu]
2. [Wymagania wstępne] 
3. [Uruchomienie aplikacji]  
4. [Konfiguracja]
5. [Opis działania agenta]
6. [Format wiadomości C2D]
7. [Device Twin]
8. [Obsługiwane metody bezpośrednie (Direct Methods)]

---

## Opis projektu

Aplikacja IoT Agent umożliwia integrację urządzenia z serwerem OPC UA oraz Azure IoT Hub. Agent cyklicznie monitoruje dane z wybranego urządzenia i wysyła je do chmury, a także obsługuje polecenia przychodzące z IoT Hub w formie metod bezpośrednich (Direct Methods).

---

## Wymagania wstępne

- Visual Studio (z obsługą .NET)
- Konto Azure i skonfigurowany IoT Hub

---

## Uruchomienie aplikacji

1. Uruchomienie UA SampleClient pod adersem opc.tcp://localhost:4840/
2. Uruchomienie Industrial Device Simulator i dodanie nowego użądzenia.
3. Skonfiguruj  Visual Studio wiele projektów start-upowych > Projekt_IoT Uruchom i Projekt_IoT_Device Uruchom.
4. Kliknij przycisk **"Rozpocznij"** (Start), aby uruchomić agenta.

---

## Konfiguracja

### Konfiguracja po stronie urządzenia (`device`) Projekt_IoT_Device:

- **Połączenie z serwerem OPC UA**:  
  Zmienna `string OPCstring = "opc.tcp://localhost:4840/";` umieszona w pliku Functions.cs

- **Nazwa urządzenia OPC UA**:
  Zmienna `string DeviceName = "Device1";` umieszona w pliku Functions.cs

- **Klucz połączeniowy do Azure IoT Hub**:  
  Klucz umieszony w zmiennej conString w pliku Program.cs
  `string conString = "HostName=projekt-iot.azure-devices.net;DeviceId=Device1;SharedAccessKey=6YVojAtq8v4YHIno38bH0S40gi9qBDhg1my9EYP6fHg=";`

### Konfiguracja po stronie kontrolera Projekt_IoT:

- **Połączenie z IoT Hub**:  
    Azure Conntecting String Umieszony w zmiennej conString w pliku Program.cs
  `string conString = "HostName=projekt-iot.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=C+4U1vEcfGiqt3tj7+LRdvmOtsOkaSxagAIoTKwRW+Y=";`

---

## Opis działania agenta

- Agent łączy się z serwerem OPC UA i cyklicznie (co 10 sekund) odczytuje dane z jednego urządzenia.
- Dane te są wysyłane jako wiadomości C2D do chmury Azure aż do momentu zatrzymania agenta.

---

## Format wiadomości C2D
### Start device

|------------------------------------------|
```[Agent] Azure Conntecting String Loaded
[Agent] Connection with Device Established
[Agent]         Initial twin value recived:
{
  "deviceId": null,
  "etag": null,
  "version": null,
  "properties": {
    "desired": {
      "$version": 13,
      "BadCount": 1429786692,
      "DeviceErrors": 845448158,
      "GoodCount": 185742273,
      "ProductionStatus": 343258145,
      "WorkerID": 1871513973,
      "WorkorderID": 1871513973,
      "prop1": "23",
      "temperature": 900235169
    },
    "reported": {
      "$version": 10,
      "DateTimeLastAppLaunch": "2025-05-27T17:58:20.6554221+02:00",
      "ErrorStatus": "",
      "ProductionRate": 0
    }
  }
}
[Agent] Start Working...

|---------------------------------------|

[Agent] Getting data from Opc Ua ...

[Agent] Data Collected

[Agent] Device sending message to Azure IOT HUB


[Agent]27.05.2025 18:02:24 --- Message sending

[Data] [{"ProductionStatus":null,"WorkorderId":null,"Temperature":null,"GoodCount":null,"BadCount":null,"ProductionRate":null}]

[Agent] Message Send to Azure
 
 [Agent] Device Offline -> Not Sending Data !
```
### Menu Controlera i akcje
```
[Controller] Azure Conntecting String Loaded
------ MENU ------
1 - C2D - Cloud to Device
2 - Device Twin                                                                                                       
3 - Direct Method - Send Message                                                                                        
4 - Direct Method - Emergency STOP                                                                                      
5 - Direct Method - Reset Errors                                                                                        
6 - Increase Production Rate by 10                                                                                      
7 - Decrease Production Rate by 10                                                                                      
8 - Set Production Rate                                                                                                 
0 - Exit                                                                                                          
1                                                                                                                       
Write your message text and click enter:                                                                               
Hello device                                                                                                            
Enter your Azure ID device and click enter:                                                                            
Device1                                                                                                                 
Message sent! 
2
Enter your Azure ID device and click enter:
Device1
Enter your property Name:
Temperature
3                                                                                                                      
Enter your Azure ID device and click enter                                                                              
Device1                                                                                                                 
[Controller] Method Executed with: 0 
4
Enter your Azure ID device and click enter:
Device1
[Controller] Method Executed with: 500
5
Enter your Azure ID device and click enter:
Device1
[Controller] Method Executed with: 500
6
Enter your Azure ID device and click enter:
Device1
[Controller] Method Executed with: 0
7
Enter your Azure ID device and click enter:
Device1
[Controller] Method Executed with: 0

0[Controller] Controller End Working
-------------------------------------------------
```
### Informacje zwrotne 
```
|---------------------------------------|
[Agent] Getting data from Opc Ua ...
[Agent] Data Collected
[Agent] Device sending message to Azure IOT HUB

[Agent]27.05.2025 21:16:44 --- Message sending
[Data] [{"ProductionStatus":null,"WorkorderId":null,"Temperature":null,"GoodCount":null,"BadCount":null,"ProductionRate":null}]
[Agent] Message Send to Azure
[Agent] Device Offline -> Not Sending Data !
[Agent] Device Offline -> Not Sending Data !
[Agent] Device Offline -> Not Sending Data !
[Agent] Device Offline -> Not Sending Data !
 |---------------------------------------|
[Agent]         27.05.2025 21:17:06> C2D message callback - message recieved with id=580f004a-104a-4fed-ad9d-eaa0206d24fd
[Agent]                 Recieved message: {"text":"Hello device"}
[Agent]         27.05.2025 21:17:06> Completed C2D message with ID=580f004a-104a-4fed-ad9d-eaa0206d24fd
[Agent] Device Offline -> Not Sending Data !
[Agent] Device Offline -> Not Sending Data !
[Agent] Device Offline -> Not Sending Data !
  |---------------------------------------|
  [Agent]          Desired property change:
{"$version":16,"BadCount":1429786692,"DeviceErrors":845448158,"GoodCount":185742273,"ProductionStatus":343258145,"Temperature":1436428444,"WorkerID":1871513973,"WorkorderID":1871513973,"prop1":691424510,"temperature":900235169}
[Agent]         Sending current time as reported property
[Agent] Device Offline -> Not Sending Data !
 |---------------------------------------|
[Agent] Getting data from Opc Ua ...
[Agent] Data Collected
[Agent] Device sending message to Azure IOT HUB
[Agent]27.05.2025 21:20:58 --- Message sending
[Data] [{"ProductionStatus":null,"WorkorderId":null,"Temperature":null,"GoodCount":null,"BadCount":null,"ProductionRate":null}]
[Agent] Message Send to Azure
 [Agent] Device Offline -> Not Sending Data !
 [Agent] Device Offline -> Not Sending Data !
|---------------------------------------|
|---------------------------------------|
|---------------------------------------|
|---------------------------------------|
|---------------------------------------|
[Agent] Device Offline -> Not Sending Data !                                                                           
[Agent]          Desired property change:                                                                                        
{"$version":19,"BadCount":1429786692,"Device1":"190","DeviceErrors":845448158,"GoodCount":185742273,"KlockiLego":"190","ProductionStatus":343258145,"Temperature":1436428444,
"WorkerID":1871513973,"WorkorderID":1871513973,"kjfwf":1913029940,"prop1":691424510,"temperature":900235169}                                                                 
[Agent]         Sending current time as reported property
```
