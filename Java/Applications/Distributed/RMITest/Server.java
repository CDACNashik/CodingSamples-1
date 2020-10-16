import java.rmi.*;

class Server {

	public static void main(String[] args) throws Exception {
		Naming.rebind("shopKeeper", new shopping.ShopKeeperService());
	}
}

