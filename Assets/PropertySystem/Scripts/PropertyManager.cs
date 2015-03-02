using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertyManager : MonoBehaviour 
{
	public string className;
	public string contentName;

	private PropertyClass _class;
	private Dictionary<string, PropertyBase> _properties = null;

	void Start()
	{
		_class = GlobalManager.instance.getPropertyClass(className);
		if (_class != null) _properties = _class.cloneProperties();
	}

	public string toJsonString()
	{
		return null;
	}

	public void fromJsonString(string jsonString)
	{
	}
}
