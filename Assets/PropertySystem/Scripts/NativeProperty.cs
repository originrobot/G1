using UnityEngine;
using System.Collections;

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
}
