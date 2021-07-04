using System;
using System.Xml;

namespace Serializer
{
	public static class XmlNodeExtensions
	{
		public static void ForEachChildWithName(this XmlNode node, string name, Action<XmlNode> action)
		{
			if (!node.HasChildNodes)
				return;
			for (int i = 0; i < node.ChildNodes.Count; i++)
			{
				if (node.ChildNodes[i].Name == name)
					action(node.ChildNodes[i]);
			}
		}
	}
}
