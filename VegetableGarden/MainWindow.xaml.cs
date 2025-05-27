
using System.Windows;
using VegetableGarden.ViewModels;

namespace VegetableGarden
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}