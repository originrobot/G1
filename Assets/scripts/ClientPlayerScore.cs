using UnityEngine;
using System.Collections;

public class ClientPlayerScore : MonoBehaviour
{
	
	private int currentClientScore=0;
	private int previousClientScore=0;

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		//		Debug.Log (playerId+"is sending scores!");

		int clientScore = 0;
		Vector3 position=Vector3.zero;
		if (stream.isWriting) {
			clientScore = currentClientScore;
			stream.Serialize(ref clientScore);
			position = transform.position;
			stream.Serialize(ref position);
		} else {
			stream.Serialize(ref clientScore);
			currentClientScore = clientScore;
			stream.Serialize(ref position);
			transform.position = position;
			Debug.Log("client is recieving score upates: " + clientScore);
		}
	}

	public void updateClientScore(int score)
	{
		
		currentClientScore = score;
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (previousClientScore != currentClientScore) 
		{
			previousClientScore = currentClientScore;
			gameObject.GetComponent<UILabel>().text = currentClientScore.ToString();
		}
	}
}

