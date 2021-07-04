using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml;

namespace Serializer
{
	public class Serializer
	{
		private readonly XmlDocument _document;

		public Serializer(XmlDocument document)
		{
			_document = document;
		}

		public string SerializeToJson()
		{
			XmlNode root = _document.DocumentElement;

			List<ProductOccurence> products = GetProductOccurences(root);

			if (products != null)
			{
				var jsonProducts = JsonConvert.SerializeObject(products);
				return jsonProducts;
			}
			else
			{
				return SerializeOtherFormatFile();
			}
		}

		private List<ProductOccurence> GetProductOccurences(XmlNode root)
		{
			List<ProductOccurence> products = null;

			root.ForEachChildWithName("ModelFile", (rootChild) =>
			{
				products = new List<ProductOccurence>();

				rootChild.ForEachChildWithName("ProductOccurence", (product) =>
				{
					var productElement = (XmlElement)product;
					var addedProduct = new ProductOccurence(productElement.GetAttribute("Id"),
						productElement.GetAttribute("Name"));
					product.ForEachChildWithName("Attributes", (attribute) =>
					{
						attribute.ForEachChildWithName("Attr", (prop) =>
						{
							var propertyElement = (XmlElement)prop;
							var property = new Property(
								propertyElement.GetAttribute("Name"),
								propertyElement.GetAttribute("Type"),
								propertyElement.GetAttribute("Value"));
							addedProduct.Props.Add(property);
						});
					});
					products.Add(addedProduct);
				});
			});

			return products;
		}

		private string SerializeOtherFormatFile()
		{
			return JsonConvert.SerializeXmlNode(_document);
		}
	}
}
