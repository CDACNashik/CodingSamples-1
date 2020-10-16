import java.util.*;
import java.net.*;

class DatagramSocketTest {

	public static void main(String[] args) throws Exception {
		String[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		Random gen = new Random();
		InetAddress classDDest = InetAddress.getByName("230.0.0.1");
		DatagramSocket publisher = new DatagramSocket();
		for(;;){
			int i = gen.nextInt(symbols.length);
			double p = 0.01 * (gen.nextInt(9000) + 1000);
			String msg = String.format("%s => %.2f", symbols[i], p);
			DatagramPacket packet = new DatagramPacket(msg.getBytes(), msg.length(), classDDest, 3055);
			publisher.send(packet);
			Thread.sleep(10000);
		}
	}
}

