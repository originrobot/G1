using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	// Use this for initialization
	private HostPlayerScore hostScore;
	private ClientPlayerScore clientScore;
	public static int host = 1;
	public static int client = 2;
	public int playerType=0;
	private PlayMakerFSM fsm;
	public void updateScore(int score)
	{
		if (playerType == 1) 
		{
			hostScore.updateHostScore(score);
		}
		else
		{
			clientScore.updateClientScore(score);
		}
	}
	void Start () 
	{
		fsm = GameObject.Find ("Player").GetComponent<PlayMakerFSM>();
	}
	public void instantiateObjects()
	{
		GameObject hostPrefab = Resources.Load ("HostScore") as GameObject;
		GameObject clientPrefab = Resources.Load ("ClientScore") as GameObject;

		if(Network.isServer)
		{
			GameObject go = Network.Instantiate (hostPrefab, hostPrefab.transform.position, hostPrefab.transform.rotation,1) as GameObject;
//			go.transform.parent = GameObject.Find ("Root").transform;

			hostScore = go.GetComponent<HostPlayerScore>();
//			go.transform.position+=new Vector3(-100f,-190f,0f);
			Debug.Log (go+":"+go.transform.localPosition.x);
		}
		else
		{
			GameObject go = Network.Instantiate (clientPrefab, clientPrefab.transform.position, clientPrefab.transform.rotation,1) as GameObject;
//			go.transform.parent = GameObject.Find ("Root").transform;
			clientScore = go.GetComponent<ClientPlayerScore>();
//			go.transform.position+=new Vector3(100f,-190f,0f);
		}


	}
	// Update is called once per frame
	void Update () {
		if(hostScore&&hostScore.transform.position.x==0)
		{
			hostScore.transform.localPosition+=new Vector3(60f,200f,0f);
		}
		if(clientScore&&clientScore.transform.position.x==0)
		{
			clientScore.transform.localPosition+=new Vector3(-60f,200f,0f);
		}
		if(fsm.FsmVariables.GetFsmBool("GameOver").Value == true)
			updateScore((int)fsm.FsmVariables.GetFsmFloat ("FinalScore").Value);
	}
}
