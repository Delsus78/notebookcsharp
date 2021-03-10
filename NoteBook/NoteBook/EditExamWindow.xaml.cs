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
using Storage;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {
        private Notebook notebook;
        private IStockage storage;
        private Exam exam;

        public EditExamWindow(Notebook nb, IStockage storage, Exam exam)
        {
            
            this.notebook = nb;
            InitializeComponent();
            DrawModules();
            this.storage = storage;
            this.exam = exam;

            CB_Absent.IsChecked = this.exam.IsAbsent;

            if (this.exam.IsAbsent) TB_Score.IsEnabled = false;

            TB_Coef.Text = this.exam.Coef.ToString();
            TB_Score.Text = this.exam.Score.ToString();
            TB_Teacher.Text = this.exam.Teacher;
            DP_Date.SelectedDate = this.exam.DateExam;
            CB_Module.SelectedItem = this.exam.Module;
        }

        /// <summary>
        /// (r)affiche les modules de la liste LB_Modules
        /// </summary>
        private void DrawModules()
        {
            CB_Module.Items.Clear();
            foreach (Module module in notebook.ListModules())
                CB_Module.Items.Add(module);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void validate(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CB_Module.SelectedItem is Module m)
                {
                    this.exam.Module = m;
                    this.exam.Coef = (float)Convert.ToDouble(TB_Coef.Text);

                    this.exam.Score = (float)Convert.ToDouble(TB_Score.Text);
                    this.exam.IsAbsent = (bool)CB_Absent.IsChecked;
                    this.exam.Teacher = TB_Teacher.Text;
                    this.exam.DateExam = (DateTime)DP_Date.SelectedDate;

                    if (!notebook.ListExams().Contains(this.exam))
                        this.notebook.AddExam(this.exam);
                    
                    storage.Update(notebook);
                    Close();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void OnClickAbsent(object sender, RoutedEventArgs e)
        {
            TB_Score.IsEnabled = !TB_Score.IsEnabled;
        }
    }
}
