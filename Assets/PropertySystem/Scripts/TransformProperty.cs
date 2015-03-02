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
}
