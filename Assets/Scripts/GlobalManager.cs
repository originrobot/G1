using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class GlobalManager : MonoBehaviour
{
	private bool _propClassesInited = false;
	private Dictionary<string, PropertyClass> _propertyClasses = new Dictionary<string, PropertyClass>();
	private static GlobalManager _instance = null;

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
		_instance = this;
	}

	public static GlobalManager instance
	{
		get { return _instance; }
	}

	void Start()
	{
		StartCoroutine(coInitPropertyClasses());
	}
	
	void Update() 
	{
	}

	public PropertyClass getPropertyClass(string className)
	{
		if (!_propClassesInited) return null;

		if (_propertyClasses.ContainsKey(className)) return _propertyClasses[className];
		else return null;
	}

	private IEnumerator coInitPropertyClasses()
	{
		ResourceRequest request = Resources.LoadAsync<TextAsset>("PropertyClasses");
		yield return request;

		if (request.isDone && request.asset != null)
		{
			TextAsset xmlClasses = request.asset as TextAsset;
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xmlClasses.text);

			XmlElement root = doc.DocumentElement;
			XmlNodeList classes = root.SelectNodes("/PropertyClasses/PropertyClass");

			foreach (XmlNode propClass in classes)
			{
				// parse each property class
				PropertyClass newClass = new PropertyClass(propClass.Attributes["name"].InnerText);

				foreach (XmlNode child in propClass.ChildNodes)
				{
					if (child.Name == "ParentClass") // get properties from parent
					{
						string parentName = child.Attributes["name"].InnerText;
						if (parentName != "none" && _propertyClasses.ContainsKey(parentName))
						{
							Dictionary<string, PropertyBase> parentProperties = _propertyClasses[parentName].properties;
							foreach (PropertyBase prop in parentProperties.Values)
							{
								newClass.addProperty(prop);
							}
						}
					}
					else if (child.Name == "Property") // new property
					{
						PropertyBase newProperty = new PropertyBase(child.Attributes["name"].InnerText);
						newClass.addProperty(newProperty);
					}
				}

				// add to dictionary
				_propertyClasses.Add(newClass.className, newClass);
			}
		}

		_propClassesInited = true;
	}
}
