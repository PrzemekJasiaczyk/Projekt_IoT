using Microsoft.Azure.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_IoT
{
    internal class IotHubManager
    {

        private readonly ServiceClient client;
        private readonly RegistryManager registry;
        public IotHubManager(ServiceClient client, RegistryManager registry)
        {
            this.client = client;
            this.registry = registry;
        }
    }
}
