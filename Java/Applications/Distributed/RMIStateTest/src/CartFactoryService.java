package shopping;

import java.rmi.*;

public class CartFactoryService extends java.rmi.server.UnicastRemoteObject implements CartFactory {

	public CartFactoryService() throws RemoteException {
		super();
	}

	public Cart create() throws RemoteException {
		return new CartService();
	}
}

