using Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;

namespace Antiproton
{
    public class PBarElement : IWrapsElement
    {
        private PBarDriver _pBarDriver;
        private IWebElement _element;
        private By _elementIdentifier;

        public PBarElement(PBarDriver driver, By elementIdentifier)
        {
            _pBarDriver = driver;
            _element = PBarDriver.FindElement(elementIdentifier).WrappedElement;
            _elementIdentifier = elementIdentifier;
        }

        public PBarElement(PBarDriver driver, IWebElement element)
        {
            _pBarDriver = driver;
            _element = element;
        }

        public PBarElement(PBarDriver driver, IWebElement element, By elementIdentifier)
        {
            _pBarDriver = driver;
            _element = element;
            _elementIdentifier = elementIdentifier;
        }

        public PBarElement(PBarDriver driver, PBarElement element)
        {
            _pBarDriver = driver;
            _element = element.WrappedElement;
            _elementIdentifier = element.ElementIdentifier;
        }
        public PBarDriver PBarDriver => _pBarDriver;

        public IWebElement WrappedElement => _element;

        public By ElementIdentifier => _elementIdentifier;

        public string TagName
        {
            get
            {
                Log.GetLogger().Info($"Getting element [{ElementIdentifier}] TagName Property");
                return WrappedElement.TagName;
            }
        }

        public string Text
        {
            get
            {
                Log.GetLogger().Info($"Getting element [{ElementIdentifier}] Text Property");
                return WrappedElement.Text;
            }
        }

        public bool Enabled
        {
            get
            {
                Log.GetLogger().Info($"Getting element [{ElementIdentifier}] Enabled Property");
                return WrappedElement.Enabled;
            }
        }

        public bool Selected
        {
            get
            {
                Log.GetLogger().Info($"Getting element [{ElementIdentifier}] Selected Property");
                return WrappedElement.Selected;
            }
        }

        public Point Location
        {
            get
            {
                Log.GetLogger().Info($"Getting element [{ElementIdentifier}] Location Property");
                return WrappedElement.Location;
            }
        }

        public Size Size
        {
            get
            {
                Log.GetLogger().Info($"Getting element [{ElementIdentifier}] Size Property");
                return WrappedElement.Size;
            }
        }

        public bool Displayed
        {
            get
            {
                Log.GetLogger().Info($"Getting element [{ElementIdentifier}] Displayed Property");
                return WrappedElement.Displayed;
            }
        }

        public PBarElement Clear()
        {
            Log.GetLogger().Info($"Clearing element [{ElementIdentifier}]");
            WrappedElement.Clear();

            return this;
        }

        public PBarElement SendKeys(string text)
        {
            Log.GetLogger().Info($"Sending [{text}] to element [{ElementIdentifier}]");
            WrappedElement.SendKeys(text);

            return this;
        }

        public PBarElement Submit()
        {
            Log.GetLogger().Info($"Submitting element [{ElementIdentifier}]");
            WrappedElement.Submit();

            return this;
        }

        public PBarElement Click()
        {
            Log.GetLogger().Info($"Clicking element [{ElementIdentifier}]");
            WrappedElement.Click();

            return this;
        }

        public PBarElement ClickAndWaitForUrlChange()
        {
            string currentUrl = PBarDriver.Url;

            Log.GetLogger().Info($"Clicking element [{ElementIdentifier}]");
            WrappedElement.Click();

            Log.GetLogger().Info($"Waiting for url to change after click");

            while (PBarDriver.Url.Equals(currentUrl))
            {
                Thread.Sleep(250);
            }

            Log.GetLogger().Info($"Url changed");

            return this;
        }

        public string GetAttribute(string attributeName)
        {
            Log.GetLogger().Info($"Getting [{attributeName}] attribute for element [{ElementIdentifier}]");
            return WrappedElement.GetAttribute(attributeName);
        }

        public string GetProperty(string propertyName)
        {
            Log.GetLogger().Info($"Getting [{propertyName}] property for element [{ElementIdentifier}]");
            return WrappedElement.GetProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            Log.GetLogger().Info($"Getting [{propertyName}] CssValue for element [{ElementIdentifier}]");
            return WrappedElement.GetCssValue(propertyName);
        }

        public PBarElement FindElement(By by)
        {
            Log.GetLogger().Info($"Finding element by locator:[{by}]");
            return new PBarElement(PBarDriver, _element.FindElement(by), by);
        }

        public ReadOnlyCollection<PBarElement> FindElements(By by)
        {
            Log.GetLogger().Info($"Finding elements by locator:[{by}]");
            return new ReadOnlyCollection<PBarElement>(_element.FindElements(by).Select(el => new PBarElement(PBarDriver, el, by)).ToList());
        }
    }
}
