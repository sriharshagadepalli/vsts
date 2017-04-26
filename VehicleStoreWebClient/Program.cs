using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace VehicleStoreWebClient
{
    public class VehicleInfo
    {
        public Guid Id { get; set; }
        public string Trim { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public System.Drawing.Color Color { get; set; }
        public string VIN { get; set; }
        public int SafetyRating { get; set; }
        public int EPAGreenScore { get; set; }
        public int Axles { get; set; }
    }

    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("vehicles");
                if (response.IsSuccessStatusCode)
                {
                    //VehicleInfo item = await response.Content.ReadAsAsync<VehicleInfo>();
                    //Console.WriteLine("{0}\t{1}\t{2}", item.Make, item.Model, item.Trim);
                }

                //// HTTP POST
                //var gizmo = new VehicleInfo() { Name = "Gizmo", Price = 100, Category = "Widget" };
                //response = await client.PostAsJsonAsync("api/products", gizmo);
                //if (response.IsSuccessStatusCode)
                //{
                //    Uri gizmoUrl = response.Headers.Location;

                //    // HTTP PUT
                //    gizmo.Price = 80;   // Update price
                //    response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

                //    // HTTP DELETE
                //    response = await client.DeleteAsync(gizmoUrl);
                //}
            }
        }
    }
}