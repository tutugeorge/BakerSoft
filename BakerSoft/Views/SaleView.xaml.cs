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

namespace GSTBill.Views
{
    /// <summary>
    /// Interaction logic for SaleView.xaml
    /// </summary>
    public partial class SaleView : UserControl
    {
        List<string> nameList;
        public SaleView()
        {
            InitializeComponent();
            nameList = new List<string>
            {
                "AAAA",
                "BBBB",
                "CCCC"
            };
            txtAuto.TextChanged += new TextChangedEventHandler(txtAuto_TextChanged);
        }

        private void txtAuto_TextChanged(object sender, TextChangedEventArgs e)
        {
            string typedText = txtAuto.Text;
            List<string> autoList = new List<string>();
            autoList.Clear();

            foreach (string item in nameList)
            {
                if (!string.IsNullOrEmpty(txtAuto.Text))
                {
                    if (item.StartsWith(typedText))
                    {
                        autoList.Add(item);
                    }
                }

            }

            if (autoList.Count > 0)
            {
                lbSuggestion.ItemsSource = autoList;
                lbSuggestion.Visibility = Visibility.Visible;
            }
            else if (txtAuto.Text.Equals(""))
            {
                lbSuggestion.Visibility = Visibility.Collapsed;
                lbSuggestion.ItemsSource = null;
            }
            else
            {
                lbSuggestion.Visibility = Visibility.Collapsed;
                lbSuggestion.ItemsSource = null;
            }
        }

        private void lbSuggestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbSuggestion.ItemsSource != null)
            {
                lbSuggestion.Visibility = Visibility.Collapsed;
                txtAuto.TextChanged -= new TextChangedEventHandler(txtAuto_TextChanged);
                if (lbSuggestion.SelectedIndex != -1)
                {
                    txtAuto.Text = lbSuggestion.SelectedItem.ToString();
                }
                txtAuto.TextChanged += new TextChangedEventHandler(txtAuto_TextChanged);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtBxPId.Focus();
        }
    }
}
