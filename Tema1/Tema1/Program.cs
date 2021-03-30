using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tema1.BL;
using Tema1.DAO;
using Tema1.DAO.programare;
using Tema1.DAO.serviciu;
using Tema1.UI;

namespace Tema1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Type obj = Type.GetType(ConfigurationManager.AppSettings["UserRepository"]);
            System.Reflection.ConstructorInfo constructor = obj.GetConstructor(new Type[] { });
            IUserDAO userRepository = (IUserDAO)constructor.Invoke(null);

            UserService userService = new UserService(userRepository);

            obj = Type.GetType(ConfigurationManager.AppSettings["ServiciuRepository"]);
            constructor = obj.GetConstructor(new Type[] { });
            IServiciuDAO serviciuRepository = (IServiciuDAO)constructor.Invoke(null);

            ServiciuService serviciuServer = new ServiciuService(serviciuRepository);

            obj = Type.GetType(ConfigurationManager.AppSettings["ProgramareServiciuRepository"]);
            constructor = obj.GetConstructor(new Type[] { });
            IProgramareServiciuDAO programareServiciuRepository = (IProgramareServiciuDAO)constructor.Invoke(null);
       

            obj = Type.GetType(ConfigurationManager.AppSettings["ProgramareRepository"]);
            constructor = obj.GetConstructor(new Type[] { });
            IProgramareDAO programareRepository = (IProgramareDAO)constructor.Invoke(null);

            ProgramareService programareService = new ProgramareService(programareRepository, serviciuRepository,programareServiciuRepository);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(userService,serviciuServer,programareService));
        }
    }
}
