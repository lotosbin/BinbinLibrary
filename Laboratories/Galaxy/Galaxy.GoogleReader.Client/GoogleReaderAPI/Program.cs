using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml.Linq;
using System.Xml.XPath;

namespace GoogleReaderAPI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //  TODO: enter your google account information here
            string email = "";
            string password = "";

            using (Reader reader = Reader.CreateReader(email, password, "my custom reader"))
            {
                //  rip out the feed urls that I have subscribed to
                IEnumerable<string> feeds =
                    from f in
                        XDocument.Parse(reader.GetSubscriptions()).XPathSelectElements(
                            "//list[@name='subscriptions']/object/string[@name='id']")
                    select f.Value;

                //  Print the last 5 published posts for 15 random feeds
                foreach (string feed in feeds.OrderBy(x => Guid.NewGuid()).Take(15))
                {
                    string url = feed.Replace("feed/http", "http");
                    try
                    {
                        //  load the feed (requesting the last 5 most recent posts)
                        SyndicationFeed syndicationFeed = reader.GetFeed(url, 5);
                        Console.WriteLine("Feed: {0}, Last Updated: {1}", syndicationFeed.Title.Text,
                                          syndicationFeed.LastUpdatedTime.DateTime.ToShortDateString());

                        //  loop through the last 5 posts, printing the titles and the date it
                        //  was published on
                        foreach (SyndicationItem item in syndicationFeed.Items)
                        {
                            Console.WriteLine("\tPost: {0}, Published On: {1}", item.Title.Text,
                                              item.PublishDate.DateTime.ToShortDateString());
                        }

                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Retrieving Feed: {0}", ex);
                    }
                }

                //  Starred Feed
                Console.WriteLine("Starred Feed");
                reader.StarredFeed(5).Items.ToList().ForEach(x => Console.WriteLine(x.Title.Text));
                Console.WriteLine();

                //  Read Feed
                Console.WriteLine("Read Feed");
                reader.ReadFeed(5).Items.ToList().ForEach(x => Console.WriteLine(x.Title.Text));
                Console.WriteLine();
            }
        }
    }
}