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
    public class NarudzbenicaRepository
    {
        public static Narudzbenica GetNarudzbenica(int id)
        {
            Narudzbenica narudzbenica = null;

            string sql = $"SELECT * FROM Narudzbenica WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if(reader.HasRows)
            {
                reader.Read();
                narudzbenica = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return narudzbenica;
        }

        public static List<Narudzbenica> GetNarudzbenicas()
        {
            var narudzbenicas = new List<Narudzbenica>();

            string sql = "SELECT * FROM Narudzbenica";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Narudzbenica narudzbenica = CreateObject(reader);
                narudzbenicas.Add(narudzbenica);
            }

            reader.Close();
            DB.CloseConnection();

            return narudzbenicas;
        }

        private static Narudzbenica CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            int idZaposlenik = int.Parse(reader["Id_zaposlenika"].ToString());
            var zaposlenik = ZaposlenikRepository.GetZaposlenik(idZaposlenik);
            string opis_predmeta_nabave = reader["opis_predmeta_nabave"].ToString();
            string ponuditelj_1 = reader["ponuditelj_1"].ToString();
            float cijena_bez_pdv_1 = float.Parse(reader["cijena_bez_pdv_1"].ToString());
            float cijena_sa_pdv_1 = float.Parse(reader["cijena_sa_pdv_1"].ToString());
            string odabrana_1 = reader["odabrana_1"].ToString();
            string ponuditelj_2 = reader["ponuditelj_2"].ToString();
            float cijena_bez_pdv_2 = float.Parse(reader["cijena_bez_pdv_2"].ToString());
            float cijena_sa_pdv_2 = float.Parse(reader["cijena_sa_pdv_2"].ToString());
            string odabrana_2 = reader["odabrana_2"].ToString();
            int idFinanciranja = int.Parse(reader["Id_financiranja"].ToString());
            var financiranja = FinanciranjaRepository.GetFinanciranja(idFinanciranja);
            int broj_projekta = int.Parse(reader["broj_projekta"].ToString());
            string naziv_projekta = reader["naziv_projekta"].ToString();
            string voditelj_projekta = reader["voditelj_projekta"].ToString();
            string dodatno = reader["dodatno"].ToString();
            //DateTime datum = DateTime.Parse(reader["datum"].ToString());

            var narudzbenica = new Narudzbenica
            {
                Id = id,
                zaposlenik = zaposlenik,
                opis_predmeta_nabave = opis_predmeta_nabave,
                ponuditelj_1 = ponuditelj_1,
                cijena_bez_pdv_1 = cijena_bez_pdv_1,
                cijena_sa_pdv_1 = cijena_sa_pdv_1,
                odabrana_1 = odabrana_1,
                ponuditelj_2 = ponuditelj_2,
                cijena_bez_pdv_2 = cijena_bez_pdv_2,
                cijena_sa_pdv_2 = cijena_sa_pdv_2,
                odabrana_2 = odabrana_2,
                financiranje = financiranja,
                broj_projekta = broj_projekta,
                naziv_projekta = naziv_projekta,
                voditelj_projekta = voditelj_projekta,
                dodatno = dodatno
                //datum = datum
            };

            return narudzbenica;
        }

        public static void InsertNarudzbenica(int idZaposlenika, string opis, string ponuditelj_1, float cijena_bez_pdv_1, float cijena_sa_pdv_1, string odabrano_1, string ponuditelj_2, float cijena_bez_pdv_2, float cijena_sa_pdv_2, string odabrano_2, int idFinanciranja, int broj_projekta, string naziv_projekta, string voditelj, string dodatno)
        {
            //string sql = $"INSERT INTO Narudzbenica (id_zaposlenika, opis_predmeta_nabave, ponuditelj_1, cijena_bez_pdv_1, cijena_sa_pdv_1, odabrana_1, ponuditelj_2, cijena_bez_pdv_2, cijena_sa_pdv_2, odabrana_2, id_financiranja, broj_projekta, naziv_projekta, voditelj_projekta, dodatno) VALUES ({idZaposlenika}, {opis}, {ponuditelj_1}, {cijena_bez_pdv_1}, {cijena_sa_pdv_1}, {odabrano_1}, {ponuditelj_2}, {cijena_bez_pdv_2}, {cijena_sa_pdv_2}, {odabrano_2}, {idFinanciranja}, {broj_projekta}, {naziv_projekta}, {voditelj}, {dodatno})";
            string sql = $"INSERT INTO Narudzbenica VALUES ({idZaposlenika}, {opis}, {ponuditelj_1}, {cijena_bez_pdv_1}, {cijena_sa_pdv_1}, {odabrano_1}, {ponuditelj_2}, {cijena_bez_pdv_2}, {cijena_sa_pdv_2}, {odabrano_2}, {idFinanciranja}, {broj_projekta}, {naziv_projekta}, {voditelj}, {dodatno})";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void DeleteNarudzbenica(int id)
        {
            string sql = $"DELETE FROM Narudzbenica WHERE Id={id}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

    }
}
