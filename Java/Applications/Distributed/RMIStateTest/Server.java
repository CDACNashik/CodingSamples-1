import java.rmi.*;

class Server {

	public static void main(String[] args) throws Exception {
		Naming.rebind("cartFactory", new shopping.CartFactoryService());
	}
}

