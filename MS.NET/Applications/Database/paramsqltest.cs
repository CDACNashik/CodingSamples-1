using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{

	public static void Main(string[] args)
	{
		string customerId = args[0].ToUpper();
		int productNo = int.Parse(args[1]);
		int quantity = int.Parse(args[2]);
	
		var con = new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=True");
		con.Open();
	
		var cmd = con.CreateCommand();
		cmd.Transaction = con.BeginTransaction();

		try
		{
			cmd.CommandText = "UPDATE Counters SET CurrentValue=CurrentValue+1 WHERE Id='order'";
			cmd.ExecuteNonQuery();
			cmd.CommandText = "SELECT CurrentValue+1000 FROM Counters WHERE Id='order'";
			int orderNo = (int)cmd.ExecuteScalar();
			cmd.CommandText = "INSERT INTO OrderDetail VALUES(@orderId, @orderDate, @customer, @product, @quantity)";
			cmd.Parameters.AddWithValue("@orderId", orderNo);
			cmd.Parameters.AddWithValue("@orderDate", DateTime.Today);
			cmd.Parameters.AddWithValue("@customer", customerId);
			cmd.Parameters.AddWithValue("@product", productNo);
			cmd.Parameters.AddWithValue("@quantity", quantity);
			cmd.ExecuteNonQuery();
			cmd.Transaction.Commit();
			Console.WriteLine("New Order Number: {0}", orderNo);
		}
		catch(SqlException ex)
		{
			cmd.Transaction.Rollback();
			Console.WriteLine("Order Failed: {0}", ex.Message);
		}

		con.Close();
		
	}
}
