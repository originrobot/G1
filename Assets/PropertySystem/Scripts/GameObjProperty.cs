﻿using UnityEngine;
using System.Collections;

public class GameObjProperty : PropertyBase
{
	private GameObject _gameObject;
	public GameObject gameObject
	{
		get { return _gameObject; }
		set 
		{
			_type = value.GetType();
			_gameObject = value;
		}
	}

	public GameObjProperty(string inName) : base(inName)
	{
		_type = typeof(GameObject);
	}
}