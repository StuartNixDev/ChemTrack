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

        public List<Product> FetchProduct(int productID)
        {
            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var parameter = new { target = productID };
                var sql = "SELECT * from Products where ProductID = @target";
                var result = connection.Query<Product>(sql, parameter);
                return (List<Product>)result;
            }
        }

    }
}
