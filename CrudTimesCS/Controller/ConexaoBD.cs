using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTimesCS.controler
{
    class ConexaoBD
    {
        public static string conectar()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pedro.hssilva52\source\repos\CrudTimesCS\CrudTimesCS\BDTimesCS.mdf;Integrated Security=True";
        }
    }
}
