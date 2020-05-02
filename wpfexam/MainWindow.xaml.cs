using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using wpfexam.DataModel;

namespace wpfexam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Receipt> receipts;
        public ObservableCollection<Country> countries;
        public ObservableCollection<Category> categories;
        public ReceiptContext db;
        public MainWindow()
        {
            InitializeComponent();
            using (db = new ReceiptContext())
            {
                receipts = new ObservableCollection<Receipt>();
                countries = new ObservableCollection<Country>();
                categories = new ObservableCollection<Category>();
                if (db.Countries.Count() <= 0)
                {
                    db.Countries.Add(new Country { Name = "Україна" });
                    db.Countries.Add(new Country { Name = "Китай" });
                    db.Countries.Add(new Country { Name = "Франція" });
                    db.Countries.Add(new Country { Name = "Італія" });
                    db.SaveChanges();
                }
                foreach (var item in db.Countries)
                {
                    countries.Add(item);
                }
                if (db.Categories.Count() <= 0)
                {
                    db.Categories.Add(new Category { Name = "Салати" });
                    db.Categories.Add(new Category { Name = "Перші страви" });
                    db.Categories.Add(new Category { Name = "Другі страви" });
                    db.Categories.Add(new Category { Name = "Напої" });
                    db.SaveChanges();
                }
                foreach (var item in db.Categories)
                {
                    categories.Add(item);
                }
                if(db.Receipts.Count() <=0)
                {
                    db.Receipts.Add(new Receipt { CategoryId = 1, CountryId = 1, Cooking = "test cooking 1", Ingredients = "test ingredients 1", Name = "test name 1" });
                    db.Receipts.Add(new Receipt { CategoryId = 2, CountryId = 2, Cooking = "test cooking 2", Ingredients = "test ingredients 2", Name = "test name 2" });
                    db.Receipts.Add(new Receipt { CategoryId = 3, CountryId = 3, Cooking = "test cooking 3", Ingredients = "test ingredients 3", Name = "test name 3" });
                }
                foreach (var item in db.Receipts)
                {
                    receipts.Add(item);
                }
                lbReceipts.SelectedIndex = 0;
                db.Receipts.Load();
                lbReceipts.ItemsSource = db.Receipts.Local.ToBindingList();
                cbCategories.ItemsSource = cbAddCategory.ItemsSource = categories;
                cbCategories.DataContext = cbAddCategory.ItemsSource = categories;
                cbCountries.ItemsSource = cbAddCountry.ItemsSource = countries;
                cbCountries.DataContext = cbAddCountry.ItemsSource = countries;
            }
            //receipts = new ObservableCollection<Receipt>()
            //{
            //    new Receipt{CategoryId = 1,CountryId = 1, Cooking = "test cooking 1", Ingredients = "test ingredients 1", Name = "test name 1"},
            //    new Receipt{CategoryId = 2,CountryId = 2, Cooking = "test cooking 2", Ingredients = "test ingredients 2", Name = "test name 2"},
            //    new Receipt{CategoryId = 3,CountryId = 3, Cooking = "test cooking 3", Ingredients = "test ingredients 3", Name = "test name 3"}
            //};
            //lbReceipts.ItemsSource = lbReceipts.ItemsSource = receipts;
            //lbReceipts.DataContext = lbReceipts.ItemsSource = receipts;
            //countries = new ObservableCollection<Country>()
            //{
            //    new Country { Name = "Україна" },
            //    new Country { Name = "Китай" },
            //    new Country { Name = "Франція" },
            //    new Country { Name = "Італія" }
            //};
            //cbCountries.ItemsSource = cbAddCountry.ItemsSource = countries;
            //cbCountries.DataContext = cbAddCountry.ItemsSource = countries;
            //categories = new ObservableCollection<Category>()
            //{
            //    new Category { Name = "Салати" },
            //    new Category { Name = "Перші страви" },
            //    new Category { Name = "Другі страви" },
            //    new Category { Name = "Напої" }
            //};
            //cbCategories.ItemsSource = cbAddCategory.ItemsSource = categories;
            //cbCategories.DataContext = cbAddCategory.ItemsSource = categories;

        }
    }
}
