using System.IO;
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

namespace _06_01_AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();    
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task<int> task = Task.Run(GenerateNumber);
            //int value =  task.Result;//freeze
            //task.Wait();//freeze
            // list.Items.Add(value);

            //done
            //done
            //async - allow method to use await keyword
            //await - wait task without freeze
            //done
            //done
            //int value = await task;
            //list.Items.Add(value);
            //MessageBox.Show("Completed");

            list.Items.Add(await GenerateNumberAsync());
           //File.Copy(Path.Combine(Path.GetDirectoryName()
            
        }

        int GenerateNumber()
        {
            Thread.Sleep(random.Next(5000));
            
            return random.Next(1000);
        }
        Task<int> GenerateNumberAsync()
        {
             return Task.Run(()=>
             {
                 Thread.Sleep(random.Next(5000));
                 return random.Next(1000);
             });
           
        }
    }
}