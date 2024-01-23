namespace BlazorApp1.Logic
{
    public class CatfactRetriever
    {
        public HttpClient httpClient { get; set; }
        public CatfactRetriever(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<string> RetrieveFact()
        {
            var response = await httpClient.GetStringAsync("https://catfact.ninja/fact");
            var content = response;
            var fact = content;
            return fact; 
        }
    }
}
