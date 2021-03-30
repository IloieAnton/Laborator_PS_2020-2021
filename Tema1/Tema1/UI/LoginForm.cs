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
using Tema1.DAO;
using Tema1.Entities;
using Tema1.UI;

namespace Tema1
{
    public partial class LoginForm : Form
    {
        private UserService _userService;
        private ServiciuService _serviciuService;
        private ProgramareService _programareService;
        public LoginForm(UserService userService,ServiciuService serviciuService,ProgramareService programareService)
        {
            _userService = userService;
            _serviciuService = serviciuService;
            _programareService = programareService;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String parola = textBox2.Text;


            User u = _userService.login(username, parola);
            if (u == null)
            {
                MessageBox.Show("Username gresit sau parola gresita!");
            }
            else
            {
                if (u.getRol() == "admin")
                {
                    AdminForm resForm = new AdminForm(_userService,_serviciuService,_programareService);
                    resForm.Show();
                }
                else
                {
                    AngajatForm resForm = new AngajatForm(_serviciuService,_programareService);
                    resForm.Show();
                }
            }
        }
    }
}
