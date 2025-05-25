
using System.Windows;
using VegetableGarden.ViewModels;

namespace VegetableGarden
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Эта строка должна быть первой в конструкторе
            DataContext = new MainWindowViewModel();
        }
    }
}