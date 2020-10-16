import java.io.*;
import java.net.*;

class SocketTest {

	public static void main(String[] args) throws Exception {
		if(args.length < 2) {
			System.out.println("USAGE: java SocketTest item quantity [server=localhost]");
			System.exit(0);
		}
		String item = args[0].toLowerCase();
		int quantity = Integer.parseInt(args[1]);
		String host = args.length > 2 ? args[2] : "localhost"; 
		Socket client = new Socket(host, 2055);
		InputStream input = client.getInputStream();
		OutputStream output = client.getOutputStream();
		BufferedReader reader = new BufferedReader(new InputStreamReader(input));
		PrintWriter writer = new PrintWriter(new OutputStreamWriter(output));
		System.out.println(reader.readLine());
		writer.println(item);
		writer.flush();
		String response = reader.readLine();
		writer.close();
		reader.close();
		client.close();
		if(response != null){
			String[] info = response.split("&");
			double price = Double.parseDouble(info[0].substring(6));
			int stock = Integer.parseInt(info[1].substring(6));
			if(quantity <= stock)
				System.out.printf("Total Payment: %.2f%n", quantity * price);
			else
				System.out.println("Out of stock!");
		}else{
			System.out.println("Not available!");
		}
	}
}

