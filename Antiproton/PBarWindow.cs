using Logger;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Antiproton
{
    public class PBarWindow : IWindow
    {
        private IWindow _window;

        public PBarWindow (IWindow window)
        {
            _window = window;
        }

        public Point Position
        {
            get
            {
                Log.GetLogger().Info($"Window Position is [{_window.Position}]");
                return _window.Position;
            }
            set
            {
                Log.GetLogger().Info($"Setting the Window Size to [{value}]");
                _window.Position = value;
            }
        }
        public Size Size
        {
            get
            {
                Log.GetLogger().Info($"Window Size is [{_window.Size}]");
                return _window.Size;
            }
            set
            {
                Log.GetLogger().Info($"Setting the Window Size to [{value}]");
                _window.Size = value;
            }
        }

        public void FullScreen()
        {
            Log.GetLogger().Info($"Setting the Window To FullScreen");
            _window.FullScreen();
        }

        public void Maximize()
        {
            Log.GetLogger().Info($"Setting the Window To FullScreen");
            _window.Maximize();
        }

        public void Minimize()
        {
            Log.GetLogger().Info($"Setting the Window To FullScreen");
            _window.Minimize();
        }
    }
}
