using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using HutongGames.PlayMaker;

public class MyParseTest : MonoBehaviour {
	
	private IEnumerable<ParseObject> result;
	private ParseQuery<ParseObject> query;
	public PlayMakerFSM MyFSM;
	public string ID;
	public string answer;
	public string yes;
	public string no;


	// Use this for initialization
	void Start () {
		Debug.Log("put whatever u like here");
		query = new ParseQuery<ParseObject>("Data20Q");
		query.FindAsync().ContinueWith(t =>
		                               {
			result = t.Result;
			Debug.Log("data recieved!");
			foreach (ParseObject obj in result)
			{
				answer = obj.Get<string>("Answer");
				Debug.Log(obj.Get<string>("Answer"));
				yes = obj.Get<string>("Yes");
				Debug.Log(obj.Get<string>("Yes"));
				no = obj.Get<string>("No");
				Debug.Log(obj.Get<string>("No"));
			}
		} );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}