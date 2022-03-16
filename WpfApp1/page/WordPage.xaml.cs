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
using Word = Microsoft.Office.Interop.Word;

namespace WpfApp1.page
{
    /// <summary>
    /// Логика взаимодействия для WordPage.xaml
    /// </summary>
    public partial class WordPage : Page
    {
        public WordPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Product> WD = BaseClass.Base.Product.ToList();
            var aplication = new Word.Application();
            Word.Document document = aplication.Documents.Add();
            foreach (var product in WD)
            {
                Word.Paragraph paragraph = document.Paragraphs.Add();
                Word.Range range = paragraph.Range;
                range.Text = product.Title;
                paragraph.set_Style("Заголовок");
                range.InsertParagraphAfter();
                Word.Paragraph paragraphTable = document.Paragraphs.Add();
                Word.Range rangeTable = paragraph.Range;
                Word.Table table = document.Tables.Add(rangeTable, 2, 3);
                table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                Word.Range cellrange;
                cellrange = table.Cell(1, 1).Range;
                cellrange.Text = "Изображение";
                cellrange = table.Cell(1, 2).Range;
                cellrange.Text = "Тип продукции";
                cellrange = table.Cell(1, 3).Range;
                cellrange.Text = "Артикль";
                table.Rows[1].Range.Bold = 1;
                table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                string path = "/Resources/picture.png";
                cellrange = table.Cell(2, 1).Range;
                if (product.Image != null)
                {
                    Word.InlineShape image = cellrange.InlineShapes.AddPicture(AppDomain.CurrentDomain.BaseDirectory + "..\\.." + product.Image);
                    image.Width = image.Height = 50;
                    cellrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                else
                {
                    Word.InlineShape image = cellrange.InlineShapes.AddPicture(AppDomain.CurrentDomain.BaseDirectory + "..\\.." + path);
                    image.Width = image.Height = 40;
                    cellrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                cellrange = table.Cell(2, 2).Range;
                cellrange.Text = product.ProductType.Title;
                cellrange = table.Cell(2, 3).Range;
                cellrange.Text = product.ArticleNumber;

                
            }
            aplication.Visible = true;
          //  document.SaveAs2(@"X:\Test.docx");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Product> WD = BaseClass.Base.Product.ToList();
            var aplication = new Word.Application();
            Word.Document document = aplication.Documents.Add();
            foreach (var product in WD)
            {

            }
        }
    }
}
