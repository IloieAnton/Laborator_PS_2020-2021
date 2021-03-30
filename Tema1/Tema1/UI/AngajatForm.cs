using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tema1.BL;
using Tema1.Entities;

namespace Tema1.UI
{
    public partial class AngajatForm : Form
    {
        private ServiciuService _serviciuServer;
        private ProgramareService _programareService;
        public AngajatForm(ServiciuService serviciuService,ProgramareService programareService)
        {
            InitializeComponent();
            _serviciuServer = serviciuService;
            _programareService = programareService;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String numeClient = numeClientBox.Text;
            String data = dataBox.Text;
            String ora = oraBox.Text;
            String telefon = telefonBox.Text;
            List<String> servicii = new List<String>();
            foreach(String s in checkedListBox1.CheckedItems)
            {
                servicii.Add(s);
            }
            bool suc = _programareService.adaugareProgramare(numeClient, data, ora, telefon, servicii);
            if (suc == true)
            {
                MessageBox.Show("Inregistrare programare cu succes");
            }
            else
            {
                MessageBox.Show("Nu s-a putut inregistra programarea. Posibil sa fie o programare deja la ora asta avand cel putin un serviciu la fel.\nPosibil date introduse gresit!!\nPosibil nu s-a ales serviciu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Serviciu> servicii = _serviciuServer.afisareServicii();
            checkedListBox1.Items.Clear();
            string[] numeServicii = new string[servicii.Count];
            int i = 0;
            foreach(Serviciu serviciu in servicii)
            {
                numeServicii[i] = serviciu.getNume();
                i++;
                
            }
            checkedListBox1.Items.AddRange(numeServicii);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String data = dataCautareBox.Text;
            if (data.Equals(""))
            {
                MessageBox.Show("Trebuie introdusa o data");
                return;
            }
            List<Programare> programari = _programareService.listaProgramari(data);
            listView1.Items.Clear();
            if (programari != null)
            {
                foreach (Programare programare in programari)
                {
                    float pret = 0.0f;
                    String servicii = "";
                    foreach (Serviciu serviciu in programare.getServicii())
                    {
                        pret += serviciu.getPret();
                        servicii = servicii + serviciu.getNume() + ", ";

                    }
                    var row = new string[] { programare.getNumeClient(), programare.getData().ToString("yyyy-MM-dd"), programare.getOra().ToString("HH:mm"),programare.getTelefon(),servicii, pret.ToString() };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = programare;

                    listView1.Items.Add(lvi);

                }
            }
            else
            {
                MessageBox.Show("Nu exista programari pe aceasta data");
            }
        }
    }
}
