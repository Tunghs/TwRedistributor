using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace TwRedistributor.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region UI Variable
        #region Window
        private WindowState _MainWindowState;
        public WindowState MainWindowState
        {
            get => _MainWindowState;
            set => Set(ref _MainWindowState, value);
        }
        #endregion
        #endregion

        #region Command
        public RelayCommand<object> MenuClickCommand { get; private set; }
        public RelayCommand<object> ButtonClickCommand { get; private set; }
        public RelayCommand<CancelEventArgs> WindowClosingCommand { get; private set; }
        public RelayCommand<object> ToggledCommand { get; private set; }

        #region Command Action
        private void InitRelayCommand()
        {
            // MenuClickCommand = new RelayCommand<object>(OnMenuClick);
            ButtonClickCommand = new RelayCommand<object>(OnButtonClick);
            //WindowClosingCommand = new RelayCommand<CancelEventArgs>(OnWindowClosing);
            //ToggledCommand = new RelayCommand<object>(OnToggled);
        }

        private void OnButtonClick(object param)
        {
            switch (param.ToString())
            {
                case "Minimize":
                    MinimizeWindow();
                    break;
                case "Close":
                    CloseWindow();
                    break;
            }
        }

        private void MinimizeWindow()
        {
            MainWindowState = WindowState.Minimized;
        }

        private void CloseWindow()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        #endregion
        #endregion

        public MainViewModel()
        {
            InitRelayCommand();
        }
    }
}
