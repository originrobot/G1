
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
}
