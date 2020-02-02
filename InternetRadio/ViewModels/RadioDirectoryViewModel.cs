using InternetRadio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InternetRadio.ViewModels
{
    public class RadioDirectoryViewModel : BaseViewModel
    {
        private IEnumerable<Country> _countries;

        public IEnumerable<Country> Countries
        {
            get { return _countries; }
            set { SetProperty(ref _countries, value); }
        }

        private Country _country;

        public Country SelectedCountry
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }

        private IEnumerable<Radio> _radios;

        public IEnumerable<Radio> Radios
        {
            get { return _radios; }
            set { SetProperty(ref _radios, value); }
        }

        private Radio _selectedRadio;

        public Radio SelectedRadio
        {
            get { return _selectedRadio; }
            set { SetProperty(ref _selectedRadio, value); }
        }

        private string _apiServer;

        public string ApiServer
        {
            get { return _apiServer; }
            set { SetProperty(ref _apiServer, value); }
        }

        public async Task Init()
        {
            ApiServer = string.Format("https://{0}", await GetApiServer());
            RestClient.SetBaseUri(ApiServer);

            Countries = await GetCountries();
        }

        public async Task ShowRadiosForSelectedCountry()
        {
            Radios = await GetRadiosByCountry(SelectedCountry.Name);
        }

        private async Task<string> GetApiServer()
        {
            var addresses = await Task.Run(() => Dns.GetHostAddresses(Constants.RadioBrowserDns));
            var hostEntries = addresses.Select(address => Dns.GetHostEntry(address.ToString()));

            return hostEntries.First().HostName;
        }

        private async Task<IEnumerable<Country>> GetCountries()
        {
            string countriesQuery = "json/countries";
            IEnumerable<Country> searchResult = await RestClient.GetResults<List<Country>>(countriesQuery);

            return searchResult;
        }

        private async Task<IEnumerable<Radio>> GetRadiosByCountry(string country)
        {
            string radiosByCountryQuery = string.Format("json/stations/bycountry/{0}", country);
            IEnumerable<Radio> searchResult = await RestClient.GetResults<List<Radio>>(radiosByCountryQuery);

            return searchResult;
        }
    }
}
