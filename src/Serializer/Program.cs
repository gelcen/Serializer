using System;
using System.IO;
using System.Xml;

namespace Serializer
{
	class Program
	{
		static int Main(string[] args)
		{
			try
			{
				if (args.Length < 2)
				{
					Console.WriteLine("Incorrect number of arguments. Please enter two arguments.");
					return 1;
				}

				XmlDocument doc = new();
				doc.Load(args[0]);

				var serializer = new Serializer(doc);
				string jsonText = serializer.SerializeToJson();

				File.WriteAllText(args[1], jsonText);
				Console.WriteLine($"{args[0]} is successfully serialized to {args[1]} json file.");

				return 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return 1;
			}
		}
	}
}
