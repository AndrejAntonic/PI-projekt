using DBLayer;
using Purchase_Assistant.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase_Assistant.Repositories
{
    public class ZaposlenikRepository
    {
        public static Zaposlenik GetZaposlenik(int id)
        {
            Zaposlenik zaposlenik = null;
            string sql = $"SELECT * FROM Zaposlenik WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if(reader.HasRows)
            {
                reader.Read();
                zaposlenik = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return zaposlenik;
        }

        public static List<Zaposlenik> GetZaposleniks()
        {
            var zaposleniks = new List<Zaposlenik>();

            string sql = "SELECT * FROM Zaposlenik";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while(reader.Read())
            {
                Zaposlenik zaposlenik = CreateObject(reader);
                zaposleniks.Add(zaposlenik);
            }

            reader.Close();
            DB.CloseConnection();

            return zaposleniks;
        }

        private static Zaposlenik CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string firstName = reader["Ime"].ToString();
            string lastName = reader["Prezime"].ToString();
            string mail = reader["Mail"].ToString();

            
            var zaposlenik = new Zaposlenik
            {
                Id = id,
                Ime = firstName,
                Prezime = lastName,
                Mail = mail
            };

            return zaposlenik;
        }
    }
}
