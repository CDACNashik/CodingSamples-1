import java.sql.*;

class UpdateTest {

	public static void main(String[] args) throws Exception{
		String sql = "update products set stock=stock+5 where pno=" + Integer.parseInt(args[0]);
		Connection con = DAL.getConnection();
		Statement stmt = con.createStatement();
		int n = stmt.executeUpdate(sql);
		stmt.close();
		con.close();
		if(n > 0)
			System.out.println("Product updated.");
		else
			System.out.println("No such product!");
	}
}

