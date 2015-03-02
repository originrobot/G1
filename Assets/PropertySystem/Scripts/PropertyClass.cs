using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public class PropertyClass
{
	private string _className;
	public string className
	{
		get { return _className; }
		set { _className = value; }
	}
	private Dictionary<string, PropertyBase> _properties = new Dictionary<string, PropertyBase>();
	public Dictionary<string, PropertyBase> properties
	{
		get { return _properties; }
	}

	public PropertyClass(string name)
	{
		_className = name;
	}

	public void addProperty(PropertyBase property)
	{
		if (!_properties.ContainsKey(property.name))
		{
			_properties.Add(property.name, property);
		}
	}

	public Dictionary<string, PropertyBase> cloneProperties()
	{
		Dictionary<string, PropertyBase> results = new Dictionary<string, PropertyBase>();
		foreach (PropertyBase prop in _properties.Values)
		{
			PropertyBase clonedProp = prop.clone();
			results.Add(clonedProp.name, clonedProp);
		}

		return results;
	}
}
