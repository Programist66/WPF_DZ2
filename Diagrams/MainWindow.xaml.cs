using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace Diagrams
{
    public partial class MainWindow : Window
    {
        private List<MonthSale> monthSales = new List<MonthSale>() { 
            new MonthSale(new DateTime(2006,12,25), 255.5), 
            new MonthSale(new DateTime(2006, 12, 15), 200), 
            new MonthSale(new DateTime(2006, 12, 5), 400.45)
        };
        public MainWindow()
        {           
            InitializeComponent();
            DrawDiagrams(monthSales);            
        }

        private void form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawDiagrams(monthSales);
        }

        private void DrawDiagrams(List<MonthSale> monthSales) 
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            List<Label> colomnDates = new List<Label>();
            List<Rectangle> colomns = new List<Rectangle>();
            List<Brush> brushes = new List<Brush>() { Brushes.Red, Brushes.Green, Brushes.Blue };

            for (int i = 0; i < monthSales.Count + 2; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                if (i == 0 || i == monthSales.Count + 1)
                {
                    grid.ColumnDefinitions[i].Width = new GridLength(0.5, GridUnitType.Star);
                }
            }

            int currentColor = 0;

            for (int i = 0; i < monthSales.Count; i++)
            {                
                colomnDates.Add(new Label());
                colomns.Add(new Rectangle());

                Grid.SetColumn(colomnDates[i], i+1);
                Grid.SetRow(colomnDates[i], 1);
                Grid.SetColumn(colomns[i], i+1);

                grid.Children.Add(colomnDates[i]);
                grid.Children.Add(colomns[i]);

                double maxHeightColomn = grid.ActualHeight * (grid.RowDefinitions[0].Height.Value - 0.1);
                double maxSale = monthSales.Max(sale => sale.Sale); 

                double widthColomn = grid.ActualWidth / grid.ColumnDefinitions.Count / 2.5;

                colomns[i].Height = maxHeightColomn * monthSales[i].Sale / maxSale;
                colomns[i].Width = widthColomn;
                colomns[i].Fill = brushes[currentColor];
                currentColor = (currentColor + 1) % brushes.Count;

                colomnDates[i].Content = monthSales[i].Date.ToShortDateString();

                colomns[i].VerticalAlignment = VerticalAlignment.Bottom;
                colomnDates[i].HorizontalAlignment = HorizontalAlignment.Center;
                colomns[i].HorizontalAlignment = HorizontalAlignment.Center;
                //if (i == 0)
                //{
                //    colomnDates[i].HorizontalAlignment = HorizontalAlignment.Right;
                //    colomns[i].HorizontalAlignment = HorizontalAlignment.Right;
                //}
                //else if(i == monthSales.Count-1)
                //{
                //    colomnDates[i].HorizontalAlignment = HorizontalAlignment.Left;
                //    colomns[i].HorizontalAlignment = HorizontalAlignment.Left;
                //}
                //else
                //{
                //    colomnDates[i].HorizontalAlignment = HorizontalAlignment.Center;
                //    colomns[i].HorizontalAlignment = HorizontalAlignment.Center;
                //}
                
            }
        }
    }
}