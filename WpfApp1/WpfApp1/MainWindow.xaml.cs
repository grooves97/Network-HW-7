using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
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


        private void Download(object url)
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(url as string, Guid.NewGuid().ToString());
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                finally
                {
                    MessageBox.Show("Загрузка началась");
                }
            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            Thread downloadThread = new Thread(Download);
            downloadThread.Start(urlTextBox.Text);
        }
    }
}
