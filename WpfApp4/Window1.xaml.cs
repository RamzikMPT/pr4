using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string a { get; set; }
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_ADD_NEW_TYPE_Click(object sender, RoutedEventArgs e)
        {
            
            a = NAME_NEW_TYPE.Text;
            //MainWindow.TypeList.Add(a);
            //DialogResult = true;
            //a = "";
            Close();
            //DialogResult = true;
            //RecordType.SetValue(a);
        }
    }
}
