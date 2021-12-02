using HtmlAgilityPack;

namespace PriceTracker
{
    class Amazon : Website
    {
        public override string GetPrice(HtmlDocument doc)
        {
            string productPrice = string.Empty;
            var documentNode = doc.DocumentNode.SelectNodes("//span[@id='priceblock_ourprice']");
            var documentNode2 = doc.DocumentNode.SelectNodes("//span[@id='price_inside_buybox']");

            if (documentNode?.Count > 0)
                productPrice = documentNode[0].InnerText;
            else if (documentNode2?.Count > 0)
                productPrice = documentNode[0].InnerText;

            return productPrice;
        }
    }
}
