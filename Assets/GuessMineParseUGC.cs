using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using HutongGames.PlayMaker;

public class GuessMineParseUGC : MonoBehaviour 
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
	public string tier1;
	public int idIndexArray;
	public bool parseComplete = false;
	public FsmString stringList;
	public FsmGameObject storeGameObject;


	
	public void English ()
	{
		language = "English";
	}

	public void Chinese ()
	{
		language = "Chinese";
	}

	public void ParseTierUpdate ()
	{	
		PlayMakerFSM[] temp = GetComponents<PlayMakerFSM> ();
					foreach (PlayMakerFSM fsm in temp) 
					{
						if (fsm.FsmName == fsmInterfaceName)
						{
							fsmInterface = fsm;
						}
					}

			query = new ParseQuery<ParseObject> ("DataGuessMineTiers");
			query.FindAsync ().ContinueWith (t =>
			{
				result = t.Result;
				Debug.Log ("data received!");
				foreach (ParseObject obj in result) 
				{
					tier1 = obj.Get<string> ("tier1" + language);
					Debug.Log (obj.Get<string> ("tier1" + language));
				}
			parseComplete = true;
			});
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

	public void SubmitButtonUGC ()
	{
//			PlayMakerFSM[] temp = GetComponents<PlayMakerFSM> ();
//			foreach (PlayMakerFSM fsm in temp) 
//			{
//				if (fsm.FsmName == fsmInterfaceName)
//				{
//					fsmInterface = fsm;
//				Debug.Log(fsm);
//				Debug.Log(fsmInterface);
//				}
//			}
		ParseObject questionNew = new ParseObject ("DataGuessMine" + language);

//		fsmInterface = PlayMakerFSM.FindFsmOnGameObject(
//		stringList = fsmInterface.FsmVariables.FindFsmString("stringList").Value;
//		foreach (string str in stringArray) 
//		{

//		}

		questionNew ["ID"] = 1337;
		questionNew ["Answer"] = answer;
		questionNew ["HintT1"] = tier1;
		questionNew ["Yes"] = stringList.Value;
		questionNew ["Language"] = language;
		questionNew.SaveAsync ();
	}

}