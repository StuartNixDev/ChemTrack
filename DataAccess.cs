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

        public void UpdateProduct( int ProductID, string ProductName, double SG, string UN_Number, string Classification, string MarinePollutant, double Price)

        {
            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var parameters = new {ID = ProductID, name = ProductName, sg = SG, un = UN_Number, Class = Classification, MP = MarinePollutant, price = Price };
                var sql = "UPDATE Products SET ProductName = @name, SG = @sg, UN_Number = @un, Classification = @Class, MarinePollutant = @MP, Price = @price where ProductID = @ID";
                _ = connection.Query<Product>(sql, parameters);

            }
        }

        public void DeleteProduct(int id)

        {
            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var parameters = new { ID = id };
                var sql = "DELETE Products WHERE ProductID = @ID";
                _ = connection.Query<Product>(sql, parameters);

            }
        }

    }
}
