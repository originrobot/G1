using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour
{

	private int currentHostScore=0;
	private int previousHostScore=0;
	private int currentClientScore=0;
	private int previousClientScore=0;
	public string playerId;
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
//		Debug.Log (playerId+"is sending scores!");
		if (playerId == "host")
		{
			int hostScore = 0;
			
			if (stream.isWriting) {
				hostScore = currentHostScore;
				stream.Serialize(ref hostScore);
			} else {
				stream.Serialize(ref hostScore);
				currentHostScore = hostScore;
				Debug.Log(playerId+"is recieving score upates: " + hostScore);
			}
		}
		else
		{
			int clientScore = 0;
			
			if (stream.isWriting) {
				clientScore = currentClientScore;
				stream.Serialize(ref clientScore);
			} else {
				stream.Serialize(ref clientScore);
				currentClientScore = clientScore;
				Debug.Log(playerId+"is recieving score upates: " + clientScore);
			}
		}
	}
	public void updateHostScore()
	{

		currentHostScore++;
	}
	public void updateClientScore()
	{
		
		currentClientScore++;
	}
		// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if(playerId == "host")
		{
			if (previousHostScore != currentHostScore) 
			{
				previousHostScore = currentHostScore;
				gameObject.GetComponent<UILabel>().text = currentHostScore.ToString();
			}
		}
		else
		{
			if (previousClientScore != currentClientScore) 
			{
				previousClientScore = currentClientScore;
				gameObject.GetComponent<UILabel>().text = currentClientScore.ToString();
			}
		}
	}
}

