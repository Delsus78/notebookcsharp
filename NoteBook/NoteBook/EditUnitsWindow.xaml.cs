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
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        private Notebook notebook;
        private IStockage storage;

        public EditUnitsWindow(Notebook notebook, IStockage storage)
        {
            this.notebook = notebook;
            this.storage = storage;
            InitializeComponent();
            DrawUnits();
        }

        /// <summary>
        /// (r)affiche les units de la liste LB_Units
        /// </summary>
        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            LB_units.Items.Clear();
            foreach (var item in list)
                LB_units.Items.Add(item);
        }

        /// <summary>
        /// (r)affiche les modules de la liste LB_Modules
        /// </summary>
        private void DrawModules()
        {
            LB_modules.Items.Clear(); // Correction : sortie de clean du if pour qu'il soit systématique
            if (LB_units.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                foreach (Module m in list)
                    LB_modules.Items.Add(m);
            }
        }

        /// <summary>
        /// appelle la fenetre de modification de l'unit séléctionné
        /// </summary>
        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if (LB_units.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    DrawUnits();
                    storage.Update(notebook);
                }
            }
        }

        /// <summary>
        /// appelle la fenetre de modification de l'unit séléctionné
        /// </summary>
        private void AddUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);
                if (third.ShowDialog() == true)
                {
                    notebook.AddUnit(newUnit);
                    storage.Update(notebook);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// supprime l'unit séléctionné
        /// </summary>
        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult confirm = MessageBox.Show("Etes-vous sûr de vouloir faire cela ?", "Confirmation", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                    if (LB_units.SelectedItem is Unit unit)
                    {
                        notebook.RemoveUnit(unit);
                        storage.Update(notebook);
                        DrawUnits();
                    }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// affiche les modules de l'unit séléctionné
        /// </summary>
        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        /// <summary>
        /// ajoute a l'unit séléctionné un module
        /// </summary>
        private void AddModule(object sender, RoutedEventArgs e)
        {
            try
            {
                Module newModule = new Module();
                EditElementWindow third = new EditElementWindow(newModule);
                if (third.ShowDialog() == true)
                {
                    if (LB_units.SelectedItem is Unit unit)
                    {
                        unit.AddModule(newModule);
                        storage.Update(notebook);
                        DrawModules();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// appelle la fenetre de modification du module séléctionné
        /// </summary>
        private void EditModule(object sender, MouseButtonEventArgs e)
        {
            if (LB_modules.SelectedItem is Module u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    DrawModules();
                    storage.Update(notebook);
                }
            }
            
        }

        /// <summary>
        /// supprime le module séléctionné
        /// </summary>
        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult confirm = MessageBox.Show("Etes-vous sûr de vouloir faire cela ?", "Confirmation", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                    if (LB_units.SelectedItem is Unit unit)
                        if (LB_modules.SelectedItem is Module module)
                        {
                            unit.RemoveModule(module);
                            DrawModules();
                        }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            storage.Update(notebook);
        }
    }
}
