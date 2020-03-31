using System;
using System.Windows;
using System.IO;

namespace DrugsForYouWPF
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try//пытаемся читать дату из календаря, в случае успеха переписываем файл
            {
                DateTime firstDay = datePckr.SelectedDate.Value;
                File.WriteAllText(@"Date.txt", Convert.ToString(firstDay));
            }
            catch (System.InvalidOperationException)//в противном случае читаем дату из файла
            {
                //string text1 = File.ReadAllText(@"Date.txt");
                //DateTime firstDay = Convert.ToDateTime(text1);
                //throw;
            }

            string text2 = File.ReadAllText(@"Date.txt");
            DateTime firstDayOfDrugs = Convert.ToDateTime(text2);



            ////if (Convert.ToString(datePckr.SelectedDate.Value) == "null")

            ////если юзер не ввел дату из календаря
            //{
            //    //читаем дату из файла
            //    string text1 = File.ReadAllText(@"Date.txt");
            //    DateTime firstDay = Convert.ToDateTime(text1);
            //}
            //else
            ////если дата в календаре введена, то обновляем дату в файле
            //{
            //    DateTime firstDay = datePckr.SelectedDate.Value;
            //    // записываем дату в файл
            //    File.WriteAllText(@"Date.txt", Convert.ToString(firstDay));
            //}

            //string text2 = File.ReadAllText(@"Date.txt");
            //DateTime firstDayOfDrugs = Convert.ToDateTime(text2);


            int age = AgeCalculator.CalculateAge(firstDayOfDrugs);

            DateTime lastDayOfDrugs = firstDayOfDrugs.AddDays(20);//таблетки принимаем 1+20 дней

            DateTime cycleLastDay = firstDayOfDrugs.AddDays(27);// переменная для записи последнего дня цикла
            while (DateTime.Today > cycleLastDay)
            {
                firstDayOfDrugs = firstDayOfDrugs.AddDays(28);//переписываем дату первого дня приема таблеток
                lastDayOfDrugs = lastDayOfDrugs.AddDays(28);//переписываем дату последнего дня приема таблеток
                cycleLastDay = cycleLastDay.AddDays(28);//переписываем дату последнего дня приема таблеток
            }
       
            if (DateTime.Today >= firstDayOfDrugs && DateTime.Today <= lastDayOfDrugs) //если мы внутри цикла приема таблеток, то выводим сообщение
            {
                MessageBox.Show("Примите таблетку");             
            }
            else 
            {
                MessageBox.Show("Сегодня таблетки принимать не нужно");
            }
        }
    }
}
