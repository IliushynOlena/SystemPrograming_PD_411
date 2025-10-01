namespace _03_01_TestThreads
{
    internal class Program
    {
        static void InifinityLoop()
        {
            Console.WriteLine( "Thread has been started");
            int u = 1;
            while (true)
            {
                int a = 5;
                int b = a;
                int c = a+b;
                new Random().Next(500);
                Console.WriteLine("------ " + u + "---------");
                u++;
            }
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey();
                //Thread th = new Thread(InifinityLoop);
                //th.Start(); 
                InifinityLoop();



            } while (input.Key != ConsoleKey.Escape);
            
        }
    }
}
