import java.io.*;
import java.net.*;

class URLTest {

	public static void main(String[] args) throws Exception {
		if(args.length < 2) {
			System.out.println("USAGE: java URLTest item quantity [server=localhost]");
			System.exit(0);
		}
		String item = args[0].toLowerCase();
		int quantity = Integer.parseInt(args[1]);
		String host = args.length > 2 ? args[2] : "localhost"; 
		URL site = new URL("http://" + host + ":8055/" + item);
		try{
			InputStream input = site.openStream();
			BufferedReader reader = new BufferedReader(new InputStreamReader(input));
			String response = reader.readLine();
			String[] info = response.split("&");
			double price = Double.parseDouble(info[0].substring(6));
			int stock = Integer.parseInt(info[1].substring(6));
			if(quantity <= stock)
				System.out.printf("Total Payment: %.2f%n", quantity * price);
			else
				System.out.println("Out of stock!");
			reader.close();
		}catch(FileNotFoundException e){
			System.out.println("Not Available!");
		}
	}
}

