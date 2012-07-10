using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace WebScan.WpfApplication
{
    public class CachingTest
    {

        public static void Test()
        {

            ICacheManager goodsCache = CacheFactory.GetCacheManager();

            string id = "001";

            string name = "seed";

            int price = 100;

            Goods goods = new Goods();

            goods.ID = id;

            goods.Name = name;

            goods.Price = price;

            goodsCache.Add(goods.ID, goods, CacheItemPriority.Normal,

                           null, new SlidingTime(TimeSpan.FromMinutes(5)));



            //Retrieve the item

            goods = (Goods)goodsCache.GetData(id);

        }

    }
}