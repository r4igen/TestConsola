using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Web;
using Hap = HtmlAgilityPack;
using IronOcr;



namespace SlnVisual
{
    public partial class Form1 : Form
    {
        static readonly HttpClient client = new HttpClient();
        static readonly WebClient oWebClient = new WebClient();
        static readonly Random oRandom = new Random();
        int Aletorio = 0;
        static byte[] Buffer;
        public Form1()
        {
            InitializeComponent();
        }

        static void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e) 
        {
            Buffer = e.Result;

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Aletorio = oRandom.Next(0, 9999);
            //MessageBox.Show(Aletorio.ToString());
            //string urlCaptcha = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsmulruc/captcha?accion=image";           
            string urlCaptcha = string.Format("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&nmagic={0}", Aletorio);
            try
            {
                HttpResponseMessage response = await client.GetAsync(urlCaptcha);
                response.EnsureSuccessStatusCode();
                Stream oStream = await response.Content.ReadAsStreamAsync();
                //byte[] oMemoryStream = await response.Content.ReadAsByteArrayAsync();
                Image oImage = Image.FromStream(oStream);                

                var oCr = new IronTesseract();
                using (var Input = new OcrInput(oImage))
                {
                    var Results = oCr.Read(Input);
                    txtCaptcha.Text = Results.Text.Trim();
                }

                pbImagen.Image = oImage;

                //var OcrEngine = new TesseractEngine("","eng", EngineMode.Default);
                //var img = Pix.LoadFromMemory(oMemoryStream);
                //var res = OcrEngine.Process(img);
                //txtCaptcha.Text = res.GetText();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
            
            

        }

        private async void btnConsultaRuc_Click(object sender, EventArgs e)
        {
            //https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaWeb.jsp
            try
            {
                //string urlConsulta = string.Format("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsmulruc/jrmS00Alias?accion=consManual&txtRuc=&selRuc={0}&codigoM={1}", txtRuc.Text, txtCaptcha.Text);
                //HttpResponseMessage response = await client.GetAsync(urlConsulta);
                //response.EnsureSuccessStatusCode();
                //string Respuesta = await response.Content.ReadAsStringAsync();
                //int ini;
                //ini = Respuesta.IndexOf("Baja de Archivo");
                //Respuesta = Respuesta.Remove(0, ini);
                //ini = Respuesta.IndexOf("</table>");
                //Respuesta = Respuesta.Remove(ini, Respuesta.Length - ini);
                //Respuesta = Respuesta.Replace(Environment.NewLine, "");
                //ini = Respuesta.IndexOf("https:");
                //Respuesta = Respuesta.Remove(0, ini);
                //ini = Respuesta.IndexOf("target=");
                //Respuesta = Respuesta.Remove(ini, Respuesta.Length - ini);
                //Respuesta = Respuesta.Replace('"', ' ');
                //Respuesta = Respuesta.Replace(" ", "");                
                //txtRpta.Text = Respuesta;
                //oWebClient.DownloadDataCompleted += DownloadDataCompleted;
                //oWebClient.DownloadDataAsync(new Uri(Respuesta));
                
                string urlConsulta = string.Format("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS03Alias?accion=consPorRuc&razSoc=&nroRuc={0}&nrodoc=&contexto=ti-it&modo=1&rbtnTipo=1&search1=10709854092&tipdoc=1&search2=&search3=&codigo={1}",txtRuc.Text, txtCaptcha.Text);
                HttpResponseMessage response = await client.GetAsync(urlConsulta);
                response.EnsureSuccessStatusCode();             
                string Respuesta = await response.Content.ReadAsStringAsync();
                //txtRpta.Text = Respuesta;
                Respuesta = HttpUtility.HtmlDecode(Respuesta);
                Respuesta = Respuesta.Replace(Environment.NewLine, "");
                Respuesta = Respuesta.Replace("\t", "");
                //Respuesta = Respuesta.Replace(" ", "");
                //Respuesta = Respuesta.Replace("  ", "");
                //Respuesta = Respuesta.Replace("   ", "");
                //Respuesta = Respuesta.Replace("    ", "");
                //Respuesta = Respuesta.Replace("     ", "");
                //Respuesta = Respuesta.Replace("      ", "");
                //Respuesta = Respuesta.Replace("       ", "");
                //Respuesta = Respuesta.Replace("        ", "");
                //Respuesta = Respuesta.Replace("         ", "");
                //Respuesta = Respuesta.Replace("          ", "");
                //int indice = Respuesta.IndexOf("<h4 class=\"list-group-item-heading\">RUC:</h4>");

                Hap.HtmlDocument doc = new Hap.HtmlDocument();
                doc.LoadHtml(Respuesta);

                var findClasses = doc.DocumentNode
                    .Descendants("div")
                    .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("row"));
                int i = 0;
                foreach (var item in findClasses)
                {
                    if (i == 0) 
                    {
                        i += 1;
                        continue;
                    }
                        
                    string dato = item.InnerText;
                    dato = dato.Replace(Environment.NewLine, "");
                    dato = dato.Replace("          ", "");
                    if (dato.Contains("Comprobantes de Pago c/aut. de impresión (F. 806 u 816):")) 
                    {
                        var arreglos = dato.Split(":");
                        var arreglos2 = arreglos[1].Split("        ");
                        foreach (var cadena in arreglos2)
                        {
                            if (!string.IsNullOrEmpty(cadena.Trim())) 
                            {
                                txtRpta.Text += string.Format("{0}:{1}".Trim(), arreglos[0].Trim(), cadena.Trim());
                                txtRpta.Text += Environment.NewLine;
                            }                                
                        }
                        continue;
                    }
                    txtRpta.Text += dato.Trim();
                    txtRpta.Text += Environment.NewLine;
                    
                }

                
                //Hap.HtmlDocument document = new Hap.HtmlDocument();
                //document.LoadHtml(Respuesta);

                //var htmlBody = document.DocumentNode.SelectSingleNode("//body");
                //var nodes = htmlBody.Elements("div");
                //foreach (var item in nodes)
                //{


                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
