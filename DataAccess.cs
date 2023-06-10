using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ChemTrack
{
    public class DataAccess
    {

        public List<Tank> GetTanks()
        {
            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var sql = "SELECT * FROM Tanks";
                var result = connection.Query<Tank>(sql);
                return (List<Tank>)result;
            }
        }

        public List<Product> GetChems()
        {
            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var sql = "SELECT * FROM Products";
                var result = connection.Query<Product>(sql);
                return (List<Product>)result;
            }
        }
    }
}
