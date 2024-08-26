using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Interop.WinDef;
using WatcherFinal.Constants;

namespace WatcherFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Grid> viewList;
        public string UserNameEntered { get; set; }
        public string PasswordEntered { get; set; }
        private Grid current;

        public MainWindow ()
        {
            viewList = new List<Grid> ();
            InitializeComponent();
            PopulateViewList();
            UpdateUI(0);
        }

        private void PopulateViewList ()
        {
            viewList.Add(LoginView);
            viewList.Add(HomeView);
            viewList.Add(SerialDetailsView);
        }

        private void UpdateUI (int index)
        {
            if ( index >= 0 )
            {
                viewList [index].Visibility = Visibility.Visible;
                current = viewList [index];
            }
            else
            {
                //First Enterance
                LogoMain.Visibility = Visibility.Visible;
                NavigationBar.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Handles login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click ( object sender, RoutedEventArgs e )
        {
            UserNameEntered = userNameBox.Text;
            if ( passBox.IsPasswordRevealed )
            {
                PasswordEntered = passBox.Text;
            }
            else
            {
                PasswordEntered = passBox.Password;
            }
            string pass;
            if ( Users.UserList.TryGetValue(UserNameEntered, out pass) )
            {
                LoginView.Visibility = Visibility.Hidden;
                UpdateUI(1);
                UpdateUI(-1);
                if(UserNameEntered == "admin")
                    isAdminOnline.Visibility = Visibility.Visible;
            }
        }

        private void Serial_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility = Visibility.Hidden;
            SerialDetailsView.Visibility = Visibility.Visible;
            current = SerialDetailsView;
        }

        private void Ethernet_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility = Visibility.Hidden;
            EthernetDetailsView.Visibility = Visibility.Visible;
            current = EthernetDetailsView;
        }

        private void SerialConnect_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility=Visibility.Hidden;
            MonitorView.Visibility = Visibility.Visible;
            current = MonitorView;
            NavigationBar.Visibility = Visibility.Hidden;
        }
        private void EthernetConnect_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility = Visibility.Hidden;
            MonitorView.Visibility = Visibility.Visible;
            current = MonitorView;
            NavigationBar.Visibility = Visibility.Hidden;
        }

        private void NavigationHomeViewItem_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility = Visibility.Hidden;
            HomeView.Visibility = Visibility.Visible;
            current = HomeView;
        }

        private void NavigationMonitorViewItem_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility = Visibility.Hidden;
            MonitorView.Visibility = Visibility.Visible;
            current = MonitorView;
            NavigationBar.Visibility = Visibility.Hidden;
        }

        private void NavigationLogsViewItem_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility = Visibility.Hidden;
            LogsView.Visibility = Visibility.Visible;
            current = LogsView;
        }

        private void NavigationAdminPanelViewItem_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility = Visibility.Hidden;
            AdminPanelView.Visibility = Visibility.Visible;
            current = AdminPanelView;
        }

        private void NavigationSettingsViewItem_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility = Visibility.Hidden;
            SettingsView.Visibility = Visibility.Visible;
            current = SettingsView;
        }

        private void StopCommunication_Click ( object sender, RoutedEventArgs e )
        {
            current.Visibility= Visibility.Hidden;
            NavigationBar.Visibility= Visibility.Visible;
            LogsView.Visibility= Visibility.Visible;
            current= LogsView;
        }
    }
}