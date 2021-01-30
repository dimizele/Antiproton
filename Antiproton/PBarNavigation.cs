using Logger;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antiproton
{
    public class PBarNavigation : INavigation
    {
        private INavigation _navigation;

        public PBarNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }

        public void Back()
        {
            Log.GetLogger().Info($"Navigating Back");
            _navigation.Back();
        }

        public void Forward()
        {
            Log.GetLogger().Info($"Navigating Forward");
            _navigation.Forward();
        }

        public void GoToUrl(string url)
        {
            Log.GetLogger().Info($"Navigating To Url [{url}]");
            _navigation.GoToUrl(url);
        }

        public void GoToUrl(Uri url)
        {
            Log.GetLogger().Info($"Navigating To Url [{JsonConvert.SerializeObject(url)}]");
            _navigation.GoToUrl(url);
        }

        public void Refresh()
        {
            Log.GetLogger().Info($"Refresh page");
            _navigation.Refresh();
        }
    }
}
