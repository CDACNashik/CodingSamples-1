import java.sql.*;

class StoredProcTest {

	private static int placeOrder(String customerId, int productNo, int quantity) throws Exception {
		Connection con = DAL.getConnection();
		try{
			CallableStatement cstmt = con.prepareCall("{call PLACE_ORDER(?, ?, ?, ?)}");
			cstmt.setString(1, customerId);
			cstmt.setInt(2, productNo);
			cstmt.setInt(3, quantity);
			cstmt.registerOutParameter(4, Types.INTEGER);
			cstmt.execute();
			int orderNo = cstmt.getInt(4);
			cstmt.close();
			return orderNo;
		}finally{
			con.close();
		}
	}

	public static void main(String[] args) {
		String customerId = args[0].toUpperCase();
		int productNo = Integer.parseInt(args[1]);
		int quantity = Integer.parseInt(args[2]);
		try{
			int orderNo = placeOrder(customerId, productNo, quantity);
			System.out.printf("New Order Number: %d%n", orderNo);
		}catch(Exception e){
			System.out.printf("Order Failed: %s%n", e.getMessage());
		}
	}
}

