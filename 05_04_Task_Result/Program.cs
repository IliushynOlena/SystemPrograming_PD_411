using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_Task_Result
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            ////////////////// Factorial
            //
            Task<int> task1 = new Task<int>(() => Factorial(5));

            Task<int> task3 = new Task<int>(() => Factorial1(5, 15, "Hello", 5)); // 5! = 1 * 2 * 3 * 4 * 5 = 120
                                                                                  //Task<int> task3 = new Task<int>(Function); // 5! = 1 * 2 * 3 * 4 * 5 = 120
            task3.Start();
            Console.WriteLine(task3.Result);
            //Task<int> task2 = new Task<int>(TestMethod); // 5! = 1 * 2 * 3 * 4 * 5 = 120
            task1.Start();
            // task1.Wait();  //freeze

            Console.WriteLine(task1.Result); //task1.Result == task1.Wait();  freeze


            Task<int> t = task1.ContinueWith(Summ);
            Console.WriteLine(t.Result);


            //task1.Wait(); // freez
            Console.WriteLine($"Фактоіал числа 5 = {task1.Result}");// freez

            ////////////////////// Book
            Task<Book> task2 = new Task<Book>(() =>
            {
                return new Book { Title = "Harry Potter", Author = "Royling" };
            });

            //string separator = new string('-', 10);
            //Task<Book> task2 = new Task<Book>(
            //    delegate (object obj)
            //    {
            //        Book book = obj as Book;
            //        book.Title = "Deal Souls";
            //        book.Author = "Gogol";
            //        return book;
            //    },
            //    new Book());

            task2.Start();

            Book b = task2.Result;  // ожидаем получение результата
            Console.WriteLine($"Назва книги: {b.Title}, автор: {b.Author}");
            //Book b2 = task2.Result;
            //Console.WriteLine($"Назва книги: {b2.Title}, автор: {b2.Author}");
            //Console.ReadLine();
        }
        //static int  Function()
        //{

        //    //return Factorial(5, 15, "Hello"); ;

        //}
        static int Factorial(int x)//
        {

            int result = 1;


            for (int i = 1; i <= x; i++)
            {
                result *= i;//5! = 1*2*3*4*5 = 120
            }

            return result;
        }
        static int Factorial1(int x, int a, string str, int b)//
        {
            Console.WriteLine("A = " + a);
            Console.WriteLine("B = " + b);
            Console.WriteLine(str);
            int result = 1;


            for (int i = 1; i <= x; i++)
            {
                result *= i;//5! = 1*2*3*4*5 = 120
            }

            return result + a + b;
        }
        static int Summ(Task<int> prevTask)
        {
            int summ = prevTask.Result * 2;
            Console.WriteLine(summ);
            return summ;
        }
    }


    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} by {Author}";
        }
    }
}