
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            string sayi = textBox1.Text;        // sayinin textboxtan alınması ve gerekli cevrimlerin yapılması
            string kurus = string.Empty;
            string lira = string.Empty;
            double uzunlukKontrol=Convert.ToDouble(textBox1.Text);
            if(uzunlukKontrol<=99999.99)//uzunluk kontrol
            {
                if (sayi.Contains(","))
                {
                    kurus = textBox1.Text.Split(',')[1];
                    lira = textBox1.Text.Split(',')[0];
                    label1.Text += sayiYaz(lira);
                    label1.Text += " TL ";
                    label1.Text += sayiYaz(kurus);
                    label1.Text += " Kr";

                }
                else if (sayi.Contains("."))
                {
                    kurus = textBox1.Text.Split('.')[1];
                    lira = textBox1.Text.Split('.')[0];
                    label1.Text += sayiYaz(lira);
                    label1.Text += " TL ";
                    label1.Text += sayiYaz(kurus);
                    label1.Text += " Kr";


                }

                else
                {
                    lira = textBox1.Text;
                    label1.Text += sayiYaz(lira);
                    label1.Text += " TL ";
            
                }



            }
            else
            {
                MessageBox.Show("Lüften İstenilen Aralıkta Sayı Ve Sadece '.'  ',' Kullanınız! ");
            }

            
          

           
          
        }
        private  string sayiYaz(string sayi)//sayının üclü olarak bolunmesi
        {
          string yazi=string.Empty;
            char birler1 = new char();
            char birler2 = new char();
            char onlar1 = new char();
            char onlar2 = new char();
            char yüzler1 = new char();
            char yüzler2 = new char();


            if (sayi.Length >= 1) //3lu bolunen sayıların ilgili basamaklara atanması
            {
                birler1 = sayi[sayi.Length - 1];

            }
            if (sayi.Length >= 2)
            {
                onlar1 = sayi[sayi.Length - 2];

            }
            if (sayi.Length >= 3)
            {

                yüzler1 = sayi[sayi.Length - 3];

            }
            if (sayi.Length >= 4)
            {
                birler2 = sayi[sayi.Length - 4];

            }
            if (sayi.Length >= 5)
            {
                onlar2 = sayi[sayi.Length - 5];

            }
            if (sayi.Length >= 6)
            {

                yüzler2 = sayi[sayi.Length - 6];

            }

            if (sayi.Length >= 4)//bir bin yazılmasını engellemek icin
            {
                string toplam2 = yüzler2.ToString() + onlar2.ToString() + birler2.ToString();

                if ((onlar2 != '\0' || yüzler2 != '\0') || ((birler2 != '0' && birler2 != '1') && yüzler2 == '\0' && onlar2 == '\0'))
                {

                    yazi += üclü(toplam2);

                }
                yazi += "Bin";
            }
            string toplam1 = yüzler1.ToString() + onlar1.ToString() + birler1.ToString();
            yazi += üclü(toplam1);
            return yazi;


        }


        private string üclü(string sayi)
        {
            string sonuc=string.Empty;
            
            Dictionary<string, string> birlerbas = new Dictionary<string, string>(); //birler basamağı icin sözlük tanımlanması
            Dictionary<string, string> onlarbas = new Dictionary<string, string>(); //onlar basamağı icin sözlük tanımlanması
            birlerbas.Add("0", "");
            birlerbas.Add("1", " Bir ");
            birlerbas.Add("2", " İki ");
            birlerbas.Add("3", " Üç ");
            birlerbas.Add("4", " Dört ");
            birlerbas.Add("5", " Beş ");
            birlerbas.Add("6", " Altı ");
            birlerbas.Add("7", " Yedi ");
            birlerbas.Add("8", " Sekiz ");
            birlerbas.Add("9", " Dokuz ");
            onlarbas.Add("0", "");
            onlarbas.Add("1", " On ");
            onlarbas.Add("2", " Yirmi ");
            onlarbas.Add("3", " Otuz ");
            onlarbas.Add("4", " Kırk ");
            onlarbas.Add("5", " Elli ");
            onlarbas.Add("6", " Altmış ");
            onlarbas.Add("7", " Yetmiş ");
            onlarbas.Add("8", " Seksen ");
            onlarbas.Add("9", " Doksan ");
            if (sayi.Length >= 3)//yüzler basamagı bulunması
            {
                char yüzler = sayi[sayi.Length - 3];
                if (yüzler != '1'&&yüzler!='\0' && yüzler != '0')

                {

                    sonuc += birlerbas[yüzler.ToString()]+"Yüz";
                    
                }
                else if(yüzler =='1'&&yüzler!='\0')
                {
                    sonuc += "Yüz";
                }
               

            }

            if (sayi.Length >= 2)//onlar basamagı bulunması
            {
                char onlar = sayi[sayi.Length - 2];
                if(onlar!='\0')
                {
                    sonuc += onlarbas[onlar.ToString()];
                }

              


            }
            if (sayi.Length >= 1)//birler basamagı bulunması
            {
                char birler = sayi[sayi.Length - 1];
                if(birler!='\0')
                {
                    sonuc += birlerbas[birler.ToString()];

                }
                

            }
            return sonuc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
        }
    }
}
