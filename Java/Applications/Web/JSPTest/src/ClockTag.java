package basic.web.app;

import java.io.*;
import java.util.*;
import java.text.*;
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;

public class ClockTag implements SimpleTag {

	private JspContext context;
	private JspFragment body;
	private JspTag parent;

	public void setJspContext(JspContext context) { this.context = context; }

	public void setJspBody(JspFragment body) { this.body = body; }

	public void setParent(JspTag parent) { this.parent = parent; }

	public JspTag getParent() { return parent; }

	public void doTag() throws JspException, IOException {
		JspWriter out = context.getOut();
		Date now = new Date();
		out.print(formatter.format(now));
	}

	private SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

	public void setFormat(String format) {
		formatter.applyPattern(format);
	}


}




