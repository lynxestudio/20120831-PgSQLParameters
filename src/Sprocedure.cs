using System;
using Npgsql;
using System.Data;
using NpgsqlTypes;

namespace Samples{
public class Sprocedure{
public static int Main(string[] args){
 int paramValue = 66;
 string conStr = "Server=127.0.0.1;Port=5432;Database=Test;User 
ID=postgres;Password=Pa$$W0rd";
 string commandText = "createrefnum";
try {
 using(NpgsqlConnection conn = new NpgsqlConnection(conStr)){
 conn.Open();
 using(NpgsqlCommand cmd = new NpgsqlCommand(commandText,conn))
 {
 cmd.CommandType = CommandType.StoredProcedure;
 cmd.Parameters.Add("createref",NpgsqlDbType.Integer).Value= paramValue;
 string nref = cmd.ExecuteScalar().ToString();
 Console.WriteLine("Output: {0}",nref);
 }
 }
 }
 catch(Exception e)
 {
  Console.WriteLine(e.Message);
 }
 return 0;
}
}
}
