using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebApiBet.DAO.Entities;

namespace WebApiBet.DAO
{
    public class DbContext
    {
        public DbContext()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        public IEnumerable<Roulette> GetRoulettes()
        {
            List<Roulette> roulettes = new List<Roulette>();

            try
            {
                using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("SQL")))
                {
                    SqlCommand cmd = new SqlCommand("select IdRoulette, Status, NumWinner from Roulette", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Roulette roulette = new Roulette();
                        roulette.IdRoulette = Convert.ToInt32(dr["IdRoulette"]);
                        roulette.Status = Convert.ToInt32(dr["Status"]);
                        roulette.NumWinner = Convert.ToInt32(dr["NumWinner"]);

                        roulettes.Add(roulette);
                    }
                    con.Close();
                }
                return roulettes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int insertRoulette(Roulette roulette)
        {
            int idRouletteCreated = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("SQL")))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Roulette" +
                                                    "(Status,NumWinner)" +
                                                    "VALUES(@Status,@NumWinner);" +
                                                    "SELECT SCOPE_IDENTITY()", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Status", roulette.Status);
                    cmd.Parameters.AddWithValue("@NumWinner", roulette.NumWinner);
                    idRouletteCreated = Convert.ToInt32(cmd.ExecuteScalar());
                    return idRouletteCreated;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool updateStateRoulette(int idRoulette)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("SQL")))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Roulette " +
                                                    "SET Status = @Status " +
                                                    "WHERE IdRoulette = @IdRoulette", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Status", 1);
                    cmd.Parameters.AddWithValue("@IdRoulette", idRoulette);
                    var rowsAfected = cmd.ExecuteNonQuery();
                    if (rowsAfected == 0)
                    {
                        return false;
                    }
                    
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
    }
}
