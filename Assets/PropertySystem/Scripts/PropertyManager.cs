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
		if (_properties == null) return null;

		Dictionary<string, string> dataDict = new Dictionary<string, string>();
		foreach (PropertyBase prop in _properties.Values)
		{
			dataDict.Add(prop.name, prop.valueToString());
		}

		return MiniJSON.Json.Serialize(dataDict);
	}

	public void fromJsonString(string jsonString)
	{
		if (_properties == null) return;

		Dictionary<string, string> dataDict = MiniJSON.Json.Deserialize(jsonString) as Dictionary<string, string>;

		foreach (KeyValuePair<string, string> pair in dataDict)
		{
			if (_properties.ContainsKey(pair.Key))
			{
				PropertyBase prop = _properties[pair.Key];
				prop.valueFromString(pair.Value);
			}
		}
	}
}
