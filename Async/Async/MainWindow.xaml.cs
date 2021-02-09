using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //DownloadHtmlAsync("http://msdn.microsoft.com");

            // throws compliation error when adding await to this line
            // because Button_Click was not declared async
            // you can only use the await keyword in an async method
            //var html = await GetHtmlAsync("http://msdn.microsoft.com");

            // OR

            // when you call GetHtmlAsync the control immediately returns
            // getHtmlTask, so we have a task object that represents
            // the state of that asynchronous operation
            var getHtmlTask = GetHtmlAsync("http://msdn.microsoft.com");

            // You don't have to always await right after an
            // asynchronous operation, instead you can do work in between
            // that is NOT dependent on the result of that async operation
            MessageBox.Show("Waiting for the task to complete");

            // next, this line tells the runtime the rest of this method
            // cannot be executed until this operation is completed
            var html = await getHtmlTask;
            MessageBox.Show(html.Substring(0, 10));
            // So the control immediately returns to the UI,
            // which is why the UI is responsive
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            var webClient = new WebClient();

            return await webClient.DownloadStringTaskAsync(url);
        }

        public string GetHtml(string url)
        {
            var webClient = new WebClient();

            return webClient.DownloadString(url);
        }

        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            // await is a marker for the compiler
            // when the compiler sees await, it knows the operation
            // might be costly and take a bit of time
            // in that case instead of blocking this thread, its going
            // to return this control immediately to the caller of
            // DownloadHtmlAsync
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"c:\bin\result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }

        // Non async
        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"c:\bin\result.html"))
            {
                streamWriter.Write(html);
            }
        }
    }
}
