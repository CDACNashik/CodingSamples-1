<jsp:useBean id="ctr" class="basic.web.app.CounterBean" scope="session"/>
<jsp:setProperty name="ctr" property="step" value="3"/>
<html>
	<head>
		<title>JSPWebApp</title>
	</head>
	<body>
		<h1>Welcome Visitor</h1>
		<b>Number of greetings: </b>${ctr.nextCount}
	</body>
</html>

