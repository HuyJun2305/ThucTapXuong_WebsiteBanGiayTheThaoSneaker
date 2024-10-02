using DataProcessing.Models;
using Newtonsoft.Json;
using View.IServices;

namespace View.Servicecs
{
    public class ShippingUnitServices : IShippingUnitServices
    {
        private readonly HttpClient _httpClient;

        public ShippingUnitServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task create(ShippingUnit shippingUnit)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:44351/api/ShippingUnits", shippingUnit);
        }

        public async Task delete(Guid? shippingUnitId)
        {
            await _httpClient.DeleteAsync($"https://localhost:44351/api/ShippingUnits/{shippingUnitId}");
        }

        public async Task<List<ShippingUnit>> GetAllShippingUnit()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:44351/api/ShippingUnits");
            var listShippingUnit = JsonConvert.DeserializeObject<List<ShippingUnit>>(response);
            return listShippingUnit;
        }

        public async Task<ShippingUnit> GetShippingUnitById(Guid? shippingUnitId)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44351/api/ShippingUnits/{shippingUnitId}");
            var ShippingUnit = JsonConvert.DeserializeObject<ShippingUnit>(response);
            return ShippingUnit;
        }

        public async Task update(ShippingUnit shippingUnit)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:44351/api/ShippingUnits/{shippingUnit.ShippingUnitID}", shippingUnit);
        }
    }
}
