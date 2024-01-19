using AuthAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPP.Controller
{
    public class GenderController
    {
        Connection connection = new Connection();
        public List<Genders> GetGenders()
        {
            try
            {
                var genders = connection.auth.Genders.ToList();
                return genders;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
