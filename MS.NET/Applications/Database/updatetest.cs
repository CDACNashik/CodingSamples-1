using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
	public static void Main(string[] args)
	{
		string sql = "UPDATE Product SET Stock=Stock+5 WHERE ProductNo=" + int.Parse(args[0]);
		
		var con = new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=True");
		con.Open();

		var cmd = new SqlCommand(sql, con);
		int n = cmd.ExecuteNonQuery();		
		if(n > 0)
			Console.WriteLine("Product updated.");
		else
			Console.WriteLine("No such product!");

		con.Close();
		
	}
}
