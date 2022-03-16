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



namespace WpfApp1.page
{
    /// <summary>
    /// Логика взаимодействия для MaskPage.xaml
    /// </summary>
    public partial class MaskPage : Page
    {
        List<Product> ProductsStart = BaseClass.Base.Product.ToList();
      
        public MaskPage()
        {
            InitializeComponent();
            LVService.ItemsSource = ProductsStart;
            CBSort.Items.Add("наименование ");
            CBSort.Items.Add("номер цеха ");
            CBSort.Items.Add("минимальная стоимость");
            CBSort.SelectedIndex = 0;           
            List<ProductType> GB = BaseClass.Base.ProductType.ToList();
            CBFilter2.Items.Add("Все типы");  
            for (int i = 0; i < GB.Count(); i++)  
            {
                CBFilter2.Items.Add(GB[i].Title);
            }
            CBFilter2.SelectedIndex = 0;
        }

        private void TBMaterial(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<ProductMaterial> TC = BaseClass.Base.ProductMaterial.Where(x => x.ProductID == index).ToList();
            string str = "Материалы: ";
            foreach (ProductMaterial item in TC)
            {
                str += item.Material.Title + ", ";
            }
            tb.Text = str.Substring(0, str.Length-2);
        }

        List<Product> MaskFilter;
        private void filter()
        {     
            if (CBFilter2.SelectedIndex != 0) 
            {
                MaskFilter = ProductsStart.Where(x => x.ProductTypeID == CBFilter2.SelectedIndex).ToList();
            }
            else
            {
                MaskFilter = ProductsStart;  
            }
            if (!string.IsNullOrWhiteSpace(TBFilter.Text))
            {
                MaskFilter = MaskFilter.Where(x => x.Title.ToLower().Contains(TBFilter.Text)).ToList();
            }
            LVService.ItemsSource = MaskFilter;       
        }

        private void BTUp(object sender, RoutedEventArgs e)
        {
            if (CBSort.SelectedIndex == 0)
            {
                MaskFilter.Sort((x, y) => x.Title.CompareTo(y.Title));
                LVService.Items.Refresh();
            }
            if (CBSort.SelectedIndex == 1)
            {
                MaskFilter.Sort((x, y) => x.ProductionWorkshopNumber.CompareTo(y.ProductionWorkshopNumber));
                LVService.Items.Refresh();
            }
            if (CBSort.SelectedIndex == 2)
            {
                MaskFilter.Sort((x, y) => x.MinCostForAgent.CompareTo(y.MinCostForAgent));
                LVService.Items.Refresh();
            }
        }

        private void BTDown(object sender, RoutedEventArgs e)
        {
            if (CBSort.SelectedIndex == 0)
            {
                MaskFilter.Sort((x, y) => x.Title.CompareTo(y.Title));
                MaskFilter.Reverse();
                LVService.Items.Refresh();
            }
            if (CBSort.SelectedIndex == 1)
            {
                MaskFilter.Sort((x, y) => x.ProductionWorkshopNumber.CompareTo(y.ProductionWorkshopNumber));
                MaskFilter.Reverse();
                LVService.Items.Refresh();
            }
            if (CBSort.SelectedIndex == 2)
            {
                MaskFilter.Sort((x, y) => x.MinCostForAgent.CompareTo(y.MinCostForAgent));
                MaskFilter.Reverse();
                LVService.Items.Refresh();
            }
        }
        private void TBFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
          filter();
        }  
        private void CBFilter2_SelectionChanged(object sender, SelectionChangedEventArgs e)// фильтрация
        {
            filter();
        }
    

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            Product ProductUpdate = BaseClass.Base.Product.FirstOrDefault(y => y.ID == ind);
         
            FrameClass.FrameMain.Navigate(new UpdatePage(ProductUpdate));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new UpdatePage());
        }

        private void TBCost(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<ProductMaterial> PM = BaseClass.Base.ProductMaterial.Where(x => x.ProductID == index).ToList();
            int cost = 0;
            foreach(ProductMaterial item in PM)
            {
                cost += (int)item.Material.Cost;
            }
            tb.Text = cost + " руб";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new WordPage());

        }
    }
   
}
