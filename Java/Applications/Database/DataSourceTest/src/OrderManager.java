package sales;

import java.rmi.*;

public interface OrderManager extends Remote {

	int placeOrder(String customerId, int productNo, int quantity) throws java.sql.SQLException, RemoteException;
}

