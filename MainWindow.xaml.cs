using System.Diagnostics;
using System.Windows;

namespace ElementID
{
    public partial class MainWindow : Window
    {
        public VM_MainWindow VM_MainWindow;

        public MainWindow()
        {
            InitializeComponent();
            new System.Windows.Interop.WindowInteropHelper(this).Owner = Process.GetCurrentProcess().MainWindowHandle;
        }

        #region PUBLIC METHODS
        public void SetupForm()
        {
            DataContext = VM_MainWindow;
        }
        #endregion

        #region EVENTS
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Service.RunProcess();
        }

        private void BtnSelection_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Service.SelectObjects();
            ShowDialog();
        }
        #endregion
    }
}
