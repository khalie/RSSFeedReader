﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;
using RSS_Feed_Reader.Model;

namespace RSS_Feed_Reader.ViewModel
{
    public class MainPageViewModel
    {
        public ObservableCollection<SyndicationItem> News { get; set; }

        public MainPageViewModel()
        {
            News = new ObservableCollection<SyndicationItem>();

        }

        public async void LoadNews()
        {
            RSSReader rssReader = new RSSReader();
            var news = await rssReader.LoadNewsAsync();

            foreach (var syndicationItem in news)
            {
                News.Add(syndicationItem);
            }

        }
    }
}