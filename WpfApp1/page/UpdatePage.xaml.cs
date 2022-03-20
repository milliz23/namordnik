using Microsoft.Win32;
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
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        string path;  
        Product product=new Product();
        bool flag;
        List<ProductType> PT = BaseClass.Base.ProductType.ToList();
        public UpdatePage()
        {
            InitializeComponent();
            flag = true;         
            CBType.Items.Add("Все типы");
            for (int i = 0; i < PT.Count; i++)
            {
                CBType.Items.Add(PT[i].Title);
            }
            CBType.SelectedIndex = 0;         
        }
        public UpdatePage(Product ProductUpdate)
        {
            InitializeComponent();
            product = ProductUpdate;
            TBTitle.Text = ProductUpdate.Title;
            CBType.Items.Add("Все типы");
            for(int i=0; i<PT.Count;i++)
            {
                CBType.Items.Add(PT[i].Title);
            }
            CBType.SelectedIndex = 0;
            CBType.SelectedIndex = (int)ProductUpdate.ProductTypeID;
         
            TBartik.Text = ProductUpdate.ArticleNumber;
            if (path != null)
            {
                BitmapImage BI = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                Imagepr.Source = BI;
            }
            TBperson.Text = Convert.ToString(ProductUpdate.ProductionPersonCount);
            TBWorkshonNumb.Text = Convert.ToString(ProductUpdate.ProductionWorkshopNumber);
            TBmincost.Text = Convert.ToString(ProductUpdate.MinCostForAgent);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int type = 0;
                if(CBType.SelectedIndex != 0)
                {
                    type = CBType.SelectedIndex;
                }
                product.Title = TBTitle.Text;
                product.ArticleNumber = TBartik.Text;
                product.ProductTypeID = type;
                product.ProductionPersonCount = Convert.ToInt32(TBperson.Text);
                product.ProductionWorkshopNumber = Convert.ToInt32(TBWorkshonNumb.Text);
                product.MinCostForAgent = Convert.ToInt32(TBmincost.Text);
                product.Image = path;
                if (flag == true)
                {
                    BaseClass.Base.Product.Add(product);
                }
                BaseClass.Base.SaveChanges();
             
             
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Данные записаны");
                FrameClass.FrameMain.Navigate(new MaskPage());
            }
            catch
            {
                MessageBox.Show("Данные не записаны");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog(); 
            OFD.ShowDialog();  
            path = OFD.FileName;  
            int n = path.IndexOf("products");  
            path = "\\"+path.Substring(n);
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            int ind = product.ID;
            Product ProductDelete = BaseClass.Base.Product.FirstOrDefault(y => y.ID == ind);
            BaseClass.Base.Product.Remove(ProductDelete);
            BaseClass.Base.SaveChanges();
            FrameClass.FrameMain.Navigate(new MaskPage());
            MessageBox.Show("Запись удалена");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new MaskPage());
        }
    }
}
