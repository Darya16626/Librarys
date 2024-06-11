using System.Net;

namespace FunctionalLib
{
    public class ImmitationWork
    {
        public static void ImmitateLongFileBlock(string file, int milisecond)
        {
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                Thread.Sleep(milisecond);
            }
        }

        public static HttpStatusCode ImmitateserverResponce(int milisecond = 0)
        {
            Thread.Sleep(milisecond);
            var statuses = Enum.GetValues(typeof(HttpStatusCode)).Cast<HttpStatusCode>().ToArray();
            Random rand = new Random();
            return statuses[rand.Next(0, statuses.Length)];
        }
    }
}
