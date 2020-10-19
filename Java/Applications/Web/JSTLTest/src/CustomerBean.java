package sales.web.app;

import java.util.*;
import java.sql.*;
import javax.sql.*;
import javax.naming.*;

public class CustomerBean implements java.io.Serializable {

	private String id;

	public final String getId() { return id; }

	public boolean authenticate(String customerId, String password) throws SQLException, NamingException {
		Context naming = new InitialContext();
		DataSource ds = (DataSource)naming.lookup("jdbc/SalesDB");
		try(Connection con = ds.getConnection()){
			PreparedStatement stmt = con.prepareStatement("select count(cust_id) from customers where cust_id=? and pwd=?");
			stmt.setString(1, customerId);
			stmt.setString(2, password);
			ResultSet rs = stmt.executeQuery();
			rs.next();
			int count = rs.getInt(1);
			rs.close();
			stmt.close();
			if(count == 1){
				id = customerId;
				return true;
			}
			id = null;
			return false;
		}
	}
	
	public int placeOrder(int productNo, int quantity) throws SQLException, NamingException {
		Context naming = new InitialContext();
		DataSource ds = (DataSource)naming.lookup("jdbc/SalesDB");
		try(Connection con = ds.getConnection()){
			CallableStatement stmt = con.prepareCall("{call PLACE_ORDER(?, ?, ?, ?)}");
			stmt.setString(1, id);
			stmt.setInt(2, productNo);
			stmt.setInt(3, quantity);
			stmt.registerOutParameter(4, Types.INTEGER);
			stmt.execute();
			int orderNo = stmt.getInt(4);
			stmt.close();
			return orderNo;
		}

	}

	public List<OrderEntry> getInvoice() throws SQLException, NamingException {
		List<OrderEntry> invoice = new ArrayList<>();
		Context naming = new InitialContext();
		DataSource ds = (DataSource)naming.lookup("jdbc/SalesDB");
		try(Connection con = ds.getConnection()){
			PreparedStatement stmt = con.prepareStatement("select ord_date, pno, qty from orders where cust_id=?");
			stmt.setString(1, id);
			ResultSet rs = stmt.executeQuery();
			while(rs.next())
				invoice.add(new OrderEntry(rs));
			rs.close();
			stmt.close();
		}
		return invoice;
	}

	public static class OrderEntry {
		
		private int productNo;
		private java.sql.Date orderDate;
		private int quantity;

		OrderEntry(ResultSet rs) throws SQLException{
			productNo = rs.getInt("pno");
			orderDate = rs.getDate("ord_date");
			quantity = rs.getInt("qty");
		}

		public final int getProductNo() { return productNo; }

		public final java.sql.Date getOrderDate() { return orderDate; }

		public final int getQuantity() { return quantity; }
	}
}


