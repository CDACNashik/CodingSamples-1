import shopping.*;
import java.rmi.*;

class Client {
	
	public static void main(String[] args) throws Exception {
		String item = args[0].toLowerCase();
		int quantity = Integer.parseInt(args[1]);
		ShopKeeper stub = (ShopKeeper)Naming.lookup("rmi://localhost/shopKeeper");
		ItemInfo info = stub.getItemInfo(item);
		if(info != null){
			if(quantity <= info.currentStock){
				float discount = stub.getBulkDiscount(quantity);
				System.out.printf("Total Payment: %.2f%n", quantity * info.unitPrice * (1 - discount / 100));
			}else{
				System.out.println("Out of stock!");
			}
		}else{
			System.out.println("Not available!");
		}
	}
}


