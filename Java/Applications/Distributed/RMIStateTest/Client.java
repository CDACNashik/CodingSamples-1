import shopping.*;

import java.util.*;
import java.rmi.*;

class Client {

	public static void main(String[] args) throws Exception {
		Scanner input = new Scanner(System.in);
		CartFactory factoryStub = (CartFactory) Naming.lookup("rmi://localhost/cartFactory");
		Cart cartStub = factoryStub.create();
		for(int i = 1 ;; ++i) {
			System.out.printf("Item %d: ", i);
			String item = input.nextLine();
			if(item.length() == 0) break;
			System.out.printf("Adding %s to the cart...", item);
			if(cartStub.addItem(item))
				System.out.println("Succeeded.");
			else
				System.out.println("Failed!");
		}
		System.out.printf("Total Payment: %.2f%n", cartStub.checkout());
	}
}

