namespace PriceTracker
{
    abstract class Website
    {
        public abstract string GetPrice(HtmlAgilityPack.HtmlDocument doc);
        public bool ValidateUrl(string url)
        {
            bool isValid = false;
            if (url.ToLower().Contains("amazon"))
                isValid = true;
            else if (url.ToLower().Contains("flipkart"))
                isValid = true;
            else
                isValid = false;

            return isValid;
        }
    }
}