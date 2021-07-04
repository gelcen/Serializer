using System.Collections.Generic;

namespace Serializer
{
	public class ProductOccurence
	{
		public ProductOccurence(string id, string name)
		{
			Id = id;
			Name = name;
			Props = new List<Property>();
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public List<Property> Props { get; set; }
	}
}
