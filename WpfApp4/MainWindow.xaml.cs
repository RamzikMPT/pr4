using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp4
{

    public partial class MainWindow : Window
    {
        List<Budget> filtered;
        public static List<Budget> budget = new List<Budget>();
        public static List<string> TypeList = new List<string>();
       
        int? note_index;
        public MainWindow(DeserAndSer deserAndSer)
        {
            InitializeComponent();
            
            budget = (List<Budget>)deserAndSer.FromJson<List<Budget>>("json.file");
            DatePicker.Text = DateTime.Today.ToString();
           
           List_by_date();
        }

        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            //RecordType.ItemsSource = TypeList;
            Window1 window1 = new Window1();
            window1.Show();


            var newItem = window1.a;
            TypeList.Add(newItem);
            RecordType.ItemsSource = TypeList;
            



        }
        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bool isIncome = false;
            int amount = Convert.ToInt32(AmountField.Text);
            if (amount > 0)
                isIncome = true;
            else
                amount *= -1;
            budget.Add(new Budget
            {
                Name = NameField.Text,
                RecordType = RecordType.Text,
                Amount = amount,
                IsIncome = isIncome,
                Date = (DateTime)DatePicker.SelectedDate
            });
            DeserAndSer.ToJson(budget, "json.file");
            UpdatePage();
        }

        private void UpdatePage()
        {
            throw new NotImplementedException();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            bool isInCome = false;
            int amount2 = Convert.ToInt32(AmountField.Text);
            if (amount2 > 0)
                isInCome = true;
            else
                amount2 = amount2 * (-1);
            budget[Convert.ToInt32(note_index)] = new Budget { name = NameField.Text, Name = NameField.Text, RecordType = RecordType.Text, Amount = amount2, Is_income = isInCome, Date = Convert.ToDateTime(DatePicker.Text) };
            DeserAndSer.ToJson(budget, "json.file");
            List_by_date();
            note_index = null;
            UpdatePage();
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            budget.RemoveAt(Convert.ToInt32(note_index));
            DeserAndSer.ToJson(budget, "json.file");
            UpdatePage();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePage();
        }

        private void List_by_date()
        {
            RecordType.ItemsSource = TypeList;
            filtered = budget.Where(n => n.Date.Date == Convert.ToDateTime(DatePicker.Text).Date).ToList();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = filtered;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RecordType.ItemsSource = TypeList;
            if (DataGrid.SelectedIndex >= 0)
            {
                var selected = filtered[DataGrid.SelectedIndex];
                var match = budget.Where(b => b.Date == selected.Date
                                            && b.Name == selected.Name
                                            && b.RecordType == selected.RecordType
                                            && b.Amount == selected.Amount)
                                  .FirstOrDefault();
                if (match != null)
                {
                    note_index = budget.IndexOf(match);
                    NameField.Text = match.Name;
                    RecordType.Text = match.RecordType;
                    AmountField.Text = match.Is_income ? Convert.ToString(match.Amount) : Convert.ToString(match.Amount * -1);
                }
            }
        }

        private string CountTotal()
{
    double totalSum = budget.Where(item => item.IsIncome).Sum(item => item.Amount)
                     - budget.Where(item => !item.IsIncome).Sum(item => item.Amount);
    return $"Итог: {totalSum}";
}

            public void Updatefage()
        {
            List_by_date();
            NameField.Text = "";
            RecordType.Text = "";
            AmountField.Text = "";
            CountOfFull.Content = Count_total();
        }

        private object Count_total()
        {
            throw new NotImplementedException();
        }
    }
}


