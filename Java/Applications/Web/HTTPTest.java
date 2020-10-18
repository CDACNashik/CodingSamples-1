import java.util.*;
import java.io.*;
import java.net.*;

class HTTPTest {

	public static void main(String[] args) throws Exception{
		var listener = new ServerSocket(8055);
		for(int i = 0; i < 3; ++i){
			var child = new Thread(() -> {
				try{
					service(listener);
				}catch(IOException e){} 
			});
			child.start();
		}
	}

	private static void service(ServerSocket server) throws IOException{
		String[] items = {"cpu", "hdd", "keyboard", "motherboard", "mouse", "ram"};
		double[] prices = {18000, 4500, 850, 6200, 450, 2400};
		int[] stocks = {25, 38, 150, 25, 120, 65};
		//Arrays.sort(items);
		for(;;){
			Socket client = server.accept();
			client.setSoTimeout(60000);
			InputStream input = client.getInputStream();
			OutputStream output = client.getOutputStream();
			BufferedReader reader = new BufferedReader(
				new InputStreamReader(input));
			PrintWriter writer = new PrintWriter(
				new OutputStreamWriter(output), true);
			try{
				String line = reader.readLine();
				while(reader.readLine().length() > 0);
				String item = line.split(" ")[1].substring(1);
				int i = Arrays.binarySearch(items, item);
				if(i >= 0){
					writer.print("HTTP/1.0 200 OK\r\n");
					writer.print("Content-type: text/plain\r\n\r\n");
					writer.printf("price=%.2f&stock=%d", prices[i], stocks[i]);
				}else{
					writer.print("HTTP/1.0 404 Not Found\r\n\r\n");
				}
			}catch(Exception e){}
			writer.close();
			reader.close();
			client.close();
		}
	}
}


