using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;
using RSS_Feed_Reader.Model;
using System.Windows.Input;

namespace RSS_Feed_Reader.ViewModel
{
  public class MainPageViewModel
  {

    public ObservableCollection<SyndicationItem> News { get; set; }

    public MainPageViewModel()
    {
      News = new ObservableCollection<SyndicationItem>();
      _loadCommand = new RelayCommand(this.LoadNews, () => true);

      // Load the Newsfeed on startup
      LoadNews();
    }



    #region commands

    private readonly ICommand _loadCommand;
    public ICommand loadCommand
    {
      get { return _loadCommand; }
    }

    #endregion

    #region methods

    /// <summary>
    /// Method which loads the News Feed and adds the items to the "News" Collection.
    /// </summary>
    public async void LoadNews()
    {
      RSSReader rssReader = new RSSReader();

      // Clear the Collection. Otherwise the Collection dupicates on every loading.
      News.Clear();

      var news = await rssReader.LoadNewsAsync(new Uri("http://blog.pdapda.de/feed/"));

      foreach (var syndicationItem in news)
      {
        News.Add(syndicationItem);
      }

    }

    #endregion
  }
}
