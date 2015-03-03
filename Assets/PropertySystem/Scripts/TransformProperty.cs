using UnityEngine;
using System.Collections;

public class TransformProperty : PropertyBase
{
	private Transform _transform;
	public Transform transform
	{
		get { return _transform; }
		set 
		{
			_type = value.GetType();
			_transform = value; 
		}
	}

	public TransformProperty(string inName) : base(inName)
	{
		_type = typeof(Transform);
	}

	public override PropertyBase clone()
	{
		return new TransformProperty(name);
	}

	public override string valueToString()
	{
		if (_transform) 
		{
			return _transform.ToString();
		}
		else
		{
			return "";
		}
	}
	
	public override void valueFromString(string valueString)
	{
		if (_transform)
		{
		}
	}
}
