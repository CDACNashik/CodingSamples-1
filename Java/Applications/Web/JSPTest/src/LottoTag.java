package basic.web.app;

import java.io.*;
import java.util.*;
import java.text.*;
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;

public class LottoTag extends SimpleTagSupport {
	
	private String name;
	private int digits = 8;

	public void setVar(String name) {
		this.name = name;
	}

	public void setDigits(int digits) {
		this.digits = digits;
	}

	@Override
	public void doTag() throws JspException, IOException {
		Random rdm = new Random();
		JspContext context = getJspContext();
		JspFragment body = getJspBody();
		for(int i = 0; i < digits; ++i) {
			int digit = rdm.nextInt(10);
			context.setAttribute(name, digit);
			body.invoke(null);
		}
	}

}




