using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ConsolaConsultaRuc
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            string urlCaptcha = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsmulruc/captcha?accion=image";

            try
            {
                //HttpResponseMessage response = await client.GetAsync("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaWeb.jsp");
                //response.EnsureSuccessStatusCode();
                //string responseBody = await response.Content.ReadAsStringAsync();

                //HttpResponseMessage response2 = await client.GetAsync("https://www.google.com/recaptcha/api2/anchor?ar=1&k=6Ld0ZLsZAAAAAJb1R6KIom0xEN84iT6QJLWo8S9n&co=aHR0cHM6Ly9lLWNvbnN1bHRhcnVjLnN1bmF0LmdvYi5wZTo0NDM.&hl=es&v=jxFQ7RQ9s9HTGKeWcoa6UQdD&size=invisible&cb=upsz9nehi4gj");
                //response2.EnsureSuccessStatusCode();
                //string responseBody2 = await response2.Content.ReadAsStringAsync();

                //HttpResponseMessage response3 = await client.GetAsync("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsmulruc/captcha?accion=image");
                //response3.EnsureSuccessStatusCode();
                //string responseBody3 = await response3.Content.ReadAsStringAsync();

                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                //Console.WriteLine(responseBody);
                //Console.WriteLine(responseBody2);
                //Console.WriteLine(responseBody3);
                HttpResponseMessage response = await client.GetAsync(urlCaptcha);
                response.EnsureSuccessStatusCode();
                Stream oStream = await response.Content.ReadAsStreamAsync();
                Image oImage = Image.FromStream(oStream);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }
    }
}
