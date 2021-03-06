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

        private Visibility _RedistributionVisibility;
        public Visibility RedistributionVisibility
        {
            get => _RedistributionVisibility;
            set => Set(ref _RedistributionVisibility, value);
        }

        private Visibility _LogVisibility;
        public Visibility LogVisibility
        {
            get => _LogVisibility;
            set => Set(ref _LogVisibility, value);
        }

        private int _listViewIndex;
        public int ListViewIndex
        {
            get => _listViewIndex;
            set => Set(ref _listViewIndex, value);
        }
        #endregion

        #region Command
        public RelayCommand<object> MenuClickCommand { get; private set; }
        public RelayCommand<object> ButtonClickCommand { get; private set; }
        public RelayCommand<CancelEventArgs> WindowClosingCommand { get; private set; }
        public RelayCommand<object> ToggledCommand { get; private set; }
        public RelayCommand<EventArgs> SelectedListViewItemCommand { get; private set; }

        #region Command Action
        private void InitRelayCommand()
        {
            // MenuClickCommand = new RelayCommand<object>(OnMenuClick);
            ButtonClickCommand = new RelayCommand<object>(OnButtonClick);
            SelectedListViewItemCommand = new RelayCommand<EventArgs>(OnSelectedListViewItemIndex);
            //WindowClosingCommand = new RelayCommand<CancelEventArgs>(OnWindowClosing);
            //ToggledCommand = new RelayCommand<object>(OnToggled);
        }

        private void MinimizeWindow()

        {
            MainWindowState = WindowState.Minimized;
        }

        private void CloseWindow()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
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

        private void OnSelectedListViewItemIndex(EventArgs e)
        {
            switch (ListViewIndex)
            {
                case 0:
                    RedistributionVisibility = Visibility.Visible;
                    LogVisibility = Visibility.Hidden;
                    break;
                case 1:
                    RedistributionVisibility = Visibility.Hidden;
                    LogVisibility = Visibility.Visible;
                    break;
            }
        }
        #endregion
        #endregion

        public MainViewModel()
        {
            InitRelayCommand();

            ListViewIndex = 0;
            RedistributionVisibility = Visibility.Visible;
            LogVisibility = Visibility.Hidden;
        }

    }
}
