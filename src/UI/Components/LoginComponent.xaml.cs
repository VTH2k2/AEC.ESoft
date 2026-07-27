using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Views;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for LoginComponent.xaml
    /// </summary>
    public partial class LoginComponent : UserControl
    {
        public LoginComponent()
        {
            InitializeComponent();
        }
        private void HandleLoginClick(object sender, RoutedEventArgs e)
        {
            var staffView = new StaffView();

            Window.GetWindow(this).Content = staffView;
        }
    }
}
