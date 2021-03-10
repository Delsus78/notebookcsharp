
using System.Windows;
using Logic;
using Storage;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Notebook notebook;
        private IStockage storage;

        public MainWindow()
        {
            this.storage = new JsonStockage();
            this.notebook = storage.Load();
            InitializeComponent();
        }

        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            EditUnitsWindow second = new EditUnitsWindow(notebook,storage);
            second.Show();
        }

        private void EntrereExamClick(object sender, RoutedEventArgs e)
        {
            EditExamWindow examWindow = new EditExamWindow(notebook,storage,new Exam());
            examWindow.Show();
        }

        private void ClickAfficherMoyenne(object sender, RoutedEventArgs e)
        {
            ListExamsWindow listExamWindow = new ListExamsWindow(notebook,storage);
            listExamWindow.Show();
        }
    }
}
