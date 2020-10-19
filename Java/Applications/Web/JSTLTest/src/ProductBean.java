package sales.web.app;

import java.util.*;
import java.sql.*;
import javax.sql.*;
import javax.naming.*;

public class ProductBean implements java.io.Serializable {

	public List<ProductEntry> getEntries() throws NamingException, SQLException {
		List<ProductEntry> products = new ArrayList<>();
		Context naming = new InitialContext();
		DataSource ds = (DataSource)naming.lookup("jdbc/SalesDB");
		try(Connection con = ds.getConnection()){
			Statement stmt = con.createStatement();
			ResultSet rs = stmt.executeQuery("select pno, price, stock from products");
			while(rs.next())
				products.add(new ProductEntry(rs));
			rs.close();
			stmt.close();
		}
		return products;
	}

	public static class ProductEntry {
		
		private int productNo;
		private double price;
		private int stock;

		ProductEntry(ResultSet rs) throws SQLException{
			productNo = rs.getInt("pno");
			price = rs.getDouble("price");
			stock = rs.getInt("stock");
		}

		public final int getProductNo() { return productNo; }

		public final double getPrice() { return price; }

		public final int getStock() { return stock; }
	}
}


