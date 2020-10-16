package shopping;

import java.util.*;
import java.rmi.*;

public class ShopKeeperService extends java.rmi.server.UnicastRemoteObject implements ShopKeeper {

	public ShopKeeperService() throws RemoteException {
		super(); //exports this object
	}

	public ItemInfo getItemInfo(String item) throws RemoteException {
		String[] items = {"cpu", "hdd", "keyboard", "motherboard", "mouse", "ram"};
		double[] prices = {18000, 4500, 850, 6200, 450, 2400};
		int[] stocks = {25, 38, 150, 25, 120, 65};
		int i = Arrays.binarySearch(items, item);
		if(i >= 0){
			ItemInfo info = new ItemInfo();
			info.unitPrice = prices[i];
			info.currentStock = stocks[i];
			return info;
		}
		return null;
	}

	public float getBulkDiscount(int quantity) throws RemoteException {
		return quantity < 3 ? 0 : 15; 
	}

}

