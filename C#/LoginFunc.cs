using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPBLogin
{
    public class LoginFunc
    {
        public static bool Login(String Usuario, String Senha)
        {
            try
            {
                WebRequest request = WebRequest.Create("http://127.0.0.1/request.php?name=" + Usuario + "&senha=" + Senha);
                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = "application/x-www-form-urlencoded";
                StreamWriter rStream = new StreamWriter(request.GetRequestStream());
                rStream.Flush();
                rStream.Close();
                WebResponse response = request.GetResponse();
                StreamReader resReader = new StreamReader(response.GetResponseStream());
                string str = resReader.ReadToEnd();
                myLogger.Add(str);
                if (str.Contains("Login_OK"))
                {
                    myLogger.Add(Usuario + " Logou com sucesso!");
                    return true;
                    
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                myLogger.Add("Erro: " + ex);
                return false;
            }


        }
		private void button1_Click(object sender, EventArgs e)
        {
            if (LoginFunc.Login(textBox1.Text, textBox2.Text) == true)
            {
                MessageBox.Show("Dados corretos", "IPBLogin", MessageBoxButtons.OK, MessageBoxIcon.Info);
            }
            else
            {
                MessageBox.Show("Dados incorretos!", "IPBLogin", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
 
    }
}
