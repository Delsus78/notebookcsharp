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
using System.Windows.Shapes;
using Logic;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour ListExamsWindow.xaml
    /// </summary>
    public partial class ListExamsWindow : Window
    {
        private Notebook notebook;
        private IStockage storage;
        public ListExamsWindow(Notebook notebook,IStockage stockage)
        {
            InitializeComponent();
            this.notebook = notebook;
            this.storage = stockage;
            DrawExams();
        }
        private void DrawExams()
        {
            exams.Items.Clear();
            foreach (Exam e in notebook.ListExams())
            {
                exams.Items.Add(e);
            }

            LB_Moyennes.Items.Clear();
            
            foreach (AvgScore avg in notebook.ComputeScore())
            {
                LB_Moyennes.Items.Add(avg);
            }

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditExam(object sender, MouseButtonEventArgs e)
        {
            if (exams.SelectedItem is Exam exam)
            {
                EditExamWindow third = new EditExamWindow(this.notebook, this.storage, exam);
                if (third.ShowDialog() == true)
                {
                    storage.Update(notebook);
                }
            }
            DrawExams();
        }

        private void OnClickSupr(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirm = MessageBox.Show("Etes-vous sûr de vouloir faire cela ?", "Confirmation",MessageBoxButton.YesNo);
            if(confirm == MessageBoxResult.Yes)
                if (exams.SelectedItem is Exam ex)
                {
                    notebook.RemoveExam(ex);
                    DrawExams();
                    storage.Update(notebook);
                }
        }
    }
}
