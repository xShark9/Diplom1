using AuthAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPP.Controller
{
    public class ClassController
    {
        Connection connection = new Connection();
        public List<Classes> GetClasses()
        {
            try
            {
                var classes = connection.auth.Classes.ToList();
                return classes;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


    }
}
