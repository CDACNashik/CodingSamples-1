package basic.web.app;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

@javax.servlet.annotation.WebServlet("*.htmx")
public class HtmxServlet extends HttpServlet {

	@Override
	public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
		String path = request.getServletPath();
		String page = getServletContext().getRealPath(path);
		if(page == null)
			response.sendError(404);
		else{
			response.setContentType("text/html");
			PrintWriter out = response.getWriter();
			String time = new java.util.Date().toString();
			try(BufferedReader reader = new BufferedReader(new FileReader(page))){
				reader.lines()
					.map(l -> l.replaceAll("<x:now/>", time))
					.forEach(out::println);
			}
		}
	}

}

