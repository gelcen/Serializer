namespace Serializer
{
	public class Property
	{
		public Property(string name, string type, string value)
		{
			Name = name;
			Type = type;
			Value = value;
		}

		public string Name { get; set; }
		public string Type { get; set; }
		public string Value { get; set; }
	}
}
