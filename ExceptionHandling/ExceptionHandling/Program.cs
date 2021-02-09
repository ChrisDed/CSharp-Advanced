using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var api = new YoutubeApi();
                var videos = api.GetVideos("Chris");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void TryCatchHandling()
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"c:\bin\file.zip");
                //var calc = new Calculator();
                //var result = calc.Divide(5, 0);
                // StreamReader is used for reading any streams of data
                // (files, network, etc)
                var content = streamReader.ReadToEnd();
                throw new Exception("Oops");
            }
            // Create catch blocks by most specific to most generic
            catch (Exception e)
            {
                Console.WriteLine("Sorry an unexpected error occured");
            }
            // in .NET there are classes that access unmanaged resources
            // unmanaged resources = resources not managed by the CLR
            // there is no garbage collection applied to them
            // Ex: FileHandles, Database connections, Network connections
            // Graphic handles
            // in situations like this, we need a manual cleanup
            // any class that uses unmanaged resources is expected
            // to implement an interface called IDisposable
            finally
            {
                if (streamReader != null)
                    streamReader.Dispose();
            }

            // Make the above code shorter by the using keyword

            try
            {
                // finally used under the hood to dispose the unmanaged
                // resource, in this case a stream
                using (var streamReader2 = new StreamReader(@"c:\file.zip"))
                {
                    var content = streamReader2.ReadToEnd();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Unexpected error.");
            }
        }
    }
}
