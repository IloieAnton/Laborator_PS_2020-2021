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
    public partial class AdminForm : Form
    {
        private UserService _userService;
        private ServiciuService _serviciuServer;
        private ProgramareService _programareService;
        public AdminForm(UserService userService,ServiciuService serviciuServer, ProgramareService programareService)
        {
            _userService = userService;
            _serviciuServer = serviciuServer;
            _programareService = programareService;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nume = textBox1.Text;
            String username = textBox2.Text;
            String parola = textBox3.Text;
            if(nume.Equals("") || username.Equals("") || parola.Equals(""))
            {
                MessageBox.Show("Trebuie completate!!");
                return;
            }

            bool s = _userService.adaugareUser(username, parola, nume);

            if(s == true)
            {
                MessageBox.Show("Adaugare cu succes");
            }
            else
            {
                MessageBox.Show("Nu s-a putut adauga angajatul");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String nume = numeServiciuBox.Text;
            String pret = pretBox.Text;

            bool suc = _serviciuServer.adaugareServiciu(nume, pret);

            if (suc == true && !nume.Equals(""))
            {
                MessageBox.Show("Adaugare cu succes");
            }
            else
            {
                MessageBox.Show("Nu s-a putut adauga serviciul. Posibil ca nu ati pus formatul corect pentru pret sau nu ati completat");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String numeServiciuStergere = NumeServiucStergereBox.Text;

            bool s = _serviciuServer.stergereServiciu(numeServiciuStergere);
            if (s == true && !numeServiciuStergere.Equals(""))
            {
                MessageBox.Show("Stergere cu succes");
            }
            else
            {
                MessageBox.Show("Nu s-a putut sterge serviciul. Posibil ca nu ati completat sau nu exista acel serviciu");
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
          
        }
        private void button4_Click(object sender, EventArgs e)
        {
            List<Serviciu> servicii = _serviciuServer.afisareServicii();
            listView1.Items.Clear();
            foreach (Serviciu serviciu in servicii)
            {
                var row = new string[] { serviciu.getNume(), serviciu.getPret().ToString() };
                var lvi = new ListViewItem(row);
                lvi.Tag = serviciu;

                listView1.Items.Add(lvi);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String nume = numeServiciuBox.Text;
            String pret = pretBox.Text;

            bool s = _serviciuServer.modifcareServiciu(nume, pret);
            if (s == true && !nume.Equals(""))
            {
                MessageBox.Show("Modificare pret cu succes");
            }
            else
            {
                MessageBox.Show("Nu s-a putut modifica pretul serviciul. Posibil ca nu ati completat numele serviciului sau ati introdus format gresit la pret sau nu exista acel serviciu.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String dataInceput = dataInceputBox.Text;
            String dataFinala = dataFinalBox.Text;
            if (dataInceput.Equals("") || dataFinala.Equals(""))
            {
                MessageBox.Show("Trebuie introdusa o data");
                return;
            }
            listView2.Items.Clear();
            DateTime dataInceputP = DateTime.ParseExact(dataInceput, "yyyy-MM-dd", null);
            DateTime dataFinalaP = DateTime.ParseExact(dataFinala, "yyyy-MM-dd", null);
            while (dataInceputP.Date <= dataFinalaP.Date)
            {
                List<Programare> programari = _programareService.listaProgramari(dataInceputP.ToString("yyyy-MM-dd"));
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
                        var row = new string[] { programare.getNumeClient(), programare.getData().ToString("yyyy-MM-dd"), programare.getOra().ToString("HH:mm"), programare.getTelefon(), servicii, pret.ToString() };
                        var lvi = new ListViewItem(row);
                        lvi.Tag = programare;

                        listView2.Items.Add(lvi);

                    }
                }
                dataInceputP = dataInceputP.AddDays(1);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String numeClient = numeClientBox.Text;
            if (numeClient.Equals(""))
            {
                MessageBox.Show("Trebuie introdus un nume de client");
                return;
            }
            listView2.Items.Clear();
            List<Programare> programari = _programareService.listaProgramariClient(numeClient);
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
                    var row = new string[] { programare.getNumeClient(), programare.getData().ToString("yyyy-MM-dd"), programare.getOra().ToString("HH:mm"), programare.getTelefon(), servicii, pret.ToString() };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = programare;

                    listView2.Items.Add(lvi);

                }
            }

        }
    }
}
