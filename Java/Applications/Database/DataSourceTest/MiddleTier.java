class MiddleTier {

	public static void main(String[] args) throws Exception{
		var pool = new oracle.jdbc.pool.OracleConnectionPoolDataSource();
		pool.setURL("jdbc:oracle:thin:@//localhost/xe");
		pool.setUser("scott");
		pool.setPassword("tiger2");
		java.rmi.registry.LocateRegistry.createRegistry(2099);
		java.rmi.Naming.bind("//:2099/orderManager", new sales.OrderManagerService(pool));
	}
}

