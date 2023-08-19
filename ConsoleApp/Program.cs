using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Islem<T>
    {
        public T Sayi1 { get; set; }
        public T Sayi2 { get; set; }

        public Islem(T sayi1, T sayi2)
        {
            Sayi1 = sayi1;
            Sayi2 = sayi2;
        }

        public Islem() { }

        public string Topla()
        {
            return Sayi1.ToString() + " + " + Sayi2.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Islem<double> islem1 = new Islem<double>();
            islem1.Sayi1 = 10.4; islem1.Sayi2 = 20.5;

            Islem<int> islem2 = new Islem<int>();
            islem2.Sayi1 = 10; islem2.Sayi2 = 20;

            Islem<decimal> islem3= new Islem<decimal>(2.5m , 4.3m);

            Console.WriteLine(islem1.Topla());
            Console.WriteLine(islem2.Topla());

            Console.WriteLine(islem3.Topla());

        }
    }
}
