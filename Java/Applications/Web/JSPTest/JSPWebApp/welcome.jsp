<jsp:useBean id="now" class="java.util.Date"/>
<html>
	<head>
		<title>JSPWebApp</title>
	</head>
	<body>
		<h1>Welcome Visitor ${param.visitor}</h1>
		<b>Time on server: </b>${now}
	</body>
</html>

