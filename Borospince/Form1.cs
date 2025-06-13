using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Borospince
{
    public partial class Form1 : Form
    {
        private Szekreny szekreny = new Szekreny();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fajta = tbFajta.Text.Trim();
                int evjarat = int.Parse(numEvjarat.Text);
                double alkohol = double.Parse(numAlkohol.Text);

                Bor bor = new Bor(fajta, evjarat, alkohol);
                szekreny += bor;

                listBox1.Items.Add(bor);
            }
            
            catch (Exception)
            {
                labelKiir.Text = "Hibás adatbevitel!";
            }
            finally
            {
                tbFajta.Clear();
                numAlkohol.Value = numAlkohol.Minimum;
                numEvjarat.Value = numEvjarat.Minimum;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Bor bor)
            {
                try
                {
                    szekreny.Megisszak(bor);
                    listBox1.Items.Remove(bor);
                }
                catch (BorospinceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nincs elem kiválasztva!");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            var statisztika = szekreny.Statisztika();
            foreach (var kvp in statisztika)
            {
                labelKiir.Text += $"{kvp.Key}: {kvp.Value}\n";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double atlag_alkohol = szekreny.Atlag_alkoholtartalom(szekreny);
                labelKiir.Text = $"Az átlag alkoholtartalom: {atlag_alkohol}%";
            }
            catch(BorospinceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
