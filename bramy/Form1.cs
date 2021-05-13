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

        string[] lines = System.IO.File.ReadAllLines(@"C:\profile.txt");
        string[] lines1 = System.IO.File.ReadAllLines(@"C:\plaskowniki.txt");

        string[,] arr = new string[1000, 9];
        string[,] arr1 = new string[1000, 12];

        int tab = 1;

        double kpr = 0, kpl = 0;
        double m1, m2, m3, m4;
        double mp1, mp2, mp3;
        double p1 = 0, p2 = 0, p3 = 0, p4 = 0;
        double pp1 = 0, pp2 = 0, pp3 = 0;
        double total, rob, dod, cie;
        double woz, kie;
        double k44, k88;

        double masap44 = 1.82;
        double masap88 = 10.04;
        bool left = false;

        public Form1()
        {

            InitializeComponent();

            textBox9.Text = "7,10 zł";
            textBoxp9.Text = "7,10 zł";

            cm.Text = "50,00 zł";
            cc.Text = "2,70 zł";

        
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
            dodatki.TextChanged += removenans;
            ciecie.TextChanged += removenans;

            zawias1.TextChanged += removenans;
            zawias2.TextChanged += removenans;

            cp44.TextChanged += removenans;
            cpr88.TextChanged += removenans;
            lp44.TextChanged += removenans;
            lp88.TextChanged += removenans;
            wozki.TextChanged += removenans;
            kieszen.TextChanged += removenans;

            //walutowe
            textBoxp9.Leave += currency;
            textBox9.Leave += currency;

            robocizna.Leave += currency;
            dodatki.Leave += currency;
            ciecie.Leave += currency;

            cm.Leave += currency;
            cc.Leave += currency;

            zawias1.Leave += currency;
            zawias2.Leave += currency;

            cp44.Leave += currency;
            cpr88.Leave += currency;
            wozki.Leave += currency;
            kieszen.Leave += currency;


            

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
            dodatki.Text = "";
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
        private void update()
        {
            double z1, z2;
            double mn = 0;
            double mb = 0;
            double pow = 0;
            double mnp = 0;
            double mbp = 0;
            double powp = 0;
            double kosztm = 0;
            double kosztc = 0;

            //masa brutto
            double l1 = 0;
            double l2 = 0;
            double l3 = 0;
            double l4 = 0;

            if (textBox1.Text != "")
                l1 = Convert.ToDouble(textBox1.Text);

            if (textBox3.Text != "")
                l2 = Convert.ToDouble(textBox3.Text);

            if (textBox5.Text != "")
                l3 = Convert.ToDouble(textBox5.Text);

            if (textBox7.Text != "")
                l4 = Convert.ToDouble(textBox7.Text);

            //masa netto
            double ln1 = 0;
            double ln2 = 0;
            double ln3 = 0;
            double ln4 = 0;

            if (textBox2.Text != "")
                ln1 = Convert.ToDouble(textBox2.Text);

            if (textBox4.Text != "")
                ln2 = Convert.ToDouble(textBox4.Text);

            if (textBox6.Text != "")
                ln3 = Convert.ToDouble(textBox6.Text);

            if (textBox8.Text != "")
                ln4 = Convert.ToDouble(textBox8.Text);

            //dla plskownikow
            //masa brutto
            double lp1 = 0;
            double lp2 = 0;
            double lp3 = 0;

            if (textBoxp1.Text != "")
                lp1 = Convert.ToDouble(textBoxp1.Text);

            if (textBoxp3.Text != "")
                lp2 = Convert.ToDouble(textBoxp3.Text);

            if (textBoxp5.Text != "")
                lp3 = Convert.ToDouble(textBoxp5.Text);

            //masa netto
            double lnp1 = 0;
            double lnp2 = 0;
            double lnp3 = 0;

            if (textBoxp2.Text != "")
                lnp1 = Convert.ToDouble(textBoxp2.Text);

            if (textBoxp4.Text != "")
                lnp2 = Convert.ToDouble(textBoxp4.Text);

            if (textBoxp6.Text != "")
                lnp3 = Convert.ToDouble(textBoxp6.Text);


            //obliczenia profili
            if (radioButton1.Checked)
            {
                if (masa1.Text != "brak podanego profilu")
                {
                    mb = m1 * l1;
                    masab.Text = Convert.ToString(mb);
                    masab.ForeColor = System.Drawing.Color.Black;

                    mn = m1 * ln1;
                    masan.Text = Convert.ToString(mn);
                    masan.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    pow = p1*ln1;
                }
                else
                {
                    masab.ForeColor = System.Drawing.Color.Red;
                    masan.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;

                }
            }
            else if (radioButton2.Checked)
            {
                if (masa1.Text != "brak podanego profilu" && masa2.Text != "brak podanego profilu")
                {
                    mb = m1 * l1 + m2 * l2;
                    masab.Text = Convert.ToString(mb);
                    masab.ForeColor = System.Drawing.Color.Black;


                    mn = m1 * ln1 + m2 * ln2;
                    masan.Text = Convert.ToString(mn);
                    masan.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    pow = p1*ln1 + p2*ln2;
                }
                else
                {
                    masab.ForeColor = System.Drawing.Color.Red;
                    masan.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;

                }
            }
            else if (radioButton3.Checked)
            {   
                if (masa1.Text != "brak podanego profilu" && masa2.Text != "brak podanego profilu" && masa3.Text != "brak podanego profilu")
                {
                    mb = m1 * l1 + m2 * l2 + m3 * l3;
                    masab.Text = Convert.ToString(mb);
                    masab.ForeColor = System.Drawing.Color.Black;

                    mn = m1 * ln1 + m2 * ln2 + m3 * ln3;
                    masan.Text = Convert.ToString(mn);
                    masan.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    pow = p1*ln1 + p2*ln2 + p3*ln3;
                }
                else
                {
                    masab.ForeColor = System.Drawing.Color.Red;
                    masan.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;

                }
            }
            else if (radioButton4.Checked)
            {
                if (masa1.Text != "brak podanego profilu" && masa2.Text != "brak podanego profilu" && masa3.Text != "brak podanego profilu" && masa4.Text != "brak podanego profilu")
                {
                    mb = m1 * l1 + m2 * l2 + m3 * l3 + m4 * l4;
                    masab.Text = Convert.ToString(mb);
                    masab.ForeColor = System.Drawing.Color.Black;

                    mn = m1 * ln1 + m2 * ln2 + m3 * ln3 + m4 * ln4;
                    masan.Text = Convert.ToString(mn);
                    masan.ForeColor = System.Drawing.Color.Black;
                    lbltotal.ForeColor = System.Drawing.Color.Black;
                    pow = p1*ln1 + p2*ln2 + p3*ln3 + p4*ln4;

                }
                else
                {
                    masab.ForeColor = System.Drawing.Color.Red;
                    masan.ForeColor = System.Drawing.Color.Red;
                    lbltotal.ForeColor = System.Drawing.Color.Red;


                }
            }

            //dla plaskowników

            if (radioButton5.Checked)
            {
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
            }
            else if (radioButton6.Checked)
            {
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
            }
            else if (radioButton7.Checked)
            {
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
            }



            double cenac = 0;
            double cenam = 0;


            if (checkBox2.Checked)
            {
                if (cm.Text != "")
                    cenam = Double.Parse(cm.Text, NumberStyles.Currency);

                kosztm = cenam * (pow + powp) / 1000;
                lm.Text = Convert.ToString((pow + powp) / 1000);
                km.Text = string.Format("{0:c}", kosztm);
               // label31.Text = Convert.ToString(pow);
            }

            if (checkBox1.Checked)
            {
                if (cc.Text != "")
                    cenac = Double.Parse(cc.Text, NumberStyles.Currency);

                kosztc = cenac * (mn + mnp);
                lc.Text = Convert.ToString(mn + mnp);
                kc.Text = string.Format("{0:c}", kosztc);
            }


            if (textBox9.Text != "")
                kpr = Double.Parse(textBox9.Text, NumberStyles.Currency) * mb;
            else
                kpr = 0;

            kosztpr.Text = string.Format("{0:c}", kpr);


            if (textBoxp9.Text != "")
                kpl = Double.Parse(textBoxp9.Text, NumberStyles.Currency) * mbp;
            else
                kpl = 0;

            kosztpl.Text = string.Format("{0:c}", kpl);


            if (robocizna.Text != "")
                rob = Double.Parse(robocizna.Text, NumberStyles.Currency);
            else
                rob = 0;


            if (dodatki.Text != "")
                dod = Double.Parse(dodatki.Text, NumberStyles.Currency);
            else
                dod = 0;


            if (ciecie.Text != "")
                cie = Double.Parse(ciecie.Text, NumberStyles.Currency);
            else
                cie = 0;


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

                    double c44, c88;
                    double d44, d88;
                    double m44, m88;

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
                        sw.WriteLine(string.Format("Profil\t\tDł_brutto\tDł_netto\n{0}x{1}x{2,-7}\t{3}\t\t{4}", comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox1.Text, textBox2.Text));
                        if (radioButton2.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}", comboBox4.Text, comboBox5.Text, comboBox6.Text, textBox3.Text, textBox4.Text));

                        }
                        else if (radioButton3.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}", comboBox4.Text, comboBox5.Text, comboBox6.Text, textBox3.Text, textBox4.Text));
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}", comboBox7.Text, comboBox8.Text, comboBox9.Text, textBox5.Text, textBox6.Text));
                        }
                        else if (radioButton4.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}", comboBox4.Text, comboBox5.Text, comboBox6.Text, textBox3.Text, textBox4.Text));
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}", comboBox7.Text, comboBox8.Text, comboBox9.Text, textBox5.Text, textBox6.Text));
                            sw.WriteLine(string.Format("{0}x{1}x{2,-7}\t{3}\t\t{4}", comboBox10.Text, comboBox11.Text, comboBox12.Text, textBox7.Text, textBox8.Text));
                        }
                        sw.WriteLine(string.Format("Masa_brutto\tMasa_netto\tKoszt\n{0,-16}{1,-16}{2,-16}\n\n", masab.Text, masan.Text, kosztpr.Text));
                    }

                    //Płaskowniki
                    if (kpl>0)
                    {
                        sw.WriteLine(string.Format("Płaskownik\tDł_brutto\tDł_netto\n{0}x{1,-7}\t{2}\t\t{3}", comboBoxp1.Text, comboBoxp2.Text, textBoxp1.Text, textBoxp2.Text));
                        if (radioButton6.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1,-7}\t{2}\t\t{3}", comboBoxp11.Text, comboBoxp21.Text, textBoxp3.Text, textBoxp4.Text));
                        }
                        else if (radioButton7.Checked)
                        {
                            sw.WriteLine(string.Format("{0}x{1,-7}\t{2}\t\t{3}", comboBoxp11.Text, comboBoxp21.Text, textBoxp3.Text, textBoxp4.Text));
                            sw.WriteLine(string.Format("{0}x{1,-7}\t{2}\t\t{3}", comboBoxp12.Text, comboBoxp22.Text, textBoxp5.Text, textBoxp6.Text));
                        }
                        sw.WriteLine(string.Format("Masa_brutto\tMasa_netto\tKoszt\n{0,-16}{1,-16}{2,-16}\n\n", masabp.Text, masanp.Text, kosztpl.Text));
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
                    if (dodatki.Text != "")
                        sw.WriteLine(string.Format("Dodatki (groty, wzory, itp.) - {0}", dodatki.Text));
                    if (ciecie.Text != "")
                        sw.WriteLine(string.Format("Cięcie plazmowe {0}",  ciecie.Text));

                    sw.WriteLine(string.Format("TOTAL - {0}\n", lbltotal.Text));


                }
            }
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


            clear();
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //furtka
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

            clear();
            update();
        }

        private void btnb_Click(object sender, EventArgs e)
        {
            //brama
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


            clear();
            update();


        }

        private void btnbp_Click(object sender, EventArgs e)
        {
            //przesuwna
            tab = 3;

            btnbp.Enabled = false;
            btnbs.Enabled = true;

            panelfurtki.Visible = false;
            panelbramy.Visible = true;
            panelwozki.Visible = true;
            panelzz.Visible = false;

            clear();
            update();
        }

        private void btnbs_Click(object sender, EventArgs e)
        {
            //skrydlowa
            tab = 4;

            btnbs.Enabled = false;
            btnbp.Enabled = true;

            panelfurtki.Visible = true;
            panelbramy.Visible = false;
            panelprzemek.Visible = false;
            panelwozki.Visible = false;
            panelzz.Visible = true;

            clear();
            update();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Height = 95;
            update();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Height = 170;
            update();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Height = 245;
            update();

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Height = 320;
            update();

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill1();
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
            panel10.Height = 95;
            panel12.Location = new System.Drawing.Point(602, 180);
            panel12.Height = 240;
            update();

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            panel10.Height = 170;
            panel12.Location = new System.Drawing.Point(602, 255);
            panel12.Height = 165;
            update();

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
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
