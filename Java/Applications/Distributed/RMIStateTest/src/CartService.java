package shopping;

import java.util.*;
import java.rmi.*;

public class CartService extends java.rmi.server.UnicastRemoteObject implements Cart {

	private double payment = 0;

	public CartService() throws RemoteException {
		super();
	}

	public boolean addItem(String item) throws RemoteException {
		String[] items = {"cpu", "hdd", "keyboard", "motherboard", "mouse", "ram"};
		double[] prices = {18000, 4500, 850, 6200, 450, 2400};
		int i = Arrays.binarySearch(items, item);
		if(i >= 0){
			payment += prices[i];
			return true;
		}
		return false;
	}

	public double checkout() throws RemoteException {
		unexportObject(this, false);
		return payment;
	}
}

