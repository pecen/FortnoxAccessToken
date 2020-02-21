using System.Windows;

namespace FortnoxAccessToken.UI.Shell.Views {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      CenterWindowOnScreen();
    }

    private void CenterWindowOnScreen() {
      double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
      double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
      double windowWidth = Width;
      double windowHeight = Height;
      Left = (screenWidth / 2) - (windowWidth / 2);
      Top = (screenHeight / 2) - (windowHeight / 2) - 100;
    }
  }
}
