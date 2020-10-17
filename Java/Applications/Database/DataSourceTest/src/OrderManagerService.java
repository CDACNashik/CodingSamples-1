package sales;

import java.rmi.*;
import java.sql.*;
import javax.sql.*;

public class OrderManagerService extends java.rmi.server.UnicastRemoteObject implements OrderManager {

	private DataSource ds;

	public OrderManagerService(DataSource pool) throws RemoteException{
		super();
		ds = pool;
	}

	public int placeOrder(String customerId, int productNo, int quantity) throws SQLException, RemoteException {
		Connection con = ds.getConnection();
		con.setAutoCommit(false);
		try{
			Statement stmt = con.createStatement();
			stmt.executeUpdate("update counters set cur_val=cur_val+1 where ctr_name='orders'");
			ResultSet rs = stmt.executeQuery("select cur_val+1000 from counters where ctr_name='orders'");
			rs.next();
			int orderNo = rs.getInt(1);
			rs.close();
			stmt.close();
			Date today = new Date(System.currentTimeMillis());
			PreparedStatement pstmt = con.prepareStatement("insert into orders values(?, ?, ?, ?, ?)");
			pstmt.setInt(1, orderNo);
			pstmt.setDate(2, today);
			pstmt.setString(3, customerId);
			pstmt.setInt(4, productNo);
			pstmt.setInt(5, quantity);
			pstmt.executeUpdate();
			pstmt.close();
			con.commit();
			return orderNo;
		}catch(SQLException e){
			con.rollback();
			throw e;
		}finally{
			con.close();
		}
	}	
}

