using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Elelmiszer_nyilvantarto_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Storage> Keszlet;
        public StorageContext db;
        public MainWindow()
        {
            InitializeComponent();
            Keszlet = new ObservableCollection<Storage>();
            db = new StorageContext();
            //Init();
            ReflesShops();
            ListBox_Lista.ItemsSource = Keszlet;
            stackpanelInput.DataContext = Keszlet;
        }
        private void Init()
        {
            db.Storages.Add(new Storage("Kóla", 350));
            db.Storages.Add(new Storage("Gyümölcslé", 300));
            db.SaveChanges();
        }
        private void ReflesShops()
        {
            Keszlet.Clear();
            if (db.Storages.Any())
            {
                foreach (var item in db.Storages)
                {
                    Keszlet.Add((Storage)item);
                }
            }
            else
            {
                Keszlet.Add(new Storage());
            }
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Storage storage = ListBox_Lista.SelectedItem as Storage;
            if (storage.Name != null)
            {
                storage.Id = 0;
                db.Storages.Add(storage);
                db.SaveChanges();
                ReflesShops();
                ListBox_Lista.SelectedItem = storage;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Storage storage = ListBox_Lista.SelectedItem as Storage;
            if (storage.Name != null)
            {
                db.Storages.Update(storage);
                db.SaveChanges();
                ReflesShops();
                ListBox_Lista.SelectedItem = storage;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Storage shop = ListBox_Lista.SelectedItem as Storage;
            if (shop != null && shop.Id != 0)
            {
                int index = ListBox_Lista.SelectedIndex;
                db.Storages.Remove(shop);
                db.SaveChanges();
                ReflesShops();
                ListBox_Lista.SelectedIndex = index < ListBox_Lista.Items.Count ? index : ListBox_Lista.Items.Count - 1;
            }
        }

        private void CloseBuuton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            Storage storage = ListBox_Lista.SelectedItem as Storage;
            if (storage.Name != null)
            {
                storage.Number = storage.Number - 1;
                db.Storages.Update(storage);
                db.SaveChanges();
                ReflesShops();
                ListBox_Lista.SelectedItem = storage;
            }
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            Storage storage = ListBox_Lista.SelectedItem as Storage;
            if (storage.Name != null)
            {
                storage.Number = storage.Number + 1;
                db.Storages.Update(storage);
                db.SaveChanges();
                ReflesShops();
                ListBox_Lista.SelectedItem = storage;
            }
        }
    }
}
