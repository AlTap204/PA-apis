using System;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ApiCallerCodigo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(textBox1.Text);
                label2.Text = "";
                using (HttpClient httpClient = new HttpClient())
                {
                    try
                    {
                        String url = $"http://localhost/apis/colonias.php?codigo={codigo}";
                        //MessageBox.Show(url);
                        HttpResponseMessage respuesta = httpClient.GetAsync(url).Result;
                        String json = respuesta.Content.ReadAsStringAsync().Result;
                        //MessageBox.Show(respuesta.ToString());
                        var response = JsonConvert.DeserializeObject<MyApiResponse>(json);
                        //MessageBox.Show(String.Join(" ",response.data));
                        comboBox1.DataSource = response.data;
                    }
                    catch (Exception error)
                    {
                        label2.Text = $"Error al llamar API {error}";
                    }
                }
            }
            catch (Exception)
            {
                label2.Text = "Error: El codigo postal no es un numero entero";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    class MyApiResponse
    {
        public float data
        {
            get; set;
        }
        public float status
        {
            get; set;
        }
    }
}
