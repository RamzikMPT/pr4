using System;

namespace WpfApp4
{
    public class Budget
    {
        public string name;
        public string record_type;
        public double amount;
        public bool is_income;
        public DateTime date;


        public string Name { get; set; }
        public string RecordType { get; set; }
        public double Amount { get; set; }
        public bool Is_income { get; set; }
        public DateTime Date { get; set; }
        public bool IsIncome { get; internal set; }
    }
}
