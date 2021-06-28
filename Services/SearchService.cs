using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using Microsoft.Extensions.Configuration;
using shoestore_listing_aspnetcore.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoestore_listing_aspnetcore.Services
{
    public class SearchService : ISearchService
    {
        private readonly string _serviceName;
        private readonly string _apiKey;
        private readonly string _indexName;

        private readonly IConfiguration _configuration;

        public SearchService(IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceName = _configuration.GetValue<string>("Listing:Settings:SearchServiceName");
            _apiKey = _configuration.GetValue<string>("Listing:Settings:SearchServiceApiKey");
            _indexName = _configuration.GetValue<string>("Listing:Settings:ProductsIndexName");
        }

        public async Task<IEnumerable<Product>> SearchAsync(string query)
        {
            Uri serviceEndpoint = new Uri($"https://{_serviceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(_apiKey);

            // Create a SearchClient to query documents
            SearchClient searchClient = new SearchClient(serviceEndpoint, _indexName, credential);
            Response<SearchResults<Product>> response = await searchClient.SearchAsync<Product>(query);
            SearchResults<Product> value = response.Value;
            IEnumerable<Product> products = value.GetResults().Select(x => x.Document);
            return products;
        }
    }
}