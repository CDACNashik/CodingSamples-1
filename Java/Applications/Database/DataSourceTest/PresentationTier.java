class PresentationTier {

	public static void main(String[] args) {
		String customerId = args[0].toUpperCase();
		int productNo = Integer.parseInt(args[1]);
		int quantity = Integer.parseInt(args[2]);
		try{
			var middleTier = (sales.OrderManager)java.rmi.Naming.lookup("rmi://localhost:2099/orderManager");
			int orderNo = middleTier.placeOrder(customerId, productNo, quantity);
			System.out.printf("New Order Number: %d%n", orderNo);
		}catch(Exception e){
			System.out.printf("Order Failed: %s%n", e.getMessage());
		}
	}
}

