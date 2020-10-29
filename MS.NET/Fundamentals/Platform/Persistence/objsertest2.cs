using HR;
using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Department));
		
		if(args.Length > 0)
		{
			var dept = new Department{Title = args[0]};
			dept.AddEmployee(5, 45000);
			dept.AddEmployee(7, 76000);
			dept.AddEmployee(6, 65000);	
			dept.AddEmployee(4, 43000);
			dept.AddEmployee(2, 21000);

			var output = new FileStream("dept.xml", FileMode.Create);
			serializer.Serialize(output, dept);
			output.Close();
		}
		else
		{
			var input = new FileStream("dept.xml", FileMode.Open);
			var dept = (Department)serializer.Deserialize(input);
			input.Close();
			
			Console.WriteLine("Employees of {0} department", dept.Title);
			foreach(var emp in dept.Employees)
				Console.WriteLine(emp);
		}
	}
}
