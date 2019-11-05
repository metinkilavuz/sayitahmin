using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayiTahminOyunu1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int life;
        int time;
        int yourGuessNumber = 0;
        int rndNumber = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            life = 3;
            time = 60;
            yourGuessNumber = 0;
            lblLife.Text = life.ToString();
            //lblTime.Text = time.ToString();
            lblStatus.Text = "Meteor dünyaya hızla yaklaşıyor. Bunu durdurmak için şifre sayısını doğru tahmin etmelisin.";
            rndNumber = randomNumber(100, 500);
            timer1.Start();
        }

        public int randomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        void lifeControl(int param)
        {
            if (param <= 0)
            {
                gameOver(0);
            }
            else
            {
                lblLife.Text = param.ToString();
            }
        }

        void gameOver(int param)
        {
            //lblStatus.Text = "Oyun Bitti";
            timer1.Stop();

            Form3 frms = new Form3();
            frms.Show();
            frms.gameOverScreen(param);
            this.Hide();

        }

        void guessNumber(int param)
        {
            yourGuessNumber++;


            if (param > rndNumber)
            {
                lblStatus.Text = "Tahmin ettiğiniz sayi şifre olarak belirlenen sayının üzerinde. ";
                lifeControl(life--);
            }
            else if (param < rndNumber)
            {
                lblStatus.Text = "Tahmin ettiğiniz sayi şifre olarak belirlenen sayının altında. ";
                lifeControl(life--);
            }
            else
            {
                lblStatus.Text = $"Tebrikler şifre olarak belirlenen sayıyı {yourGuessNumber} tahminde buldunuz.";
                gameOver(1);
            }
        }


        private void btnGuess_Click(object sender, EventArgs e)
        {

            guessNumber(Convert.ToInt32(txtGuess.Text));

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

            lblStatus.Text = $"Şifre olarak belirlenen sayi {rndNumber - randomNumber(1, 50)} ile {rndNumber + randomNumber(1, 50)} arasındadır. ";
            btnHelp.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
           // lblTime.Text = time.ToString();
            pctMeteor.Left += 1;
            pctMeteor.Top += 1;
            if (pctMeteor.Top > 230)
            {
                gameOver(0);
            }
        }

        private void txtGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

    }
}
