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

namespace DrugsForYouWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime firstDayOfDrugs = datePckr.SelectedDate.Value;
            int age = AgeCalculator.CalculateAge(firstDayOfDrugs);

            DateTime lastDayOfDrugs = firstDayOfDrugs.AddDays(20);//таблетки принимаем 1+20 дней

            DateTime cycleLastDay = firstDayOfDrugs.AddDays(27);// переменная для записи последнего дня цикла
            while (DateTime.Today > cycleLastDay)
            {
                firstDayOfDrugs = firstDayOfDrugs.AddDays(28);//переписываем дату первого дня приема таблеток
                lastDayOfDrugs = lastDayOfDrugs.AddDays(28);//переписываем дату последнего дня приема таблеток
                cycleLastDay = cycleLastDay.AddDays(28);//переписываем дату последнего дня приема таблеток
            }
            //Console.WriteLine(firstDayOfDrugs);
            //Console.WriteLine(lastDayOfDrugs);
            //Console.WriteLine(cycleLastDay);

            if (DateTime.Today >= firstDayOfDrugs && DateTime.Today <= lastDayOfDrugs)
            {
                MessageBox.Show("You need to eat some pills");             
            }
            else 
            {
                MessageBox.Show("You don't");
            }
        }
    }
}
