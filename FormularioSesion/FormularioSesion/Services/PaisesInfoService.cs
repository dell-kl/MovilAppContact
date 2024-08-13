using FormularioSesion.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FormularioSesion.Services
{
    public class PaisesInfoService : IPaisesInfo
    {
        HttpClient _httpClient { set; get; }
        private String url { set; get; } 
        public PaisesInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            url = "https://restcountries.com/v3.1/all";
        }

        public Task<ICollection<PaisInfo>> ObtenerPaises()
        {
            return null;
        }
    }
}
