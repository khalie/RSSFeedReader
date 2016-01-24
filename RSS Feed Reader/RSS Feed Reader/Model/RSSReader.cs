using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace RSS_Feed_Reader.Model
{
  public class RSSReader
  {
    /// <summary>
    /// Creates the syndicationClient Object that loads the defined News Feed.
    /// </summary>
    /// <returns>List of Syndication Items</returns>
    public async Task<IList<SyndicationItem>> LoadNewsAsync()
    {
      SyndicationClient syndicationClient = new SyndicationClient();
      var feeds = await syndicationClient.RetrieveFeedAsync(new Uri("http://blog.pdapda.de/feed/"));

      return feeds.Items;
    }
  }
}
