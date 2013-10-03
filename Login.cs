using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Net.Mail;


using System.Diagnostics;

using System.Web ;



namespace SPA
{
    
    public partial class Login : Form
    {
        BossAdd BossAdd;
         int a;
  //    Login2 Login2;
        public Login()
        {
          this.Width=315;
          this.Height = 132;
            InitializeComponent();
  
        }

        public void SendMessage(string strName, string strLog, string strText, string strPass, string outMail,
                          string strSubject)
        {
          try
          {
            string smtp = "";
            int port = 0;
            var mailCoding = new Dictionary<string, int>
            {
                {"gmail.com", 587},
                {"yandex.ru", 225},
                {"mail.ru", 235},
                {"list.ru", 254},
                {"inbox.ru", 215},
                {"bk.ru", 255}
            };

            // поиск нужного порта и smtp при отправке        
            foreach (var kvp in mailCoding.Where(kvp => strLog.IndexOf(kvp.Key, StringComparison.Ordinal) > -1))
            {
              smtp = "smtp." + kvp.Key;
              port = kvp.Value;
            }

            using (var mailMessage = new MailMessage(strName + " <" + strLog + ">", outMail))
            {
              mailMessage.Subject = strSubject; // тема письма
              mailMessage.Body = strText; // письмо
              mailMessage.IsBodyHtml = false; // без html, но можно включить
              using (var sc = new SmtpClient(smtp, port))
              {
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLog, strPass);
                sc.Send(mailMessage);
              }
            }
          }
          catch (Exception exception)
          {
            MessageBox.Show(exception.Message, "Ошибка");
          }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
          this.Width = 294;
          this.Height = 132;
          this.Opacity = 0.9;
          textBox3.Enabled = false;
          textBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Password")
            {
              textBox1.Clear();
              textBox1.Enabled = false;           
             // auth();
             // MessageBox.Show("Сейчас Вам на почту придет письмо с кодом доступа, введите его", "Внимание!");
             // Process prc = new Process();
            //  System.Diagnostics.Process.Start("https://mail.ru");
              this.Width=605;
              this.Height = 132;
              button1.Enabled = false;
              
                   
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
            
        }
        private void auth()
        {
          MailMessage message;
          SmtpClient client;
          System.Random random = new System.Random();
          int random_value = random.Next();
          a = random_value;
          random_value = 0;

          string outMail = "korolevseva@mail.ru";
          string strPass = "LoG9309=3";
          string strText = a.ToString();
          string strSubject = "Код активации";
          string strLog = "mail.spaforvip@gmail.com";
          string strName = "Service";
          SendMessage(strName, strLog, strText, strPass, outMail,
                            strSubject);
          

    }

      private void textBox2_TextChanged(object sender, EventArgs e)
      {
      
      }

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          this.Width = 294;
          this.Height = 132;
        }

        private void button4_Click(object sender, EventArgs e)
        {
          //if (textBox2.Text == a.ToString() && textBox2.Text!="0")
         // {
            a = 0; 
            BossAdd = new BossAdd();
            BossAdd.Owner = this;
            BossAdd.ShowDialog();           
            this.Hide();
         // }
         // else MessageBox.Show("Вы ввели неверный код активации", "Внимание!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
          button4.Enabled = true;
          this.Width = 605;
          this.Height = 132;
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }
    }
}
