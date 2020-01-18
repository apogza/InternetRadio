using InternetRadio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InternetRadio.ViewModels
{
    public class MainPageViewModel
    {
        public async Task<IEnumerable<string>> ResolveRadioApiServers()
        {
            var addresses = await Task.Run(() => Dns.GetHostAddresses(Constants.RadioBrowserDns));
            var hostEntries = addresses.Select(address => Dns.GetHostEntry(address.ToString()));

            return hostEntries.Select(hostEntry => hostEntry.HostName);
        }

    }
}
