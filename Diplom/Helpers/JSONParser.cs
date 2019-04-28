using System;
using System.Collections.Generic;
using System.Linq;
using Diplom.Models;
using Newtonsoft.Json.Linq;

namespace Diplom.Helpers
{
    public class JSONParser
    {
        /// <summary>Метод возвращает список покупок из JSON файла.</summary>
        /// <param name="json">string</param>
        /// <returns>lalaa</returns>
        public static List<Purchase> getPurcases(string json)
        {
            try
            {
                List<Purchase> purchases = new List<Purchase>();
                JObject jObj = JObject.Parse(json);
                var arr = jObj.Children().ToList();
                foreach (var item in arr)
                {
                    Purchase purchase = new Purchase();
                    var buf = item.Children().ToList();
                    int clientId = (int)buf[0]["ClientId"];
                    int productId = (int)buf[0]["ProductId"];
                    double countProducts = (float)buf[0]["CountProducts"];
                    DateTime datePurchase = (DateTime)buf[0]["DatePurchase"];
                    purchase.ClientId = clientId;
                    purchase.ProductId = productId;
                    purchase.Count_product = countProducts;
                    purchase.Date_purchase = datePurchase;
                    purchases.Add(purchase);
                }
                return purchases;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return null;

        }


    }
}
