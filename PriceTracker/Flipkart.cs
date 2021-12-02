using HtmlAgilityPack;

namespace PriceTracker
{
    class Flipkart : Website
    {
        public override string GetPrice(HtmlDocument doc)
        {
            string productPrice = string.Empty;
            var documentNode = doc.DocumentNode.SelectNodes("//div[@class='_30jeq3 _16Jk6d']");

            if (documentNode?.Count > 0)
                productPrice = documentNode[0].InnerText;

            return productPrice;
        }
    }
}
