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

        public List<Tank> FetchTank(string TankID)
        {
            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var parameter = new { target = TankID };
                var sql = "SELECT * from Tanks where TankID = @target";
                var result = connection.Query<Tank>(sql, parameter);
                return (List<Tank>) result;
            }
        }

        public void UpdateProduct( int ProductID, string ProductName, double SG, string? UN_Number, string Classification, string MarinePollutant, double Price)

        {
            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var parameters = new {ID = ProductID, name = ProductName, sg = SG, un = UN_Number, Class = Classification, MP = MarinePollutant, price = Price };
                var sql = "UPDATE Products SET ProductName = @name, SG = @sg, UN_Number = @un, Classification = @Class, MarinePollutant = @MP, Price = @price where ProductID = @ID";
                _ = connection.Query<Product>(sql, parameters);

            }
        }
        public void UpdateTank(string TankID, int Capacity, string Dimensions, int TareWeight, int MaxGrossWeight, int OnHire)

        {
            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var parameters = new { ID = TankID, capacity = Capacity, dimensions = Dimensions, tareWeight = TareWeight, maxGrossWeight = MaxGrossWeight, onHire = OnHire };
                var sql = "UPDATE Products SET ProductName = @name, SG = @sg, UN_Number = @un, Classification = @Class, MarinePollutant = @MP, Price = @price where ProductID = @ID";
                _ = connection.Query<Tank>(sql, parameters);

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

        public void DeleteTank(string TankID)

        {
            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var parameters = new { ID = TankID };
                var sql = "DELETE Tank WHERE TankID = @ID";
                _ = connection.Query<Tank>(sql, parameters);

            }
        }

        public void AddProduct(string ProductName, double SG, string? UN_Number, string Classification, string MarinePollutant, double Price)

        {

            using IDbConnection connection = new SqlConnection(ConnAssist.ConnVal("ChemTrackDB"));
            {
                var parameters = new { name = ProductName, sg = SG, un = UN_Number, Class = Classification, MP = MarinePollutant, price = Price };
                var sql = "INSERT INTO Products (ProductName, SG, UN_Number, Classification, MarinePollutant, Price) VALUES (@name,@sg,@un,@Class,@MP,@price)";
                _ = connection.Query<Product>(sql, parameters);
            }


        }

    }
}
