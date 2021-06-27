using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace bramy
{
    public partial class Form1 : Form
    {

        string[] lines = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Data\", "profile.txt"));
        string[] lines1 = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Data\", "plaskowniki.txt"));
        string[] linesdefault = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Data\", "default.txt"));
        string[] przeslo = new string[50];
        string[] furtka = new string[50];
        string[] bramaprzesuwna = new string[50];
        string[] bramaskrzydlowa = new string[50];

        string[] przeslocomboboxindex = new string[20];
        string[] furtkacomboboxindex = new string[20];
        string[] bramaprzesuwnacomboboxindex = new string[20];
        string[] bramaskrzydlowacomboboxindex = new string[20];


        string[,] arr = new string[1000, 9];
        string[,] arr1 = new string[1000, 12];

        int tab = 1;
        int currenttab = 1;
        int radio1 = 1;
        int radio2 = 2;

        double kpr = 0, kpl = 0;
        double m1, m2, m3, m4;
        double mp1, mp2, mp3;
        double p1 = 0, p2 = 0, p3 = 0, p4 = 0;
        double pp1 = 0, pp2 = 0, pp3 = 0;
        double total, rob, dod, cie;
        double dodmasa = 0, dodpow = 0;
        double cpr1, cpr2, cpr3, cpr4, cpl1, cpl2, cpl3;
        double woz, kie;
        double k44, k88;
        double kpr1 = 0, kpr3 = 0, kpr4 = 0, kpr2 = 0, kpl1 = 0, kpl2 = 0, kpl3 = 0;
        double c44, c88;
        double d44, d88;
        double cenac = 0;
        double cenam = 0;

        double masap44 = 1.82;
        double masap88 = 10.04;
        bool left = false;
        bool cena = true;
        bool cenapl = true;



        //update method
        double z1, z2;
        double mn = 0;
        double mb = 0;
        double pow = 0;
        double pow44 = 0;
        double pow88 = 0;
        double mnp = 0;
        double mbp = 0;
        double powp = 0;
        double kosztm = 0;
        double kosztc = 0;
        double m44 = 0, m88 = 0;

        //masa brutto
        //dlugosc brutto
        double l1 = 0;
        double l2 = 0;
        double l3 = 0;
        double l4 = 0;
        //dlughosc netto
        double ln1 = 0;
        double ln2 = 0;
        double ln3 = 0;
        double ln4 = 0;
        //to samo dla profili
        double lp1 = 0;
        double lp2 = 0;
        double lp3 = 0;
        double lnp1 = 0;
        double lnp2 = 0;
        double lnp3 = 0;

        public Form1()
        {

            InitializeComponent();

            textBox9.Text = linesdefault[0];
            textBoxp9.Text = linesdefault[1];
            cm.Text = linesdefault[2];
            cc.Text = linesdefault[3];


            textBox1.TextChanged += removenans;
            textBox2.TextChanged += removenans;
            textBox3.TextChanged += removenans;
            textBox4.TextChanged += removenans;
            textBox5.TextChanged += removenans;
            textBox6.TextChanged += removenans;
            textBox7.TextChanged += removenans;
            textBox8.TextChanged += removenans;

            textBoxp1.TextChanged += removenans;
            textBoxp2.TextChanged += removenans;
            textBoxp3.TextChanged += removenans;
            textBoxp4.TextChanged += removenans;
            textBoxp5.TextChanged += removenans;
            textBoxp6.TextChanged += removenans;

            textBoxp9.TextChanged += removenans;
            textBox9.TextChanged += removenans;

            cm.TextChanged += removenans;
            cc.TextChanged += removenans;

            robocizna.TextChanged += removenans;
            dodatkicena.TextChanged += removenans;
            ciecie.TextChanged += removenans;

            zawias1.TextChanged += removenans;
            zawias2.TextChanged += removenans;

            cp44.TextChanged += removenans;
            cpr88.TextChanged += removenans;
            lp44.TextChanged += removenans;
            lp88.TextChanged += removenans;
            wozki.TextChanged += removenans;
            kieszen.TextChanged += removenans;

            cenap1.TextChanged += removenans;
            cenap2.TextChanged += removenans;
            cenap3.TextChanged += removenans;
            cenap4.TextChanged += removenans;
            cenapl1.TextChanged += removenans;
            cenapl2.TextChanged += removenans;
            cenapl3.TextChanged += removenans;
            dodatkimasa.TextChanged += removenans;
            dodatkipow.TextChanged += removenans;

            //walutowe
            textBoxp9.Leave += currency;
            textBox9.Leave += currency;

            robocizna.Leave += currency;
            dodatkicena.Leave += currency;
            ciecie.Leave += currency;

            cm.Leave += currency;
            cc.Leave += currency;

            zawias1.Leave += currency;
            zawias2.Leave += currency;

            cp44.Leave += currency;
            cpr88.Leave += currency;
            wozki.Leave += currency;
            kieszen.Leave += currency;

            cenap1.Leave += currency;
            cenap2.Leave += currency;
            cenap3.Leave += currency;
            cenap4.Leave += currency;
            cenapl1.Leave += currency;
            cenapl2.Leave += currency;
            cenapl3.Leave += currency;




            cm.Enabled = false;
            lm.Enabled = false;
            km.Enabled = false;
            cc.Enabled = false;
            lc.Enabled = false;
            kc.Enabled = false;
            btnp.Enabled = false;
            btnbp.Visible = false;
            btnbs.Visible = false;
            panelfurtki.Visible = false;
            panelbramy.Visible = false;
            panelwozki.Visible = false;

            panelkoszt.Visible = false;
            panelkosztpl.Visible = false;
            panelcena.Visible = true;
            btncena.Enabled = false;
            panelcenapl.Visible = true;
            btncenapl.Enabled = false;

            panel1.Height = 95;
            panel10.Height = 95;
            int i;
            string s;
            for (i = 0; i < lines.Length; i++)
            {
                s = lines[i];

                arr[i, 0] = s.Substring(0, (s.IndexOf('x'))).Trim();
                arr[i, 1] = s.Substring(s.IndexOf('x') + 1, s.IndexOf('\t') - 2).Trim();
                string[] arr2 = s.Split('\t');
                arr[i, 2] = arr2[1];
                arr[i, 3] = arr2[2];
                arr[i, 4] = arr2[3];
                arr[i, 5] = arr2[4];
                arr[i, 6] = arr2[5];
                arr[i, 7] = arr2[6];
                arr[i, 8] = arr2[7];
            }

            for (i = 0; i < lines1.Length; i++)
            {
                s = lines1[i];

                //arr1[i, 0] = s.Substring(0, (s.IndexOf('x'))).Trim();

                string[] arr2p = s.Split('\t');

                for (int j = 0; j <= 11; j++)
                {
                    arr1[i, j] = arr2p[j];
                }

            }

            for (int n = 0; n < 50; n++)
            {
                przeslo[n] = "";
                bramaprzesuwna[n] = "";
                bramaskrzydlowa[n] = "";
                furtka[n] = "";

            }
            for (int n = 0; n < 20; n++)
            {
                przeslocomboboxindex[n] = null;
                bramaprzesuwnacomboboxindex[n] = null;
                bramaskrzydlowacomboboxindex[n] = null;
                furtkacomboboxindex[n] = null;
            }
        }

        private void removenans(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(left));
            if (!left)
            {
                bool ok = true;
               // MessageBox.Show((sender as TextBox).Text);

                if ((sender as TextBox).Text.Length > 0)
                {
                    for (int i = 0; i < (sender as TextBox).Text.Length; i++)
                    {
                        char c = (sender as TextBox).Text[i];
                        int n = c;

                        if (n == 44) //sprawdzenie czy w tekście jest przecinek
                        {
                            for (int j = i + 1; j < (sender as TextBox).Text.Length; j++)
                            {
                                char c1 = (sender as TextBox).Text[j];
                                int n1 = c1;
                                if (n1 == 44)
                                {
                                    ok = false;
                                    if ((sender as TextBox).Text.Length - 1 == i) // jeśli ostatni znak nie jest cyfrą tekst zostaje przycięty o jeden znak
                                        (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, i);
                                    else // jeśli znak w środku nie jest cyfrą zostaje zsumowany tekst przed i za znakiem
                                        (sender as TextBox).Text = (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, i) + (sender as TextBox).Text.Substring(i + 1, (sender as TextBox).Text.Length - i - 1);

                                    (sender as TextBox).SelectionStart = i; // ustawienie kursora na ostatniej pozycji
                                }
                            }
                        }

                        if (n > 57 || n < 48 && n != 44) //sprawdzenie czy w tekście jest inny znak niż cyfra lub przecinek
                        {
                            ok = false;
                            if ((sender as TextBox).Text.Length - 1 == i) // jeśli ostatni znak nie jest cyfrą tekst zostaje przycięty o jeden znak
                                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, i);
                            else // jeśli znak w środku nie jest cyfrą zostaje zsumowany tekst przed i za znakiem
                                (sender as TextBox).Text = (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, i) + (sender as TextBox).Text.Substring(i + 1, (sender as TextBox).Text.Length - i - 1);

                            (sender as TextBox).SelectionStart = i; // ustawienie kursora na ostatniej pozycji
                        }
                    }
                }
                if (ok)
                {
                    update();
                }
            }
            left = false;
            //MessageBox.Show(Convert.ToString(m88));
        }
        private void currency(object sender, EventArgs e)
        {
            //removenans(sender as TextBox, e);
            left = true;

            if ((sender as TextBox).Text != "")
            {
                double val = Double.Parse((sender as TextBox).Text, NumberStyles.Currency);
                (sender as TextBox).Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", val);
            }

            update();
        }
        private void clear()
        {
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            comboBox5.SelectedItem = null;
            comboBox6.SelectedItem = null;
            comboBox7.SelectedItem = null;
            comboBox8.SelectedItem = null;
            comboBox9.SelectedItem = null;
            comboBox10.SelectedItem = null;
            comboBox11.SelectedItem = null;
            comboBox12.SelectedItem = null;
            comboBoxp1.SelectedItem = null;
            comboBoxp2.SelectedItem = null;
            comboBoxp11.SelectedItem = null;
            comboBoxp21.SelectedItem = null;
            comboBoxp12.SelectedItem = null;
            comboBoxp22.SelectedItem = null;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBoxp1.Text = "";
            textBoxp2.Text = "";
            textBoxp3.Text = "";
            textBoxp4.Text = "";
            textBoxp5.Text = "";
            textBoxp6.Text = "";
            lm.Text = "";
            km.Text = "";
            lc.Text = "";
            kc.Text = "";
            robocizna.Text = "";
            dodatkicena.Text = "";
            dodatkimasa.Text = "";
            dodatkipow.Text = "";
            ciecie.Text = "";
            zawias1.Text = "";
            zawias2.Text = "";
            cp44.Text = "";
            cpr88.Text = "";
            lp44.Text = "";
            lp88.Text = "";
            mp44.Text = "";
            kp44.Text = "";
            mp88.Text = "";
            kp88.Text = "";
            wozki.Text = "";
            kieszen.Text = "";
            masa1.Text = "";
            masa2.Text = "";
            masa3.Text = "";
            masa4.Text = "";
            masap1.Text = "";
            masap2.Text = "";
            masap3.Text = "";
            masab.Text = "";
            masan.Text = "";
            masabp.Text = "";
            masanp.Text = "";
            kosztpl.Text = "";
            kosztpr.Text = "";

            radioButton1.Checked = true;
            radioButton5.Checked = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;


            colour();
        }

        private void price()
        {
            //profile
            if (cenap1.Text != "")
            {
                cpr1 = Double.Parse(cenap1.Text, NumberStyles.Currency);
            }
            else
            {
                if (textBox9.Text != "")
                    cpr1 = Double.Parse(textBox9.Text, NumberStyles.Currency);
                else
                    cpr1 = 0;
            }

            if (cenap2.Text != "")
            {
                cpr2 = Double.Parse(cenap2.Text, NumberStyles.Currency);
            }
            else
            {
                if (textBox9.Text != "")
                    cpr2 = Double.Parse(textBox9.Text, NumberStyles.Currency);
                else
                    cpr2 = 0;
            }

            if (cenap3.Text != "")
            {
                cpr3 = Double.Parse(cenap3.Text, NumberStyles.Currency);
            }
            else
            {
                if (textBox9.Text != "")
                    cpr3 = Double.Parse(textBox9.Text, NumberStyles.Currency);
                else
                    cpr3 = 0;
            }

            if (cenap4.Text != "")
            {
                cpr4 = Double.Parse(cenap4.Text, NumberStyles.Currency);
            }
            else
            {
                if (textBox9.Text != "")
                    cpr4 = Double.Parse(textBox9.Text, NumberStyles.Currency);
                else
                    cpr4 = 0;
            }

            switch (radio1)
            {
                case 1:
                    kpr = cpr1 * m1 * l1;
                    break;

                case 2:
                    kpr = cpr1 * m1 * l1 + cpr2 * m2 * l2;
                    break;

                case 3:
                    kpr = cpr1 * m1 * l1 + cpr2 * m2 * l2 + cpr3 * m3 * l3;
                    break;

                case 4:
                    kpr = cpr1 * m1 * l1 + cpr2 * m2 * l2 + cpr3 * m3 * l3 + cpr4 * m4 * l4;
                    break;
            }
            kosztpr.Text = string.Format("{0:c}", kpr);


            if (cena == false)
            {
                if (textBox9.Text != "")
                {
                    kpr1 = cpr1 * m1 * l1;
                    kpr2 = cpr2 * m2 * l2;
                    kpr3 = cpr3 * m3 * l3;
                    kpr4 = cpr4 * m4 * l4;
                }
                else
                {
                    kpr1 = 0;
                    kpr2 = 0;
                    kpr3 = 0;
                    kpr4 = 0;
                }
                
                lblkpr1.Text = string.Format("{0:c}", kpr1);
                lblkpr2.Text = string.Format("{0:c}", kpr2);
                lblkpr3.Text = string.Format("{0:c}", kpr3);
                lblkpr4.Text = string.Format("{0:c}", kpr4);                   
            }


            //plaskowniki

            if (cenapl1.Text != "")
            {
                cpl1 = Double.Parse(cenapl1.Text, NumberStyles.Currency);
            }
            else
            {
                if (textBoxp9.Text != "")
                    cpr1 = Double.Parse(textBoxp9.Text, NumberStyles.Currency);
                else
                    cpr1 = 0;
            }

            if (cenapl2.Text != "")
            {
                cpl2 = Double.Parse(cenapl2.Text, NumberStyles.Currency);
            }
            else
            {
                if (textBoxp9.Text != "")
                    cpl2 = Double.Parse(textBoxp9.Text, NumberStyles.Currency);
                else
                    cpl2 = 0;
            }

            if (cenapl3.Text != "")
            {
                cpl3 = Double.Parse(cenapl3.Text, NumberStyles.Currency);
            }
            else
            {
                if (textBoxp9.Text != "")
                    cpl3 = Double.Parse(textBoxp9.Text, NumberStyles.Currency);
                else
                    cpl3 = 0;
            }

            switch (radio2)
            {
                case 1:
                    kpl = cpl1 * mp1 * lp1;
                    break;

                case 2:
                    kpl = cpl1 * mp1 * lp1 + cpl2 * mp2 * lp2;
                    break;

                case 3:
                    kpl = cpl1 * mp1 * lp1 + cpl2 * mp2 * lp2 + cpl3 * mp3 * lp3;
                    break;
            }
            kosztpl.Text = string.Format("{0:c}", kpl);

            if (cenapl == false)
            {
                if (textBoxp9.Text != "")
                {
                    kpl1 = cpl1 * mp1 * lp1;
                    kpl2 = cpl2 * mp2 * lp2;
                    kpl3 = cpl3 * mp3 * lp3;
                }
                else
                {
                    kpl1 = 0;
                    kpl2 = 0;
                    kpl3 = 0;
                }

                lblkpl1.Text = string.Format("{0:c}", kpl1);
                lblkpl2.Text = string.Format("{0:c}", kpl2);
                lblkpl3.Text = string.Format("{0:c}", kpl3);
            }
        }
        private void update()
        {
            //dlugosc netto

            l1 = (textBox1.Text != "") ? Convert.ToDouble(textBox1.Text) : 0;
            l2 = (textBox3.Text != "") ? Convert.ToDouble(textBox3.Text) : 0;
            l3 = (textBox5.Text != "") ? Convert.ToDouble(textBox5.Text) : 0;
            l4 = (textBox7.Text != "") ? Convert.ToDouble(textBox7.Text) : 0;

            //dlugosc netto

            ln1 = (textBox2.Text != "") ? Convert.ToDouble(textBox2.Text) : 0;
            ln2 = (textBox4.Text != "") ? Convert.ToDouble(textBox4.Text) : 0;
            ln3 = (textBox6.Text != "") ? Convert.ToDouble(textBox6.Text) : 0;
            ln4 = (textBox8.Text != "") ? Convert.ToDouble(textBox8.Text) : 0;

            //dla plskownikow
            //dlugosc brutto

            lp1 = (textBoxp1.Text != "") ? Convert.ToDouble(textBoxp1.Text) : 0;
            lp2 = (textBoxp3.Text != "") ? Convert.ToDouble(textBoxp3.Text) : 0;
            lp3 = (textBoxp5.Text != "") ? Convert.ToDouble(textBoxp5.Text) : 0;

            //dlugosc netto

            lnp1 = (textBoxp2.Text != "") ? Convert.ToDouble(textBoxp2.Text) : 0;
            lnp2 = (textBoxp4.Text != "") ? Convert.ToDouble(textBoxp4.Text) : 0;
            lnp3 = (textBoxp6.Text != "") ? Convert.ToDouble(textBoxp6.Text) : 0;


            //obliczenia profili
            switch(radio1)
            {

                case 1:
            
                if (masa1.Text != "brak podanego profilu")
                {
                    mb = m1 * l1;
                    masab.Text = Convert.ToString(mb);
                    masab.ForeColor = System.Drawing.Color.Black;

                    mn = m1 * ln1;
                    masan.Text = Convert.ToString(mn);
                    masan.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    pow = p1 * ln1;

                }
                else
                {
                    masab.ForeColor = System.Drawing.Color.Red;
                    masan.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;
                }

                    break;

                case 2:
             
                if (masa1.Text != "brak podanego profilu" && masa2.Text != "brak podanego profilu")
                {
                    mb = m1 * l1 + m2 * l2;
                    masab.Text = Convert.ToString(mb);
                    masab.ForeColor = System.Drawing.Color.Black;


                    mn = m1 * ln1 + m2 * ln2;
                    masan.Text = Convert.ToString(mn);
                    masan.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    pow = p1 * ln1 + p2 * ln2;

                }
                else
                {
                    masab.ForeColor = System.Drawing.Color.Red;
                    masan.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;

                }
            
                    break;

                case 3:
                    
                if (masa1.Text != "brak podanego profilu" && masa2.Text != "brak podanego profilu" && masa3.Text != "brak podanego profilu")
                {
                    mb = m1 * l1 + m2 * l2 + m3 * l3;
                    masab.Text = Convert.ToString(mb);
                    masab.ForeColor = System.Drawing.Color.Black;

                    mn = m1 * ln1 + m2 * ln2 + m3 * ln3;
                    masan.Text = Convert.ToString(mn);
                    masan.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    pow = p1 * ln1 + p2 * ln2 + p3 * ln3;

                }
                else
                {
                    masab.ForeColor = System.Drawing.Color.Red;
                    masan.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;

                }
                    break;

                case 4:
            
                if (masa1.Text != "brak podanego profilu" && masa2.Text != "brak podanego profilu" && masa3.Text != "brak podanego profilu" && masa4.Text != "brak podanego profilu")
                {
                    mb = m1 * l1 + m2 * l2 + m3 * l3 + m4 * l4;
                    masab.Text = Convert.ToString(mb);
                    masab.ForeColor = System.Drawing.Color.Black;

                    mn = m1 * ln1 + m2 * ln2 + m3 * ln3 + m4 * ln4;
                    masan.Text = Convert.ToString(mn);
                    masan.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    pow = p1 * ln1 + p2 * ln2 + p3 * ln3 + p4 * ln4;


                }
                else
                {
                    masab.ForeColor = System.Drawing.Color.Red;
                    masan.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;
                }
                    break;
            }
           

            //dla plaskowników

            switch(radio2)
            {
                case 1:

                if (masap1.Text != "brak podanego profilu")
                {

                    mbp = mp1 * lp1;
                    masabp.Text = Convert.ToString(mbp);
                    masabp.ForeColor = System.Drawing.Color.Black;

                    mnp = mp1 * lnp1;
                    masanp.Text = Convert.ToString(mnp);
                    masanp.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    powp = pp1 * lnp1;

                }
                else
                {
                    masabp.ForeColor = System.Drawing.Color.Red;
                    masanp.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;

                }
                    break;

                case 2:  
                    
                if (masap1.Text != "brak podanego profilu" && masap2.Text != "brak podanego profilu")
                {
                    mbp = mp1 * lp1 + mp2 * lp2;
                    masabp.Text = Convert.ToString(mbp);
                    masabp.ForeColor = System.Drawing.Color.Black;

                    mnp = mp1 * lnp1 + mp2 * lnp2;
                    masanp.Text = Convert.ToString(mnp);
                    masanp.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    powp = pp1 * lnp1 + pp2 * lnp2;

                }
                else
                {
                    masabp.ForeColor = System.Drawing.Color.Red;
                    masanp.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;
                }
                    break;

                case 3:

                if (masap1.Text != "brak podanego profilu" && masap2.Text != "brak podanego profilu" && masap3.Text != "brak podanego profilu")
                {
                    mbp = mp1 * lp1 + mp2 * lp2 + mp3 * lp3;
                    masabp.Text = Convert.ToString(mbp);
                    masabp.ForeColor = System.Drawing.Color.Black;

                    mnp = mp1 * lnp1 + mp2 * lnp2 + mp3 * lnp3;
                    masanp.Text = Convert.ToString(mnp);
                    masanp.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    powp = pp1 * lnp1 + pp2 * lnp2 + pp3 * lnp3;

                }
                else
                {
                    masabp.ForeColor = System.Drawing.Color.Red;
                    masanp.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;
                }
                    break;
            }


            price();



            if (robocizna.Text != "")
                rob = Double.Parse(robocizna.Text, NumberStyles.Currency);
            else
                rob = 0;


            if (dodatkicena.Text != "")
                dod = Double.Parse(dodatkicena.Text, NumberStyles.Currency);
            else
                dod = 0;


            if (ciecie.Text != "")
                cie = Double.Parse(ciecie.Text, NumberStyles.Currency);
            else
                cie = 0;


            if (cenap1.Text != "")
                cpr1 = Double.Parse(cenap1.Text, NumberStyles.Currency);
            else
                cpr1 = 0;

            if (dodatkimasa.Text != "")
                dodmasa = Double.Parse(dodatkimasa.Text, NumberStyles.Currency);
            else
                dodmasa = 0;

            if (dodatkipow.Text != "")
                dodpow = Double.Parse(dodatkipow.Text, NumberStyles.Currency);
            else
                dodpow = 0;

            //malowanie
            if (checkBox2.Checked)
            {
                if (cm.Text != "")
                {
                    cenam = Double.Parse(cm.Text, NumberStyles.Currency);
                }

                if (lp44.Text != "")
                    d44 = Convert.ToDouble(lp44.Text);
                else
                    d44 = 0;

                if (lp88.Text != "")
                    d88 = Convert.ToDouble(lp88.Text);
                else
                    d88 = 0;


                pow44 = d44 * 240;
                pow88 = d88 * 240;
                kosztm = cenam * (pow + powp + pow44 + pow88 + dodpow * 1000) / 1000;
                lm.Text = Convert.ToString((pow + powp + pow44 + pow88 + dodpow * 1000) / 1000);
                km.Text = string.Format("{0:c}", kosztm);
                // label31.Text = Convert.ToString(pow);
            }
            else
            {
                lm.Text = "0";
                km.Text = "0";
                pow44 = 0;
                pow88 = 0;
                kosztm = 0;

            }

            //cynkowanie
            if (checkBox1.Checked)
            {
                if (cc.Text != "")
                    cenac = Double.Parse(cc.Text, NumberStyles.Currency);

                if (lp44.Text != "")
                {
                    d44 = Convert.ToDouble(lp44.Text);
                }
                else
                    d44 = 0;

                if (lp88.Text != "")
                {
                    d88 = Convert.ToDouble(lp88.Text);
                }
                else
                    d88 = 0;

                m44 = masap44 * d44;
                m88 = masap88 * d88;

                kosztc = cenac * (mn + mnp + m44 + m88 + dodmasa);
                lc.Text = Convert.ToString(mn + mnp + m44 + m88 + dodmasa);
                kc.Text = string.Format("{0:c}", kosztc);
            }
            else
            {
                lc.Text = "0";
                kc.Text = "0";
                m44 = 0;
                m88 = 0;
                kosztc = 0;
            }


            switch (tab)
            {
                case 1:

                    total = kosztm + kosztc + kpr + kpl + dod + cie + rob;

                    break;

                case 2:

                    if (zawias1.Text != "")
                        z1 = Double.Parse(zawias1.Text, NumberStyles.Currency);
                    else
                        z1 = 0;

                    if (zawias2.Text != "")
                        z2 = Double.Parse(zawias2.Text, NumberStyles.Currency);
                    else
                        z2 = 0;

                    total = kosztm + kosztc + kpr + kpl + dod + cie + rob + z1 + z2;

                    break;


                case 3:

                    if (cp44.Text != "")
                        c44 = Double.Parse(cp44.Text, NumberStyles.Currency);
                    else
                        c44 = 0;

                    if (cpr88.Text != "")
                        c88 = Double.Parse(cpr88.Text, NumberStyles.Currency);
                    else
                        c88 = 0;

                    if (lp44.Text != "")
                        d44 = Convert.ToDouble(lp44.Text);
                    else
                        d44 = 0;

                    if (lp88.Text != "")
                        d88 = Convert.ToDouble(lp88.Text);               
                    else
                        d88 = 0;

                    if (wozki.Text != "")
                        woz = Double.Parse(wozki.Text, NumberStyles.Currency);
                    else
                        woz = 0;

                    if (kieszen.Text != "")
                        kie = Double.Parse(kieszen.Text, NumberStyles.Currency);
                    else
                        kie = 0;


                    m44 = masap44 * d44;
                    m88 = masap88 * d88;

                    k44 = m44 * c44;
                    k88 = m88 * c88;

                    mp44.Text = Convert.ToString(m44);
                    mp88.Text = Convert.ToString(m88);

                    kp44.Text = string.Format("{0:c}", k44);
                    kp88.Text = string.Format("{0:c}", k88);


                    total = kosztm + kosztc + kpr + kpl + dod + cie + rob + k44 + k88 + woz + kie;
                    

                    break;

                case 4:

                    if (zawias1.Text != "")
                        z1 = Double.Parse(zawias1.Text, NumberStyles.Currency);
                    else
                        z1 = 0;

                    if (zawias2.Text != "")
                        z2 = Double.Parse(zawias2.Text, NumberStyles.Currency);
                    else
                        z2 = 0;

                    total = kosztm + kosztc + kpr + kpl + dod + cie + rob + z1 + z2;

                    break;
            }


            lbltotal.Text = string.Format("{0:c}", total);
            colour();
        }
        private void colour()
        {
            if (masa1.Text == "brak podanego profilu")
                masa1.ForeColor = System.Drawing.Color.Red;
            else
                masa1.ForeColor = System.Drawing.Color.Black;
            if (masa2.Text == "brak podanego profilu")
                masa2.ForeColor = System.Drawing.Color.Red;
            else
                masa2.ForeColor = System.Drawing.Color.Black;
            if (masa3.Text == "brak podanego profilu")
                masa3.ForeColor = System.Drawing.Color.Red;
            else
                masa3.ForeColor = System.Drawing.Color.Black;
            if (masa4.Text == "brak podanego profilu")
                masa4.ForeColor = System.Drawing.Color.Red;
            else
                masa4.ForeColor = System.Drawing.Color.Black;

            if (masap1.Text == "brak podanego profilu")
                masap1.ForeColor = System.Drawing.Color.Red;
            else
                masap1.ForeColor = System.Drawing.Color.Black;
            if (masap2.Text == "brak podanego profilu")
                masap2.ForeColor = System.Drawing.Color.Red;
            else
                masap2.ForeColor = System.Drawing.Color.Black;
            if (masap3.Text == "brak podanego profilu")
                masap3.ForeColor = System.Drawing.Color.Red;
            else
                masap3.ForeColor = System.Drawing.Color.Black;
        }
        private void save()
        {
            if (textBox9.Text != linesdefault[0] || textBoxp9.Text != linesdefault[1] || cm.Text != linesdefault[2] || cc.Text != linesdefault[3])
            {
                DialogResult result = MessageBox.Show("Czy zapisać ceny?", "Siema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    savedefault();
                }
            }


            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            switch(tab)
            {
                case 1:
                    savefile.FileName = "Przęsło.txt";
                    break;
                case 2:
                    savefile.FileName = "Furtka.txt";
                    break;
                case 3:
                    savefile.FileName = "Brama_przesuwna.txt";
                    break;
                case 4:
                    savefile.FileName = "Brama_skrzydłowa.txt";
                    break;
            }
            // set filters
            savefile.Filter = "Text files (.txt)|.txt";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                {
                    //Profile
                    if(kpr>0)
                    {
                        sw.WriteLine(string.Format("Profil\t\tDł_brutto\tDł_netto\tCena\n{0}x{1}x{2,-7}\t{3}\t\t{4}\t\t{5}", comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox1.Text, textBox2.Text, lblkpr1.Text));
                        if (radioButton2.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}\t\t{5}", comboBox4.Text, comboBox5.Text, comboBox6.Text, textBox3.Text, textBox4.Text, lblkpr2.Text));

                        }
                        else if (radioButton3.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}\t\t{5}", comboBox4.Text, comboBox5.Text, comboBox6.Text, textBox3.Text, textBox4.Text, lblkpr2.Text));
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}\t\t{5}", comboBox7.Text, comboBox8.Text, comboBox9.Text, textBox5.Text, textBox6.Text, lblkpr3.Text));
                        }
                        else if (radioButton4.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}\t\t{5}", comboBox4.Text, comboBox5.Text, comboBox6.Text, textBox3.Text, textBox4.Text, lblkpr2.Text));
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}\t\t{5}", comboBox7.Text, comboBox8.Text, comboBox9.Text, textBox5.Text, textBox6.Text, lblkpr3.Text));
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}\t\t{5}", comboBox10.Text, comboBox11.Text, comboBox12.Text, textBox7.Text, textBox8.Text, lblkpr4.Text));
                        }
                        sw.WriteLine(string.Format("Cena_stali\tMasa_brutto\tMasa_netto\tKoszt\n{0,-16}{1,-16}{2,-16}{3,-16}\n\n",textBox9.Text, masab.Text, masan.Text, kosztpr.Text));
                    }

                    //Płaskowniki
                    if (kpl>0)
                    {
                        sw.WriteLine(string.Format("Płaskownik\tDł_brutto\tDł_netto\tCena\n{0}x{1,-7}\t{2}\t\t{3}\t\t{4}", comboBoxp1.Text, comboBoxp2.Text, textBoxp1.Text, textBoxp2.Text,lblkpl1.Text));
                        if (radioButton6.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1,-7}\t{2}\t\t{3}\t\t{4}", comboBoxp11.Text, comboBoxp21.Text, textBoxp3.Text, textBoxp4.Text,lblkpl2.Text));
                        }
                        else if (radioButton7.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1,-7}\t{2}\t\t{3}\t\t{4}", comboBoxp11.Text, comboBoxp21.Text, textBoxp3.Text, textBoxp4.Text,lblkpl2.Text));
                            sw.WriteLine(string.Format("{0}x{1,-7}\t{2}\t\t{3}\t\t{4}", comboBoxp12.Text, comboBoxp22.Text, textBoxp5.Text, textBoxp6.Text,lblkpl3.Text));
                        }
                        sw.WriteLine(string.Format("Cena_stali\tMasa_brutto\tMasa_netto\tKoszt\n{0,-16}{1,-16}{2,-16}{3,-16}\n\n",textBoxp9.Text, masabp.Text, masanp.Text, kosztpl.Text));
                    }


                    if (checkBox2.Checked)
                    {
                        sw.WriteLine(string.Format("Malowanie - {0}", km.Text));
                    }
                    if (checkBox1.Checked)
                    {
                        sw.WriteLine(string.Format("Cynkowanie - {0}", kc.Text));
                    }

                    switch(tab)
                    {
                        case 2:
                            if (zawias1.Text != "") 
                                sw.WriteLine(string.Format("Zawiasy regulowane - {0}", zawias1.Text));
                            if (zawias2.Text != "")
                                sw.WriteLine(string.Format("Przymyk + elektrozamek - {0}", zawias2.Text));                           
                            break;

                        case 3:
                            if (k44>0)
                                sw.WriteLine(string.Format("Prowadnica górna C 40x40 - {0}", kp44.Text));
                            if (k88>0)
                                sw.WriteLine(string.Format("Prowadnica 80x80 - {0}",kp88.Text));
                            if (wozki.Text != "")
                                sw.WriteLine(string.Format("Wózki - {0}", wozki.Text));
                            if (kieszen.Text != "")
                                sw.WriteLine(string.Format("Kieszeń najazdowa, rolki najazdowe górne, trzymanie górne, rolka najazdowa - {0}", kieszen.Text));
                            break;

                        case 4:
                            if (zawias1.Text != "")
                                sw.WriteLine(string.Format("Zawiasy regulowane - {0}", zawias1.Text));
                            if (zawias2.Text != "")
                                sw.WriteLine(string.Format("Zamknięcie + żaba - {0}", zawias2.Text));
                            break;
                    }

                    if (robocizna.Text != "")
                        sw.WriteLine(string.Format("Robocizna - {0}", robocizna.Text));
                    if (dodatkicena.Text != "")
                        sw.WriteLine(string.Format("Dodatki (groty, wzory, itp.) - {0}", dodatkicena.Text));
                    if (ciecie.Text != "")
                        sw.WriteLine(string.Format("Cięcie plazmowe {0}",  ciecie.Text));

                    sw.WriteLine(string.Format("TOTAL - {0}\n", lbltotal.Text));


                }
            }
        }
        private void savedefault()
        {
            if (textBox9.Text == "")
                textBox9.Text = "7,10 zł";
            if (textBoxp9.Text == "")
                textBoxp9.Text = "7,10 zł";
            if (cm.Text == "")
                cm.Text = "50,00 zł";
            if (cc.Text == "")
                cc.Text = "2,70 zł";

            string createText = string.Format("{0}\n{1}\n{2}\n{3}" ,textBox9.Text, textBoxp9.Text, cm.Text, cc.Text + Environment.NewLine);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"Data\", "default.txt"), createText);
        }

        private void switchtab()
        {

            switch(currenttab)
            {
                case 1:
                    przeslocomboboxindex[0] = (comboBox1.SelectedItem == null) ? null : Convert.ToString(comboBox1.SelectedItem);
                    przeslocomboboxindex[1] = (comboBox2.SelectedItem == null) ? null : Convert.ToString(comboBox2.SelectedItem);
                    przeslocomboboxindex[2] = (comboBox3.SelectedItem == null) ? null : Convert.ToString(comboBox3.SelectedItem);
                    przeslocomboboxindex[3] = (comboBox4.SelectedItem == null) ? null : Convert.ToString(comboBox4.SelectedItem);
                    przeslocomboboxindex[4] = (comboBox5.SelectedItem == null) ? null : Convert.ToString(comboBox5.SelectedItem);
                    przeslocomboboxindex[5] = (comboBox6.SelectedItem == null) ? null : Convert.ToString(comboBox6.SelectedItem);
                    przeslocomboboxindex[6] = (comboBox7.SelectedItem == null) ? null : Convert.ToString(comboBox7.SelectedItem);
                    przeslocomboboxindex[7] = (comboBox8.SelectedItem == null) ? null : Convert.ToString(comboBox8.SelectedItem);
                    przeslocomboboxindex[8] = (comboBox9.SelectedItem == null) ? null : Convert.ToString(comboBox9.SelectedItem);
                    przeslocomboboxindex[9] = (comboBox10.SelectedItem == null) ? null : Convert.ToString(comboBox10.SelectedItem);
                    przeslocomboboxindex[10] = (comboBox11.SelectedItem == null) ? null : Convert.ToString(comboBox11.SelectedItem);
                    przeslocomboboxindex[11] = (comboBox12.SelectedItem == null) ? null : Convert.ToString(comboBox12.SelectedItem);
                    przeslocomboboxindex[12] = (comboBoxp1.SelectedItem == null) ? null : Convert.ToString(comboBoxp1.SelectedItem);
                    przeslocomboboxindex[13] = (comboBoxp2.SelectedItem == null) ? null : Convert.ToString(comboBoxp2.SelectedItem);
                    przeslocomboboxindex[14] = (comboBoxp11.SelectedItem == null) ? null : Convert.ToString(comboBoxp11.SelectedItem);
                    przeslocomboboxindex[15] = (comboBoxp21.SelectedItem == null) ? null : Convert.ToString(comboBoxp21.SelectedItem);
                    przeslocomboboxindex[16] = (comboBoxp12.SelectedItem == null) ? null : Convert.ToString(comboBoxp12.SelectedItem);
                    przeslocomboboxindex[17] = (comboBoxp22.SelectedItem == null) ? null : Convert.ToString(comboBoxp22.SelectedItem);

                    przeslo[0] = textBox1.Text;
                    przeslo[1] = textBox2.Text;
                    przeslo[2] = textBox3.Text;
                    przeslo[3] = textBox4.Text;
                    przeslo[4] = textBox5.Text;
                    przeslo[5] = textBox6.Text;
                    przeslo[6] = textBox7.Text;
                    przeslo[7] = textBox8.Text;
                    przeslo[8] = textBoxp1.Text;
                    przeslo[9] = textBoxp2.Text;
                    przeslo[10] = textBoxp3.Text;
                    przeslo[11] = textBoxp4.Text;
                    przeslo[12] = textBoxp5.Text;
                    przeslo[13] = textBoxp6.Text;
                    przeslo[14] = lm.Text;
                    przeslo[15] = km.Text;
                    przeslo[16] = lc.Text;
                    przeslo[17] = kc.Text;
                    przeslo[18] = robocizna.Text;
                    przeslo[19] = dodatkicena.Text;
                    przeslo[20] = dodatkimasa.Text;
                    przeslo[21] = dodatkipow.Text;
                    przeslo[22] = ciecie.Text;
                    przeslo[23] = zawias1.Text;
                    przeslo[24] = zawias2.Text;
                    przeslo[25] = cp44.Text;
                    przeslo[26] = cpr88.Text;
                    przeslo[27] = lp44.Text;
                    przeslo[28] = lp88.Text;
                    przeslo[29] = mp44.Text;
                    przeslo[30] = kp44.Text;
                    przeslo[31] = mp88.Text;
                    przeslo[32] = kp88.Text;
                    przeslo[33] = wozki.Text;
                    przeslo[34] = kieszen.Text;
                    przeslo[35] = masa1.Text;
                    przeslo[36] = masa2.Text;
                    przeslo[37] = masa3.Text;
                    przeslo[38] = masa4.Text;
                    przeslo[39] = masap1.Text;
                    przeslo[40] = masap2.Text;
                    przeslo[41] = masap3.Text;
                    przeslo[42] = masab.Text;
                    przeslo[43] = masan.Text;
                    przeslo[44] = masabp.Text;
                    przeslo[45] = masanp.Text;
                    przeslo[46] = kosztpl.Text;
                    przeslo[47] = kosztpr.Text;
                    break;

                case 2:
                    furtkacomboboxindex[0] = (comboBox1.SelectedItem == null) ? null : Convert.ToString(comboBox1.SelectedItem);
                    furtkacomboboxindex[1] = (comboBox2.SelectedItem == null) ? null : Convert.ToString(comboBox2.SelectedItem);
                    furtkacomboboxindex[2] = (comboBox3.SelectedItem == null) ? null : Convert.ToString(comboBox3.SelectedItem);
                    furtkacomboboxindex[3] = (comboBox4.SelectedItem == null) ? null : Convert.ToString(comboBox4.SelectedItem);
                    furtkacomboboxindex[4] = (comboBox5.SelectedItem == null) ? null : Convert.ToString(comboBox5.SelectedItem);
                    furtkacomboboxindex[5] = (comboBox6.SelectedItem == null) ? null : Convert.ToString(comboBox6.SelectedItem);
                    furtkacomboboxindex[6] = (comboBox7.SelectedItem == null) ? null : Convert.ToString(comboBox7.SelectedItem);
                    furtkacomboboxindex[7] = (comboBox8.SelectedItem == null) ? null : Convert.ToString(comboBox8.SelectedItem);
                    furtkacomboboxindex[8] = (comboBox9.SelectedItem == null) ? null : Convert.ToString(comboBox9.SelectedItem);
                    furtkacomboboxindex[9] = (comboBox10.SelectedItem == null) ? null : Convert.ToString(comboBox10.SelectedItem);
                    furtkacomboboxindex[10] = (comboBox11.SelectedItem == null) ? null : Convert.ToString(comboBox11.SelectedItem);
                    furtkacomboboxindex[11] = (comboBox12.SelectedItem == null) ? null : Convert.ToString(comboBox12.SelectedItem);
                    furtkacomboboxindex[12] = (comboBoxp1.SelectedItem == null) ? null : Convert.ToString(comboBoxp1.SelectedItem);
                    furtkacomboboxindex[13] = (comboBoxp2.SelectedItem == null) ? null : Convert.ToString(comboBoxp2.SelectedItem);
                    furtkacomboboxindex[14] = (comboBoxp11.SelectedItem == null) ? null : Convert.ToString(comboBoxp11.SelectedItem);
                    furtkacomboboxindex[15] = (comboBoxp21.SelectedItem == null) ? null : Convert.ToString(comboBoxp21.SelectedItem);
                    furtkacomboboxindex[16] = (comboBoxp12.SelectedItem == null) ? null : Convert.ToString(comboBoxp12.SelectedItem);
                    furtkacomboboxindex[17] = (comboBoxp22.SelectedItem == null) ? null : Convert.ToString(comboBoxp22.SelectedItem);


                    furtka[0] = textBox1.Text;
                    furtka[1] = textBox2.Text;
                    furtka[2] = textBox3.Text;
                    furtka[3] = textBox4.Text;
                    furtka[4] = textBox5.Text;
                    furtka[5] = textBox6.Text;
                    furtka[6] = textBox7.Text;
                    furtka[7] = textBox8.Text;
                    furtka[8] = textBoxp1.Text;
                    furtka[9] = textBoxp2.Text;
                    furtka[10] = textBoxp3.Text;
                    furtka[11] = textBoxp4.Text;
                    furtka[12] = textBoxp5.Text;
                    furtka[13] = textBoxp6.Text;
                    furtka[14] = lm.Text;
                    furtka[15] = km.Text;
                    furtka[16] = lc.Text;
                    furtka[17] = kc.Text;
                    furtka[18] = robocizna.Text;
                    furtka[19] = dodatkicena.Text;
                    furtka[20] = dodatkimasa.Text;
                    furtka[21] = dodatkipow.Text;
                    furtka[22] = ciecie.Text;
                    furtka[23] = zawias1.Text;
                    furtka[24] = zawias2.Text;
                    furtka[25] = cp44.Text;
                    furtka[26] = cpr88.Text;
                    furtka[27] = lp44.Text;
                    furtka[28] = lp88.Text;
                    furtka[29] = mp44.Text;
                    furtka[30] = kp44.Text;
                    furtka[31] = mp88.Text;
                    furtka[32] = kp88.Text;
                    furtka[33] = wozki.Text;
                    furtka[34] = kieszen.Text;
                    furtka[35] = masa1.Text;
                    furtka[36] = masa2.Text;
                    furtka[37] = masa3.Text;
                    furtka[38] = masa4.Text;
                    furtka[39] = masap1.Text;
                    furtka[40] = masap2.Text;
                    furtka[41] = masap3.Text;
                    furtka[42] = masab.Text;
                    furtka[43] = masan.Text;
                    furtka[44] = masabp.Text;
                    furtka[45] = masanp.Text;
                    furtka[46] = kosztpl.Text;
                    furtka[47] = kosztpr.Text;

                    break;

                case 3:
                    bramaprzesuwnacomboboxindex[0] = (comboBox1.SelectedItem == null) ? null : Convert.ToString(comboBox1.SelectedItem);
                    bramaprzesuwnacomboboxindex[1] = (comboBox2.SelectedItem == null) ? null : Convert.ToString(comboBox2.SelectedItem);
                    bramaprzesuwnacomboboxindex[2] = (comboBox3.SelectedItem == null) ? null : Convert.ToString(comboBox3.SelectedItem);
                    bramaprzesuwnacomboboxindex[3] = (comboBox4.SelectedItem == null) ? null : Convert.ToString(comboBox4.SelectedItem);
                    bramaprzesuwnacomboboxindex[4] = (comboBox5.SelectedItem == null) ? null : Convert.ToString(comboBox5.SelectedItem);
                    bramaprzesuwnacomboboxindex[5] = (comboBox6.SelectedItem == null) ? null : Convert.ToString(comboBox6.SelectedItem);
                    bramaprzesuwnacomboboxindex[6] = (comboBox7.SelectedItem == null) ? null : Convert.ToString(comboBox7.SelectedItem);
                    bramaprzesuwnacomboboxindex[7] = (comboBox8.SelectedItem == null) ? null : Convert.ToString(comboBox8.SelectedItem);
                    bramaprzesuwnacomboboxindex[8] = (comboBox9.SelectedItem == null) ? null : Convert.ToString(comboBox9.SelectedItem);
                    bramaprzesuwnacomboboxindex[9] = (comboBox10.SelectedItem == null) ? null : Convert.ToString(comboBox10.SelectedItem);
                    bramaprzesuwnacomboboxindex[10] = (comboBox11.SelectedItem == null) ? null : Convert.ToString(comboBox11.SelectedItem);
                    bramaprzesuwnacomboboxindex[11] = (comboBox12.SelectedItem == null) ? null : Convert.ToString(comboBox12.SelectedItem);
                    bramaprzesuwnacomboboxindex[12] = (comboBoxp1.SelectedItem == null) ? null : Convert.ToString(comboBoxp1.SelectedItem);
                    bramaprzesuwnacomboboxindex[13] = (comboBoxp2.SelectedItem == null) ? null : Convert.ToString(comboBoxp2.SelectedItem);
                    bramaprzesuwnacomboboxindex[14] = (comboBoxp11.SelectedItem == null) ? null : Convert.ToString(comboBoxp11.SelectedItem);
                    bramaprzesuwnacomboboxindex[15] = (comboBoxp21.SelectedItem == null) ? null : Convert.ToString(comboBoxp21.SelectedItem);
                    bramaprzesuwnacomboboxindex[16] = (comboBoxp12.SelectedItem == null) ? null : Convert.ToString(comboBoxp12.SelectedItem);
                    bramaprzesuwnacomboboxindex[17] = (comboBoxp22.SelectedItem == null) ? null : Convert.ToString(comboBoxp22.SelectedItem);
                    bramaprzesuwna[0] = textBox1.Text;
                    bramaprzesuwna[1] = textBox2.Text;
                    bramaprzesuwna[2] = textBox3.Text;
                    bramaprzesuwna[3] = textBox4.Text;
                    bramaprzesuwna[4] = textBox5.Text;
                    bramaprzesuwna[5] = textBox6.Text;
                    bramaprzesuwna[6] = textBox7.Text;
                    bramaprzesuwna[7] = textBox8.Text;
                    bramaprzesuwna[8] = textBoxp1.Text;
                    bramaprzesuwna[9] = textBoxp2.Text;
                    bramaprzesuwna[10] = textBoxp3.Text;
                    bramaprzesuwna[11] = textBoxp4.Text;
                    bramaprzesuwna[12] = textBoxp5.Text;
                    bramaprzesuwna[13] = textBoxp6.Text;
                    bramaprzesuwna[14] = lm.Text;
                    bramaprzesuwna[15] = km.Text;
                    bramaprzesuwna[16] = lc.Text;
                    bramaprzesuwna[17] = kc.Text;
                    bramaprzesuwna[18] = robocizna.Text;
                    bramaprzesuwna[19] = dodatkicena.Text;
                    bramaprzesuwna[20] = dodatkimasa.Text;
                    bramaprzesuwna[21] = dodatkipow.Text;
                    bramaprzesuwna[22] = ciecie.Text;
                    bramaprzesuwna[23] = zawias1.Text;
                    bramaprzesuwna[24] = zawias2.Text;
                    bramaprzesuwna[25] = cp44.Text;
                    bramaprzesuwna[26] = cpr88.Text;
                    bramaprzesuwna[27] = lp44.Text;
                    bramaprzesuwna[28] = lp88.Text;
                    bramaprzesuwna[29] = mp44.Text;
                    bramaprzesuwna[30] = kp44.Text;
                    bramaprzesuwna[31] = mp88.Text;
                    bramaprzesuwna[32] = kp88.Text;
                    bramaprzesuwna[33] = wozki.Text;
                    bramaprzesuwna[34] = kieszen.Text;
                    bramaprzesuwna[35] = masa1.Text;
                    bramaprzesuwna[36] = masa2.Text;
                    bramaprzesuwna[37] = masa3.Text;
                    bramaprzesuwna[38] = masa4.Text;
                    bramaprzesuwna[39] = masap1.Text;
                    bramaprzesuwna[40] = masap2.Text;
                    bramaprzesuwna[41] = masap3.Text;
                    bramaprzesuwna[42] = masab.Text;
                    bramaprzesuwna[43] = masan.Text;
                    bramaprzesuwna[44] = masabp.Text;
                    bramaprzesuwna[45] = masanp.Text;
                    bramaprzesuwna[46] = kosztpl.Text;
                    bramaprzesuwna[47] = kosztpr.Text;
                    break;

                case 4:
                    bramaskrzydlowacomboboxindex[0] = (comboBox1.SelectedItem == null) ? null : Convert.ToString(comboBox1.SelectedItem);
                    bramaskrzydlowacomboboxindex[1] = (comboBox2.SelectedItem == null) ? null : Convert.ToString(comboBox2.SelectedItem);
                    bramaskrzydlowacomboboxindex[2] = (comboBox3.SelectedItem == null) ? null : Convert.ToString(comboBox3.SelectedItem);
                    bramaskrzydlowacomboboxindex[3] = (comboBox4.SelectedItem == null) ? null : Convert.ToString(comboBox4.SelectedItem);
                    bramaskrzydlowacomboboxindex[4] = (comboBox5.SelectedItem == null) ? null : Convert.ToString(comboBox5.SelectedItem);
                    bramaskrzydlowacomboboxindex[5] = (comboBox6.SelectedItem == null) ? null : Convert.ToString(comboBox6.SelectedItem);
                    bramaskrzydlowacomboboxindex[6] = (comboBox7.SelectedItem == null) ? null : Convert.ToString(comboBox7.SelectedItem);
                    bramaskrzydlowacomboboxindex[7] = (comboBox8.SelectedItem == null) ? null : Convert.ToString(comboBox8.SelectedItem);
                    bramaskrzydlowacomboboxindex[8] = (comboBox9.SelectedItem == null) ? null : Convert.ToString(comboBox9.SelectedItem);
                    bramaskrzydlowacomboboxindex[9] = (comboBox10.SelectedItem == null) ? null : Convert.ToString(comboBox10.SelectedItem);
                    bramaskrzydlowacomboboxindex[10] = (comboBox11.SelectedItem == null) ? null : Convert.ToString(comboBox11.SelectedItem);
                    bramaskrzydlowacomboboxindex[11] = (comboBox12.SelectedItem == null) ? null : Convert.ToString(comboBox12.SelectedItem);
                    bramaskrzydlowacomboboxindex[12] = (comboBoxp1.SelectedItem == null) ? null : Convert.ToString(comboBoxp1.SelectedItem);
                    bramaskrzydlowacomboboxindex[13] = (comboBoxp2.SelectedItem == null) ? null : Convert.ToString(comboBoxp2.SelectedItem);
                    bramaskrzydlowacomboboxindex[14] = (comboBoxp11.SelectedItem == null) ? null : Convert.ToString(comboBoxp11.SelectedItem);
                    bramaskrzydlowacomboboxindex[15] = (comboBoxp21.SelectedItem == null) ? null : Convert.ToString(comboBoxp21.SelectedItem);
                    bramaskrzydlowacomboboxindex[16] = (comboBoxp12.SelectedItem == null) ? null : Convert.ToString(comboBoxp12.SelectedItem);
                    bramaskrzydlowacomboboxindex[17] = (comboBoxp22.SelectedItem == null) ? null : Convert.ToString(comboBoxp22.SelectedItem);

                    bramaskrzydlowa[0] = textBox1.Text;
                    bramaskrzydlowa[1] = textBox2.Text;
                    bramaskrzydlowa[2] = textBox3.Text;
                    bramaskrzydlowa[3] = textBox4.Text;
                    bramaskrzydlowa[4] = textBox5.Text;
                    bramaskrzydlowa[5] = textBox6.Text;
                    bramaskrzydlowa[6] = textBox7.Text;
                    bramaskrzydlowa[7] = textBox8.Text;
                    bramaskrzydlowa[8] = textBoxp1.Text;
                    bramaskrzydlowa[9] = textBoxp2.Text;
                    bramaskrzydlowa[10] = textBoxp3.Text;
                    bramaskrzydlowa[11] = textBoxp4.Text;
                    bramaskrzydlowa[12] = textBoxp5.Text;
                    bramaskrzydlowa[13] = textBoxp6.Text;
                    bramaskrzydlowa[14] = lm.Text;
                    bramaskrzydlowa[15] = km.Text;
                    bramaskrzydlowa[16] = lc.Text;
                    bramaskrzydlowa[17] = kc.Text;
                    bramaskrzydlowa[18] = robocizna.Text;
                    bramaskrzydlowa[19] = dodatkicena.Text;
                    bramaskrzydlowa[20] = dodatkimasa.Text;
                    bramaskrzydlowa[21] = dodatkipow.Text;
                    bramaskrzydlowa[22] = ciecie.Text;
                    bramaskrzydlowa[23] = zawias1.Text;
                    bramaskrzydlowa[24] = zawias2.Text;
                    bramaskrzydlowa[25] = cp44.Text;
                    bramaskrzydlowa[26] = cpr88.Text;
                    bramaskrzydlowa[27] = lp44.Text;
                    bramaskrzydlowa[28] = lp88.Text;
                    bramaskrzydlowa[29] = mp44.Text;
                    bramaskrzydlowa[30] = kp44.Text;
                    bramaskrzydlowa[31] = mp88.Text;
                    bramaskrzydlowa[32] = kp88.Text;
                    bramaskrzydlowa[33] = wozki.Text;
                    bramaskrzydlowa[34] = kieszen.Text;
                    bramaskrzydlowa[35] = masa1.Text;
                    bramaskrzydlowa[36] = masa2.Text;
                    bramaskrzydlowa[37] = masa3.Text;
                    bramaskrzydlowa[38] = masa4.Text;
                    bramaskrzydlowa[39] = masap1.Text;
                    bramaskrzydlowa[40] = masap2.Text;
                    bramaskrzydlowa[41] = masap3.Text;
                    bramaskrzydlowa[42] = masab.Text;
                    bramaskrzydlowa[43] = masan.Text;
                    bramaskrzydlowa[44] = masabp.Text;
                    bramaskrzydlowa[45] = masanp.Text;
                    bramaskrzydlowa[46] = kosztpl.Text;
                    bramaskrzydlowa[47] = kosztpr.Text;
                    break;
            }

            switch (tab)
            {
                case 1:
                    comboBox1.SelectedItem = przeslocomboboxindex[0];
                    comboBox2.SelectedItem = przeslocomboboxindex[1];
                    comboBox3.SelectedItem = przeslocomboboxindex[2];
                    comboBox4.SelectedItem = przeslocomboboxindex[3];
                    comboBox5.SelectedItem = przeslocomboboxindex[4];
                    comboBox6.SelectedItem = przeslocomboboxindex[5];
                    comboBox7.SelectedItem = przeslocomboboxindex[6];
                    comboBox8.SelectedItem = przeslocomboboxindex[7];
                    comboBox9.SelectedItem = przeslocomboboxindex[8];
                    comboBox10.SelectedItem = przeslocomboboxindex[9];
                    comboBox11.SelectedItem = przeslocomboboxindex[10];
                    comboBox12.SelectedItem = przeslocomboboxindex[11];
                    comboBoxp1.SelectedItem = przeslocomboboxindex[12];
                    comboBoxp2.SelectedItem = przeslocomboboxindex[13];
                    comboBoxp11.SelectedItem = przeslocomboboxindex[14];
                    comboBoxp21.SelectedItem = przeslocomboboxindex[15];
                    comboBoxp12.SelectedItem = przeslocomboboxindex[16];
                    comboBoxp22.SelectedItem = przeslocomboboxindex[17];
                    textBox1.Text = przeslo[0];
                    textBox2.Text = przeslo[1];
                    textBox3.Text = przeslo[2];
                    textBox4.Text = przeslo[3];
                    textBox5.Text = przeslo[4];
                    textBox6.Text = przeslo[5];
                    textBox7.Text = przeslo[6];
                    textBox8.Text = przeslo[7];
                    textBoxp1.Text = przeslo[8];
                    textBoxp2.Text = przeslo[9];
                    textBoxp3.Text = przeslo[10];
                    textBoxp4.Text = przeslo[11];
                    textBoxp5.Text = przeslo[12];
                    textBoxp6.Text = przeslo[13];
                    lm.Text = przeslo[14];
                    km.Text = przeslo[15];
                    lc.Text = przeslo[16];
                    kc.Text = przeslo[17];
                    robocizna.Text = przeslo[18];
                    dodatkicena.Text = przeslo[19];
                    dodatkimasa.Text = przeslo[20];
                    dodatkipow.Text = przeslo[21];
                    ciecie.Text = przeslo[22];
                    zawias1.Text = przeslo[23];
                    zawias2.Text = przeslo[24];
                    cp44.Text = przeslo[25];
                    cpr88.Text = przeslo[26];
                    lp44.Text = przeslo[27];
                    lp88.Text = przeslo[28];
                    mp44.Text = przeslo[29];
                    kp44.Text = przeslo[30];
                    mp88.Text = przeslo[31];
                    kp88.Text = przeslo[32];
                    wozki.Text = przeslo[33];
                    kieszen.Text = przeslo[34];
                    masa1.Text = przeslo[35];
                    masa2.Text = przeslo[36];
                    masa3.Text = przeslo[37];
                    masa4.Text = przeslo[38];
                    masap1.Text = przeslo[39];
                    masap2.Text = przeslo[40];
                    masap3.Text = przeslo[41];
                    masab.Text = przeslo[42];
                    masan.Text = przeslo[43];
                    masabp.Text = przeslo[44];
                    masanp.Text = przeslo[45];
                    kosztpl.Text = przeslo[46];
                    kosztpr.Text = przeslo[47];
                    break;

                case 2:
                    comboBox1.SelectedItem = furtkacomboboxindex[0];
                    comboBox2.SelectedItem = furtkacomboboxindex[1];
                    comboBox3.SelectedItem = furtkacomboboxindex[2];
                    comboBox4.SelectedItem = furtkacomboboxindex[3];
                    comboBox5.SelectedItem = furtkacomboboxindex[4];
                    comboBox6.SelectedItem = furtkacomboboxindex[5];
                    comboBox7.SelectedItem = furtkacomboboxindex[6];
                    comboBox8.SelectedItem = furtkacomboboxindex[7];
                    comboBox9.SelectedItem = furtkacomboboxindex[8];
                    comboBox10.SelectedItem = furtkacomboboxindex[9];
                    comboBox11.SelectedItem = furtkacomboboxindex[10];
                    comboBox12.SelectedItem = furtkacomboboxindex[11];
                    comboBoxp1.SelectedItem = furtkacomboboxindex[12];
                    comboBoxp2.SelectedItem = furtkacomboboxindex[13];
                    comboBoxp11.SelectedItem = furtkacomboboxindex[14];
                    comboBoxp21.SelectedItem = furtkacomboboxindex[15];
                    comboBoxp12.SelectedItem = furtkacomboboxindex[16];
                    comboBoxp22.SelectedItem = furtkacomboboxindex[17];
                    textBox1.Text = furtka[0];
                    textBox2.Text = furtka[1];
                    textBox3.Text = furtka[2];
                    textBox4.Text = furtka[3];
                    textBox5.Text = furtka[4];
                    textBox6.Text = furtka[5];
                    textBox7.Text = furtka[6];
                    textBox8.Text = furtka[7];
                    textBoxp1.Text = furtka[8];
                    textBoxp2.Text = furtka[9];
                    textBoxp3.Text = furtka[10];
                    textBoxp4.Text = furtka[11];
                    textBoxp5.Text = furtka[12];
                    textBoxp6.Text = furtka[13];
                    lm.Text = furtka[14];
                    km.Text = furtka[15];
                    lc.Text = furtka[16];
                    kc.Text = furtka[17];
                    robocizna.Text = furtka[18];
                    dodatkicena.Text = furtka[19];
                    dodatkimasa.Text = furtka[20];
                    dodatkipow.Text = furtka[21];
                    ciecie.Text = furtka[22];
                    zawias1.Text = furtka[23];
                    zawias2.Text = furtka[24];
                    cp44.Text = furtka[25];
                    cpr88.Text = furtka[26];
                    lp44.Text = furtka[27];
                    lp88.Text = furtka[28];
                    mp44.Text = furtka[29];
                    kp44.Text = furtka[30];
                    mp88.Text = furtka[31];
                    kp88.Text = furtka[32];
                    wozki.Text = furtka[33];
                    kieszen.Text = furtka[34];
                    masa1.Text = furtka[35];
                    masa2.Text = furtka[36];
                    masa3.Text = furtka[37];
                    masa4.Text = furtka[38];
                    masap1.Text = furtka[39];
                    masap2.Text = furtka[40];
                    masap3.Text = furtka[41];
                    masab.Text = furtka[42];
                    masan.Text = furtka[43];
                    masabp.Text = furtka[44];
                    masanp.Text = furtka[45];
                    kosztpl.Text = furtka[46];
                    kosztpr.Text = furtka[47];
                    break;

                case 3:
                    comboBox1.SelectedItem = bramaprzesuwnacomboboxindex[0];
                    comboBox2.SelectedItem = bramaprzesuwnacomboboxindex[1];
                    comboBox3.SelectedItem = bramaprzesuwnacomboboxindex[2];
                    comboBox4.SelectedItem = bramaprzesuwnacomboboxindex[3];
                    comboBox5.SelectedItem = bramaprzesuwnacomboboxindex[4];
                    comboBox6.SelectedItem = bramaprzesuwnacomboboxindex[5];
                    comboBox7.SelectedItem = bramaprzesuwnacomboboxindex[6];
                    comboBox8.SelectedItem = bramaprzesuwnacomboboxindex[7];
                    comboBox9.SelectedItem = bramaprzesuwnacomboboxindex[8];
                    comboBox10.SelectedItem = bramaprzesuwnacomboboxindex[9];
                    comboBox11.SelectedItem = bramaprzesuwnacomboboxindex[10];
                    comboBox12.SelectedItem = bramaprzesuwnacomboboxindex[11];
                    comboBoxp1.SelectedItem = bramaprzesuwnacomboboxindex[12];
                    comboBoxp2.SelectedItem = bramaprzesuwnacomboboxindex[13];
                    comboBoxp11.SelectedItem = bramaprzesuwnacomboboxindex[14];
                    comboBoxp21.SelectedItem = bramaprzesuwnacomboboxindex[15];
                    comboBoxp12.SelectedItem = bramaprzesuwnacomboboxindex[16];
                    comboBoxp22.SelectedItem = bramaprzesuwnacomboboxindex[17];

                    textBox1.Text = bramaprzesuwna[0];
                    textBox2.Text = bramaprzesuwna[1];
                    textBox3.Text = bramaprzesuwna[2];
                    textBox4.Text = bramaprzesuwna[3];
                    textBox5.Text = bramaprzesuwna[4];
                    textBox6.Text = bramaprzesuwna[5];
                    textBox7.Text = bramaprzesuwna[6];
                    textBox8.Text = bramaprzesuwna[7];
                    textBoxp1.Text = bramaprzesuwna[8];
                    textBoxp2.Text = bramaprzesuwna[9];
                    textBoxp3.Text = bramaprzesuwna[10];
                    textBoxp4.Text = bramaprzesuwna[11];
                    textBoxp5.Text = bramaprzesuwna[12];
                    textBoxp6.Text = bramaprzesuwna[13];
                    lm.Text = bramaprzesuwna[14];
                    km.Text = bramaprzesuwna[15];
                    lc.Text = bramaprzesuwna[16];
                    kc.Text = bramaprzesuwna[17];
                    robocizna.Text = bramaprzesuwna[18];
                    dodatkicena.Text = bramaprzesuwna[19];
                    dodatkimasa.Text = bramaprzesuwna[20];
                    dodatkipow.Text = bramaprzesuwna[21];
                    ciecie.Text = bramaprzesuwna[22];
                    zawias1.Text = bramaprzesuwna[23];
                    zawias2.Text = bramaprzesuwna[24];
                    cp44.Text = bramaprzesuwna[25];
                    cpr88.Text = bramaprzesuwna[26];
                    lp44.Text = bramaprzesuwna[27];
                    lp88.Text = bramaprzesuwna[28];
                    mp44.Text = bramaprzesuwna[29];
                    kp44.Text = bramaprzesuwna[30];
                    mp88.Text = bramaprzesuwna[31];
                    kp88.Text = bramaprzesuwna[32];
                    wozki.Text = bramaprzesuwna[33];
                    kieszen.Text = bramaprzesuwna[34];
                    masa1.Text = bramaprzesuwna[35];
                    masa2.Text = bramaprzesuwna[36];
                    masa3.Text = bramaprzesuwna[37];
                    masa4.Text = bramaprzesuwna[38];
                    masap1.Text = bramaprzesuwna[39];
                    masap2.Text = bramaprzesuwna[40];
                    masap3.Text = bramaprzesuwna[41];
                    masab.Text = bramaprzesuwna[42];
                    masan.Text = bramaprzesuwna[43];
                    masabp.Text = bramaprzesuwna[44];
                    masanp.Text = bramaprzesuwna[45];
                    kosztpl.Text = bramaprzesuwna[46];
                    kosztpr.Text = bramaprzesuwna[47];

                    break;

                case 4:
                    comboBox1.SelectedItem = bramaskrzydlowacomboboxindex[0];
                    comboBox2.SelectedItem = bramaskrzydlowacomboboxindex[1];
                    comboBox3.SelectedItem = bramaskrzydlowacomboboxindex[2];
                    comboBox4.SelectedItem = bramaskrzydlowacomboboxindex[3];
                    comboBox5.SelectedItem = bramaskrzydlowacomboboxindex[4];
                    comboBox6.SelectedItem = bramaskrzydlowacomboboxindex[5];
                    comboBox7.SelectedItem = bramaskrzydlowacomboboxindex[6];
                    comboBox8.SelectedItem = bramaskrzydlowacomboboxindex[7];
                    comboBox9.SelectedItem = bramaskrzydlowacomboboxindex[8];
                    comboBox10.SelectedItem = bramaskrzydlowacomboboxindex[9];
                    comboBox11.SelectedItem = bramaskrzydlowacomboboxindex[10];
                    comboBox12.SelectedItem = bramaskrzydlowacomboboxindex[11];
                    comboBoxp1.SelectedItem = bramaskrzydlowacomboboxindex[12];
                    comboBoxp2.SelectedItem = bramaskrzydlowacomboboxindex[13];
                    comboBoxp11.SelectedItem = bramaskrzydlowacomboboxindex[14];
                    comboBoxp21.SelectedItem = bramaskrzydlowacomboboxindex[15];
                    comboBoxp12.SelectedItem = bramaskrzydlowacomboboxindex[16];
                    comboBoxp22.SelectedItem = bramaskrzydlowacomboboxindex[17];

                    textBox1.Text = bramaskrzydlowa[0];
                    textBox2.Text = bramaskrzydlowa[1];
                    textBox3.Text = bramaskrzydlowa[2];
                    textBox4.Text = bramaskrzydlowa[3];
                    textBox5.Text = bramaskrzydlowa[4];
                    textBox6.Text = bramaskrzydlowa[5];
                    textBox7.Text = bramaskrzydlowa[6];
                    textBox8.Text = bramaskrzydlowa[7];
                    textBoxp1.Text = bramaskrzydlowa[8];
                    textBoxp2.Text = bramaskrzydlowa[9];
                    textBoxp3.Text = bramaskrzydlowa[10];
                    textBoxp4.Text = bramaskrzydlowa[11];
                    textBoxp5.Text = bramaskrzydlowa[12];
                    textBoxp6.Text = bramaskrzydlowa[13];
                    lm.Text = bramaskrzydlowa[14];
                    km.Text = bramaskrzydlowa[15];
                    lc.Text = bramaskrzydlowa[16];
                    kc.Text = bramaskrzydlowa[17];
                    robocizna.Text = bramaskrzydlowa[18];
                    dodatkicena.Text = bramaskrzydlowa[19];
                    dodatkimasa.Text = bramaskrzydlowa[20];
                    dodatkipow.Text = bramaskrzydlowa[21];
                    ciecie.Text = bramaskrzydlowa[22];
                    zawias1.Text = bramaskrzydlowa[23];
                    zawias2.Text = bramaskrzydlowa[24];
                    cp44.Text = bramaskrzydlowa[25];
                    cpr88.Text = bramaskrzydlowa[26];
                    lp44.Text = bramaskrzydlowa[27];
                    lp88.Text = bramaskrzydlowa[28];
                    mp44.Text = bramaskrzydlowa[29];
                    kp44.Text = bramaskrzydlowa[30];
                    mp88.Text = bramaskrzydlowa[31];
                    kp88.Text = bramaskrzydlowa[32];
                    wozki.Text = bramaskrzydlowa[33];
                    kieszen.Text = bramaskrzydlowa[34];
                    masa1.Text = bramaskrzydlowa[35];
                    masa2.Text = bramaskrzydlowa[36];
                    masa3.Text = bramaskrzydlowa[37];
                    masa4.Text = bramaskrzydlowa[38];
                    masap1.Text = bramaskrzydlowa[39];
                    masap2.Text = bramaskrzydlowa[40];
                    masap3.Text = bramaskrzydlowa[41];
                    masab.Text = bramaskrzydlowa[42];
                    masan.Text = bramaskrzydlowa[43];
                    masabp.Text = bramaskrzydlowa[44];
                    masanp.Text = bramaskrzydlowa[45];
                    kosztpl.Text = bramaskrzydlowa[46];
                    kosztpr.Text = bramaskrzydlowa[47];
                    break;

                    
            }
            update();
        }
        private void fill1()
        {
            bool set = false; 

            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (arr[i, 0] == comboBox1.Text)
                    {
                        if (arr[i, 1] == comboBox2.Text)
                        {
                            if (arr[i, comboBox3.SelectedIndex + 2] == "")
                            {
                                masa1.Text = "brak podanego profilu";
                            }
                            else
                            {
                                masa1.Text = Convert.ToString(arr[i, comboBox3.SelectedIndex + 2]);
                                m1 = Convert.ToDouble(arr[i, comboBox3.SelectedIndex + 2]);
                                double h = Convert.ToDouble(comboBox1.Text);
                                double s = Convert.ToDouble(comboBox2.Text);
                                p1 = (2 * s + 2 * h);
                                //double c = Convert.ToDouble(comboBox3.Text);
                                //double h = Convert.ToDouble(comboBox1.Text);
                                //double s = Convert.ToDouble(comboBox2.Text);
                                //double v2 = (2 * c * (h - 2 * c) + 2 * c * s);
                                //double x2 = 0.00785;
                                //double mo2 = v2 * x2;

                            }
                            set = true;
                            break;
                        }
                    }
                }

                if(!set)
                {
                    masa1.Text = "brak podanego profilu";
                }
            }

            update();
          
        }
        private void fill2()
        {
            bool set = false;

            if (comboBox4.SelectedItem != null && comboBox5.SelectedItem != null && comboBox6.SelectedItem != null)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (arr[i, 0] == comboBox4.Text)
                    {
                        if (arr[i, 1] == comboBox5.Text)
                        {
                            if (arr[i, comboBox6.SelectedIndex + 2] == "")
                            {
                                masa2.Text = "brak podanego profilu";
                            }
                            else
                            {
                                masa2.Text = Convert.ToString(arr[i, comboBox6.SelectedIndex + 2]);
                                m2 = Convert.ToDouble(arr[i, comboBox6.SelectedIndex + 2]);
                                double h = Convert.ToDouble(comboBox4.Text);
                                double s = Convert.ToDouble(comboBox5.Text);
                                p2 = (2 * s + 2 * h);
                            }
                            set = true;
                            break;
                        }
                    }
                }

                if (!set)
                {
                    masa2.Text = "brak podanego profilu";
                }
            }
            update();
        }
        private void fill3()
        {
            bool set = false;

            if (comboBox7.SelectedItem != null && comboBox8.SelectedItem != null && comboBox9.SelectedItem != null)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (arr[i, 0] == comboBox7.Text)
                    {
                        if (arr[i, 1] == comboBox8.Text)
                        {
                            if (arr[i, comboBox9.SelectedIndex + 2] == "")
                            {
                                masa3.Text = "brak podanego profilu";
                            }
                            else
                            {
                                masa3.Text = Convert.ToString(arr[i, comboBox9.SelectedIndex + 2]);
                                m3 = Convert.ToDouble(arr[i, comboBox9.SelectedIndex + 2]);
                                double h = Convert.ToDouble(comboBox7.Text);
                                double s = Convert.ToDouble(comboBox8.Text);
                                p3 = (2 * s + 2 * h);
                            }
                            set = true;
                            break;
                        }
                    }
                }

                if (!set)
                {
                    masa3.Text = "brak podanego profilu";
                }
            }
            update();
        }
        private void fill4()
        {
            bool set = false;

            if (comboBox10.SelectedItem != null && comboBox11.SelectedItem != null && comboBox12.SelectedItem != null)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (arr[i, 0] == comboBox10.Text)
                    {
                        if (arr[i, 1] == comboBox11.Text)
                        {
                            if (arr[i, comboBox12.SelectedIndex + 2] == "")
                            {
                                masa4.Text = "brak podanego profilu";
                            }
                            else
                            {
                                masa4.Text = Convert.ToString(arr[i, comboBox12.SelectedIndex + 2]);
                                m4 = Convert.ToDouble(arr[i, comboBox12.SelectedIndex + 2]);
                                double h = Convert.ToDouble(comboBox10.Text);
                                double s = Convert.ToDouble(comboBox11.Text);
                                p4 = (2 * s + 2 * h);
                            }
                            set = true;
                            break;
                        }
                    }
                }

                if (!set)
                {
                    masa4.Text = "brak podanego profilu";
                }
            }
            update();
        }


        private void fillp1()
        {
            bool set = false;

            if (comboBoxp1.SelectedItem != null && comboBoxp2.SelectedItem != null)
            {
                for (int i = 0; i < lines1.Length; i++)
                {
                    if (arr1[i, 0] == comboBoxp1.Text)
                    {
                        if (arr1[i, comboBoxp2.SelectedIndex + 1] == "-")
                        {

                            masap1.Text = "brak podanego profilu";
                        }
                        else
                        {
                            masap1.Text = Convert.ToString(arr1[i, comboBoxp2.SelectedIndex + 1]);
                            mp1 = Convert.ToDouble(arr1[i, comboBoxp2.SelectedIndex + 1]);
                            double h = Convert.ToDouble(comboBoxp1.Text);
                            double s = Convert.ToDouble(comboBoxp2.Text);
                            pp1 = (2 * s + 2 * h);
                        }

                            set = true;
                            break;
                        
                    }
                }

                if (!set)
                {
                    masap1.Text = "brak podanego profilu";
                }
            }
            update();
        }
        private void fillp2()
        {
            bool set = false;

            if (comboBoxp11.SelectedItem != null && comboBoxp21.SelectedItem != null)
            {
                for (int i = 0; i < lines1.Length; i++)
                {
                    if (arr1[i, 0] == comboBoxp11.Text)
                    {
                        if (arr1[i, comboBoxp21.SelectedIndex + 1] == "-")
                        {

                            masap2.Text = "brak podanego profilu";
                        }
                        else
                        {
                            masap2.Text = Convert.ToString(arr1[i, comboBoxp21.SelectedIndex + 1]);
                            mp2 = Convert.ToDouble(arr1[i, comboBoxp21.SelectedIndex + 1]);
                            double h = Convert.ToDouble(comboBoxp11.Text);
                            double s = Convert.ToDouble(comboBoxp21.Text);
                            pp2 = (2 * s + 2 * h);
                        }

                        set = true;
                        break;

                    }
                }

                if (!set)
                {
                    masap2.Text = "brak podanego profilu";
                }
            }
            update();
        }
        private void fillp3()
        {
            bool set = false;

            if (comboBoxp12.SelectedItem != null && comboBoxp22.SelectedItem != null)
            {
                for (int i = 0; i < lines1.Length; i++)
                {
                    if (arr1[i, 0] == comboBoxp12.Text)
                    {
                        if (arr1[i, comboBoxp22.SelectedIndex + 1] == "-")
                        {

                            masap3.Text = "brak podanego profilu";
                        }
                        else
                        {
                            masap3.Text = Convert.ToString(arr1[i, comboBoxp22.SelectedIndex + 1]);
                            mp3 = Convert.ToDouble(arr1[i, comboBoxp22.SelectedIndex + 1]);
                            double h = Convert.ToDouble(comboBoxp12.Text);
                            double s = Convert.ToDouble(comboBoxp22.Text);
                            pp3 = (2 * s + 2 * h);
                        }

                        set = true;
                        break;

                    }
                }

                if (!set)
                {
                    masap3.Text = "brak podanego profilu";
                }
            }
            update();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //przeslo
            currenttab = tab;
            tab = 1;


            btnp.Enabled = false;
            btnf.Enabled = true;
            btnb.Enabled = true;
            btnbp.Visible = false;
            btnbs.Visible = false;
            panelfurtki.Visible = false;
            panelbramy.Visible = false;
            panelwozki.Visible = false;
            panelzz.Visible = false;



            switchtab();

            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //furtka
            currenttab = tab;
            tab = 2;

            btnp.Enabled = true;
            btnf.Enabled = false;
            btnb.Enabled = true;
            btnbp.Visible = false;
            btnbs.Visible = false;
            panelfurtki.Visible = true;
            panelprzemek.Visible = true;

            panelbramy.Visible = false;
            panelwozki.Visible = false;
            panelzz.Visible = false;



                switchtab();

            update();
        }

        private void btnb_Click(object sender, EventArgs e)
        {
            //brama
            currenttab = tab;
            tab = 3;

            btnp.Enabled = true;
            btnf.Enabled = true;
            btnb.Enabled = false;

            btnbp.Visible = true;
            btnbp.Enabled = false;

            btnbs.Visible = true;
            btnbs.Enabled = true;

            panelfurtki.Visible = false;
            panelbramy.Visible = true;
            panelwozki.Visible = true;
            panelzz.Visible = false;



                switchtab();

            update();


        }



        private void btnbp_Click(object sender, EventArgs e)
        {
            //przesuwna
            currenttab = tab;
            tab = 3;

            btnbp.Enabled = false;
            btnbs.Enabled = true;

            panelfurtki.Visible = false;
            panelbramy.Visible = true;
            panelwozki.Visible = true;
            panelzz.Visible = false;


                switchtab();

            update();
        }

        private void btnbs_Click(object sender, EventArgs e)
        {
            //skrydlowa
            currenttab = tab;
            tab = 4;

            btnbs.Enabled = false;
            btnbp.Enabled = true;

            panelfurtki.Visible = true;
            panelbramy.Visible = false;
            panelprzemek.Visible = false;
            panelwozki.Visible = false;
            panelzz.Visible = true;


                switchtab();

            update();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void lp44_TextChanged(object sender, EventArgs e)
        {

        }

        private void dodatkimasa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radio1 = 1;
            panel1.Height = 95;
            update();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radio1 = 2;
            panel1.Height = 170;
            update();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radio1 = 3;

            panel1.Height = 245;
            update();

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radio1 = 4;

            panel1.Height = 320;
            update();

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill1();
        }

        private void btncena_Click(object sender, EventArgs e)
        {
            btncena.Enabled = false;
            btnkoszt.Enabled = true;

            panelcena.Visible = true;
            panelkoszt.Visible = false;

            cena = true;

            update();

        }

        private void btnkoszt_Click(object sender, EventArgs e)
        {
            btnkoszt.Enabled = false;
            btncena.Enabled = true;

            panelcena.Visible = false;
            panelkoszt.Visible = true;

            cena = false;

            update();
        }

        private void btncenapl_Click(object sender, EventArgs e)
        {
            btncenapl.Enabled = false;
            btnkosztpl.Enabled = true;

            panelcenapl.Visible = true;
            panelkosztpl.Visible = false;

            cenapl = true;

            update();
        }

        private void btnkosztpl_Click(object sender, EventArgs e)
        {
            btnkosztpl.Enabled = false;
            btncenapl.Enabled = true;

            panelcenapl.Visible = false;
            panelkosztpl.Visible = true;

            cenapl = false;

            update();
        }



        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill1();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill1();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill2();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill2();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill2();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill3();
        }


        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill3();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill3();
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillp1();
        }

        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillp1();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill4();
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill4();
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill4();
        }

        private void comboBoxp11_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillp2();
        }

        private void comboBoxp21_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillp2();
        }

        private void comboBoxp12_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillp3();
        }

        private void comboBoxp22_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillp3();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            radio2 = 1;

            panel10.Height = 95;
            panel12.Location = new System.Drawing.Point(602, 180);
            panel12.Height = 240;
            update();

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            radio2 = 2;

            panel10.Height = 170;
            panel12.Location = new System.Drawing.Point(602, 255);
            panel12.Height = 165;
            update();

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            radio2 = 3;

            panel10.Height = 245;
            panel12.Location = new System.Drawing.Point(602, 330);
            panel12.Height = 90;
            update();

        }



        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                cm.Enabled = true;
                lm.Enabled = true;
                km.Enabled = true;
            }
            else
            {
                cm.Enabled = false;
                lm.Enabled = false;
                km.Enabled = false;
            }
            update();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                cc.Enabled = true;
                lc.Enabled = true;
                kc.Enabled = true;
            }
            else
            {
                cc.Enabled = false;
                lc.Enabled = false;
                kc.Enabled = false;
            }
            update();
        }

    }
}
