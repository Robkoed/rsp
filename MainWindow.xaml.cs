using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Threading;

namespace RPS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] images = new string[3] { "/paper2.png", "/rock.reverse.png", "/scessor.reverse.png" };
        Random rnd = new Random();

        int person = 0;
        int computer = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        /*   public void Window_Load()
           {
               Person.Source = new BitmapImage(new Uri(@"/images/rock.png"));
               Computer.Source = new BitmapImage(new Uri(@"/images/rock.reverse.png"));
           }*/

        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ComputersAnswer();
        }
        public void Start_Click(object sender, EventArgs e)
        {
            ComputersAnswer();
            WhoWin();
        }

        private void rock_Click(object sender, RoutedEventArgs e)
        {
            Person.Source = new BitmapImage(new Uri(@"\rock.png", UriKind.Relative));
        }

        private void sesor_Click(object sender, RoutedEventArgs e)
        {
            Person.Source = new BitmapImage(new Uri(@"/scessor.png", UriKind.Relative));
        }

        private void paper_Click(object sender, RoutedEventArgs e)
        {
             Person.Source = new BitmapImage(new Uri(@"/paper.png", UriKind.Relative));
        }

        private void ComputersAnswer()
        {

            Computer.Source = new BitmapImage(new Uri(images[rnd.Next(0, 3)], UriKind.Relative));

        }

        private void WhoWin()
        {
            string s = Computer.Source.ToString();
                if (Computer.Source.ToString() == "pack://application:,,,/scessor.reverse.png" && Person.Source.ToString() == @"pack://application:,,,/rock.png"
                    || Computer.Source.ToString() == "pack://application:,,,/rock.reverse.png" && Person.Source.ToString() == "pack://application:,,,/paper.png"
                    || Computer.Source.ToString() == "pack://application:,,,/paper2.png" && Person.Source.ToString() == "pack://application:,,,/scessor.png")
                {
                    person++;
                }
                else if (Computer.Source.ToString() == "pack://application:,,,/scessor.reverse.png" && Person.Source.ToString() == "pack://application:,,,/paper.png"
                || Computer.Source.ToString() == "pack://application:,,,/rock.reverse.png" && Person.Source.ToString() == "pack://application:,,,/scessor.png"
                || Computer.Source.ToString() == "pack://application:,,,/paper2.png" && Person.Source.ToString() == "pack://application:,,,/rock.png")
                {
                    computer++;
                }
                Score.Text = person + ":" + computer;
        }
    }
}