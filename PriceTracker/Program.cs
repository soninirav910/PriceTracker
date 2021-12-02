using HtmlAgilityPack;
using System;
using System.Net;

namespace PriceTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInput();
        }

        private static void GetInput()
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                Console.WriteLine("Enter Product Link:");
                var url = Console.ReadLine();
                bool isValid = false;
                string price = string.Empty;

                //Flipkart: TLS 1.2, Amazon: TLS 1.3
                //Setting TLS 1.2 needed explicitly for Flipkart.
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HtmlDocument doc = web.Load(url);
                
                if (url.ToLower().Contains("amazon"))
                {
                    var amazon = new Amazon();
                    isValid = amazon.ValidateUrl(url);
                    if (isValid)
                        price = amazon.GetPrice(doc);
                    else
                        Console.WriteLine("Unsupported Url");
                }
                else if (url.ToLower().Contains("flipkart"))
                {
                    var flipkart = new Flipkart();
                    isValid = flipkart.ValidateUrl(url);
                    if (isValid)
                        price = flipkart.GetPrice(doc);
                    else
                        Console.WriteLine("Unsupported Url");
                }
                else
                    Console.WriteLine("Unsupported Url");

                if (!string.IsNullOrWhiteSpace(price))
                {
                    Console.WriteLine("Price of this product is: " + price);
                    var email = new Mail();
                    email.SendNotification();
                }
                else
                    Console.WriteLine("Price fetch failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.StackTrace);
            }

            Console.WriteLine("Press 1 for retry");
            var retry = Console.ReadLine();
            if (retry == "1")
            {
                GetInput();
            }
        }

        
    }
}
