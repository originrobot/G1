﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using HutongGames.PlayMaker;

public class GuessMineParse : MonoBehaviour 
{
	
	private IEnumerable<ParseObject> result;
	private ParseQuery<ParseObject> query;
	private PlayMakerFSM fsmInterface;
	public string fsmInterfaceName = "FsmScriptInterface";
	public int ID;
	public string language;
	public string answer;
	public string yes;
	public string hintT1;
	public int idIndexArray;
	public bool parseComplete = false;

	
	public void English ()
	{
		language = "English";
	}

	public void Chinese ()
	{
		language = "Chinese";
	}

	// Use this for initialization


	public void StartButton () 
	{
		PlayMakerFSM[] temp = GetComponents<PlayMakerFSM> ();
		foreach (PlayMakerFSM fsm in temp) 
		{
			if (fsm.FsmName == fsmInterfaceName)
			{
				fsmInterface = fsm;
			}
		}
		Debug.Log (fsmInterface);
		Debug.Log("put whatever u like here");
		query = new ParseQuery<ParseObject>("DataGuessMine" + language);
		query.FindAsync().ContinueWith(t =>
		{
			result = t.Result;
			Debug.Log("data recieved!");
			foreach (ParseObject obj in result)
			{
				ID = obj.Get<int>("ID");
				answer = obj.Get<string>("Answer");
				Debug.Log(obj.Get<string>("Answer"));
				yes = obj.Get<string>("Yes");
				Debug.Log(obj.Get<string>("Yes"));
				hintT1 = obj.Get<string>("HintT1");
				Debug.Log(obj.Get<string>("HintT1"));
				Debug.Log("put whatever u like here");
				
				fsmInterface.FsmVariables.GetFsmArray("IDArray").Resize(idIndexArray + 1);
				fsmInterface.FsmVariables.GetFsmArray("answerArray").Resize(idIndexArray + 1);
				fsmInterface.FsmVariables.GetFsmArray("yesArray").Resize(idIndexArray + 1);
				
				fsmInterface.FsmVariables.GetFsmArray("IDArray").Set (idIndexArray,ID);
				fsmInterface.FsmVariables.GetFsmArray("answerArray").Set (idIndexArray,answer);
				fsmInterface.FsmVariables.GetFsmArray("yesArray").Set (idIndexArray,yes + "," + hintT1);
//				fsmInterface.FsmVariables.GetFsmArray("yesArray").Set (idIndexArray,hintT1);

				idIndexArray = idIndexArray + 1;
			}
			parseComplete = true;
		} );
	}

	void Update ()
	{
		if (parseComplete == true)
		{
			PlayMakerFSM[] temp = GetComponents<PlayMakerFSM> ();
			foreach (PlayMakerFSM fsm in temp) 
			{
				if (fsm.FsmName == fsmInterfaceName)
				{
					fsmInterface = fsm;
				}
				if (fsmInterface != null)
				{
					fsmInterface.Fsm.Event("Tap");
				}
			} 
			parseComplete = false;
		}
	}

}