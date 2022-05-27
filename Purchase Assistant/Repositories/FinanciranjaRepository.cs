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
    public class FinanciranjaRepository
    {
        public static Financiranja GetFinanciranja(int id)
        {
            Financiranja financiranja = null;
            string sql = $"SELECT * FROM Financiranja WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql); 
            if(reader.HasRows)
            {
                reader.Read();
                financiranja = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();

            return financiranja;
        }

        public static List<Financiranja> GetFinanciranjas()
        {
            var financiranjas = new List<Financiranja>();

            string sql = "SELECT * FROM Financiranja";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while(reader.Read())
            {
                Financiranja financiranja = CreateObject(reader);
                financiranjas.Add(financiranja);
            }

            reader.Close();
            DB.CloseConnection();

            return financiranjas;
        }

        private static Financiranja CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string naziv = reader["naziv"].ToString();

            var financiranja = new Financiranja
            {
                Id = id,
                naziv = naziv
            };

            return financiranja;
        }
    }
}
