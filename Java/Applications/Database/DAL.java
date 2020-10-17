import java.sql.*;

class DAL {

	public static Connection getConnection() throws ClassNotFoundException, SQLException{
		//Class.forName("com.mysql.jdbc.Driver");
		//return DriverManager.getConnection("jdbc:mysql://localhost/sales", "root", "");
		Class.forName("oracle.jdbc.OracleDriver");
		return DriverManager.getConnection("jdbc:oracle:thin:@//localhost/xe", "scott", "tiger2");
	}
}


