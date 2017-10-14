using CopyTableToServer.Process;

namespace CopyTableToServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var process = new CheckAndCopy())
            {
                process.CopyData();
            }
        }
    }
}
