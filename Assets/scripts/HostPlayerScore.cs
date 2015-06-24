using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HostPlayerScore : MonoBehaviour
{

	private int currentHostScore=0;
	private int previousHostScore=0;
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		//		Debug.Log (playerId+"is sending scores!");
		int hostScore = 0;
		Vector3 position=Vector3.zero;
		if (stream.isWriting) {
			hostScore = currentHostScore;
			stream.Serialize(ref hostScore);
			position = transform.position;
			stream.Serialize(ref position);
		} else {
			stream.Serialize(ref hostScore);
			currentHostScore = hostScore;
			stream.Serialize(ref position);
			transform.position = position;

			Debug.Log("host is recieving score upates: " + hostScore);
		}
	}
	public void updateHostScore(int score)
	{
		
		currentHostScore = score;
	}
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (previousHostScore != currentHostScore) 
		{
			previousHostScore = currentHostScore;
			gameObject.GetComponent<Text>().text = currentHostScore.ToString();
		}
	}
}

