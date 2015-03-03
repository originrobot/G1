using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class NativeProperty<NativeType> : PropertyBase
{
	private NativeType _value;
	public NativeType propertyValue
	{
		get { return _value; }
		set { _value = value; }
	}

	public NativeProperty(string inName) : base(inName)
	{
		_type = typeof(NativeType);
	}

	public override PropertyBase clone()
	{
		return new NativeProperty<NativeType>(name);
	}

	public override string valueToString()
	{
		return _value.ToString();
	}
	
	public override void valueFromString(string valueString)
	{
		TypeConverter convertor = TypeDescriptor.GetConverter(_type);
		if (convertor != null)
		{
			_value = (NativeType)convertor.ConvertFromString(valueString);
		}
	}
}
