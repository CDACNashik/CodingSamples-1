import java.sql.*;

class QueryTest {

	public static void main(String[] args) throws Exception{
		Connection con = DAL.getConnection();
		Statement stmt = con.createStatement();
		ResultSet rs = stmt.executeQuery("select pno, price, stock from products");
		while(rs.next())
			System.out.printf("%-6d%10.2f%8d%n", rs.getInt(1), rs.getDouble(2), rs.getInt("stock"));
		rs.close();
		stmt.close();
		con.close();
	}
}

