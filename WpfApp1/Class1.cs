using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class Product
    {
        public string PartalClass
        {
            get
            {
                return ProductType.Title + " | " + Title;
            }

         }
        public int Cost
        {
            get
            {
                return (int)MinCostForAgent;
            }

        }
        public SolidColorBrush CountColor
        {
            get
            {
               if(MinCostForAgent>2000)
               {
                    return Brushes.LightCoral;
               }
                else return Brushes.Transparent ;
            }
        }
    }
}
  

