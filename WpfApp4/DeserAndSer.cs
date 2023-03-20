using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp4
{
    public class DeserAndSer
    {




        private readonly string fileName = "data.json";

        private DeserAndSer GetDeserAndSer(DeserAndSer deserAndSer)
        {
            return deserAndSer;
        }

        private void Rfgfgfgfg(object sender, RoutedEventArgs e, DeserAndSer deserAndSer)
        {
            var data = deserAndSer.FromJson<MyData>(fileName);
            
        }

        public object FromJson<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public void ToJson(object sender, RoutedEventArgs e)
        {
            var data = new MyData();
            
            DeserAndSer.ToJson(data, fileName);
        }

        public  void ToJson(MyData data, string fileName)
        {
            throw new NotImplementedException();
        }

        internal static void ToJson(List<Budget> budget, string v)
        {
            throw new NotImplementedException();
        }
    }

    public class MyData
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}




