using System.Collections.Generic;

public class PropertyClass
{
	private string _className;
	public string className
	{
		get { return _className; }
		set { _className = value; }
	}
	private Dictionary<string, PropertyBase> _properties = new Dictionary<string, PropertyBase>();

	public void addProperty(PropertyBase property)
	{
		if (!_properties.ContainsKey(property.name))
		{
			_properties.Add(property.name, property);
		}
	}
}
