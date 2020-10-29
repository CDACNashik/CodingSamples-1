using HR;
using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		
		if(args.Length > 0)
		{
			var dept = new Department{Title = args[0]};
			dept.AddEmployee(5, 45000);
			dept.AddEmployee(7, 76000);
			dept.AddEmployee(6, 65000);	
			dept.AddEmployee(4, 43000);
			dept.AddEmployee(2, 21000);

			var output = new FileStream("dept.dat", FileMode.Create);
			serializer.Serialize(output, dept);
			output.Close();
		}
		else
		{
			var input = new FileStream("dept.dat", FileMode.Open);
			var dept = (Department)serializer.Deserialize(input);
			input.Close();
			
			Console.WriteLine("Employees of {0} department", dept.Title);
			foreach(var emp in dept.Employees)
				Console.WriteLine(emp);
		}
	}
}
