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

	PropertyClass(string name)
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

	public void loadFromFile(string fileName)
	{
		Debug.LogError("load propertyclass from: " + fileName);
	}
}
