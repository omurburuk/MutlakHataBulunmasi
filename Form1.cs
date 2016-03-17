using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sayısalcozumlememutlakhata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double Epslon;
        private void button1_Click(object sender, EventArgs e)
        {
            int carpixkare = Convert.ToInt16(textBox1.Text);
            int carpix= Convert.ToInt16(textBox2.Text);
            int arti = Convert.ToInt16(textBox3.Text);

            int xtenkucuk =Convert.ToInt16( textBox6.Text);
            int xtenbuyuk =Convert.ToInt16(textBox4.Text);
            yaklastir(carpixkare, carpix,arti, xtenkucuk, xtenbuyuk);
            Epslon = Convert.ToDouble(textBox5.Text);
        }

        int Xy;
        int FXa;
        string cikti = "";

        public void yaklastir(int carpixkare, int carpix, int arti, float xtenkucuk, float xtenbuyuk)
        {
            //    a-)
            // F (Xa)
            int xkareyitut=1;
            float FXa = fonksiyon(carpixkare, carpix, arti, xtenkucuk);
            xkareyitut=1;
            // F ( Xu)
             float FXu = fonksiyon(carpixkare, carpix, arti, xtenbuyuk);
            // Xy= alt+ust/2
            while (true)  //  a-)  b-) c-) d-) ..... sonsuza kadar  döngüyle her seferinde daha çok yaklaş .. 
                {
            float Xy=(xtenbuyuk+xtenkucuk)/2;
            if ( FXa*FXu<0){
                // Bu aralıkta kök vardır
                // Xy
                // F(Xy)
                    float FXy = fonksiyon(carpixkare, carpix, arti, Xy);
                    if (FXy * FXa > 0)
                    {
                        xtenkucuk = Xy;
                    }
                    else
                    {
                        xtenbuyuk = Xy;
                    }
                    float mutlaklı;
                    if (xtenkucuk - xtenbuyuk < 0)
                    {
                        mutlaklı = -1 * (xtenbuyuk - xtenkucuk);
                    }
                    else
                    {
                        mutlaklı = (xtenbuyuk - xtenkucuk);

                    }
                    if ((FXa - FXu) < Epslon || mutlaklı < Epslon)
                    {
                        DialogResult result = MessageBox.Show("Durmak İstermisiniz?" , " Kökümüz :>> "+ Xy +" << 'dir" ,
  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        cikti += "  Kök :" + Xy + " 'dir.\n";
                        cikti += "  x alt değeri :" + xtenkucuk + " 'dir.\n";
                        cikti += "  x üst değeri :" + xtenbuyuk + " 'dir.\n";
                        if (result == DialogResult.Yes)
                        {
                            Bitir(Xy);
                            MessageBox.Show(" Kök :" + Xy + " 'dir.");
                            break;
                        }
                        else if (result == DialogResult.No)
                        {
                            continue;
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            Xy= (xtenbuyuk + xtenkucuk) / 2;
                            Bitir(Xy);
                        }
                        MessageBox.Show(" Kök " + Xy + " 'dir.");
                        continue;
                    }
                } 
            else 
            {
                MessageBox.Show(" Bu aralıkta Kök Yoktur ");
            }
            }
            label13.Text = cikti;
        }
        float cevap;
         float fonksiyonsonucu;
        public float fonksiyon(int carpixkare,int carpix, int arti,float xdegeri)
        {
            float xkareyitut = 1;
            for (int i = 0; i < 2; i++)
            {
                xkareyitut *= xdegeri;
            }
            fonksiyonsonucu = xkareyitut * carpixkare + carpix * xdegeri + arti;
            return fonksiyonsonucu;
        }
        public void Bitir(float kök){
            label11.Text = Convert.ToString(kök);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
