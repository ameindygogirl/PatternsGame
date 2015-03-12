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

namespace DesignPatternsGame
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        ItemList items;
        public Inventory(ItemList items)
        {
            this.items = items;
            InitializeComponent();

            itemListBox.ItemsSource = this.items;
            itemListBox.DisplayMemberPath = "name";
        }
    }
}
