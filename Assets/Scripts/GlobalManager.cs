using UnityEngine;
using System.Collections;

public class GlobalManager : MonoBehaviour
{
	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start()
	{
	}
	
	void Update() 
	{
	}
}
