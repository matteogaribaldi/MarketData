using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using YahooQuotesApi;


namespace MarketData.Controllers;

[EnableCors(origins: "*", 
    headers: "*", methods: "*")]
[ApiController]
[Route("[controller]")]
public class MarketData: ControllerBase
{

    YahooQuotes yahooQuotes = new YahooQuotesBuilder().Build();

    AssetMarketData data = new AssetMarketData();


    [HttpGet]
    [Route("/api/getAssetPrice/")]
    public async Task<AssetMarketData?> GetAsync(string input)
    {
        

        Security? security = await yahooQuotes.GetAsync(input);

        if (security is null)
            throw new ArgumentException("Unknown symbol: "+input);

        data.Ticker = input;
        data.CurrentPrice = security.RegularMarketPrice; 
        data.Currency = security.Currency;

        return data;
    }
    [HttpGet]
    [Route("/api/getMinRebalance/")]
    public int Get()
    {
        Random rnd = new Random();
// Create the linear solver with the GLOP backend.
       

        return rnd.Next(100);
    }

       [HttpPost]
    [Route("/api/rebalancePortfolio/")]
    public Task<List<RebalancedAsset>> GetRebalancedAssets(decimal cash, List<RebalancedAsset> portfolio)
    {
       List<RebalancedAsset> rebalancedPortfolio = new List<RebalancedAsset>(portfolio);

        foreach (RebalancedAsset asset in rebalancedPortfolio)
        {
            Random rnd = new Random();
            asset.calculatedTargetNumber = (rnd.Next(20));
            asset.calculatedTargetDelta = asset.calculatedTargetNumber * asset.currentPrice;
            asset.calculatedTotalPrice = (asset.number + asset.calculatedTargetNumber) * asset.currentPrice;
        }

        return Task.FromResult(rebalancedPortfolio);
    }
 


}
