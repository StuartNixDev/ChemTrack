using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Configuration.Assemblies;

namespace ChemTrack
    
{
    public static class ConnAssist
    {

            public static string ConnVal(string name)

            {
                string output = System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString.ToString();
                return output;
            }
        
    }
}
