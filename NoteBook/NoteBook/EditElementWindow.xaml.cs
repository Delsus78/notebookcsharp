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
    /// Logique d'interaction pour EditElementWindow.xaml
    /// </summary>
    public partial class EditElementWindow : Window
    {

        private PedagogicalElement element;

        public EditElementWindow(PedagogicalElement elt)
        {
            InitializeComponent();
            this.element = elt;
            TB_name.Text = elt.Name;
            TB_Coef.Text = elt.Coef.ToString();
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                element.Name = TB_name.Text;
                element.Coef = (float)Convert.ToDouble(TB_Coef.Text);
                DialogResult = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
