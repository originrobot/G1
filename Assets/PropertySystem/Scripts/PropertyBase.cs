
public class PropertyBase
{
	private string _name;
	public string name
	{
		get { return _name; }
	}

	protected System.Type _type;
	public System.Type type
	{
		get { return _type; }
		set { _type = value; }
	}

	public PropertyBase(string inName)
	{
		_name = inName;
	}

	public virtual PropertyBase clone()
	{
		return new PropertyBase(_name);
	}

	public virtual string valueToString()
	{
		return "";
	}

	public virtual void valueFromString(string valueString)
	{
	}
}
