using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour 
{
	private const string _gameTypeName = "superT";
	private const string _gameName = "superTProto";
	private List<HostData> instanceHosts = new List<HostData>();
	private int _currentIdx = -1;
	private UILabel hostInfo;
	private MainScript main;
	private GameObject getHostButton;
	private GameObject connectHostButton;
	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
		MasterServer.ipAddress = "67.225.180.24";
		hostInfo = GameObject.Find ("HostInfo").GetComponent<UILabel>();
		main = GameObject.Find ("Camera").GetComponent<MainScript>();
		getHostButton = GameObject.Find ("GetHostButton");
		connectHostButton = GameObject.Find ("ConnectHostButton");
		connectHostButton.SetActive (false);
	}

	public void StartInstanceServer()
	{
		main.playerType = 1;
		bool useNat = !Network.HavePublicAddress();
		int port = Mathf.FloorToInt(Random.Range(25000, 30000));
		Network.InitializeServer(2, port, false);
		MasterServer.RegisterHost(_gameTypeName, _gameName, SystemInfo.deviceName + Time.realtimeSinceStartup.ToString());
	
	}
	public void OnServerInitialized()
	{
		Debug.Log ("server initialized");
		main.instantiateObjects ();
	}
	public void OnConnectedToServer()
	{
		Debug.Log ("client connected server");
		main.instantiateObjects ();
	}
	public void GetInstanceServer()
	{
		StartCoroutine(coRequestHostList());
	}

	private IEnumerator coRequestHostList()
	{
		instanceHosts.Clear();
		MasterServer.ClearHostList();
		MasterServer.RequestHostList(_gameTypeName);

		while (MasterServer.PollHostList().Length == 0) 
		{
			yield return null;
		}
		HostData[] hostData = MasterServer.PollHostList();
		foreach (HostData host in hostData)
		{
			Debug.LogError("host: " + host.comment);
			hostInfo.text = host.comment;
			instanceHosts.Add(host);
			getHostButton.SetActive (false);
			connectHostButton.SetActive (true);
		}
		MasterServer.ClearHostList();

		_currentIdx = 0;
	}
	
	public void ConnectToServer()
	{
		main.playerType = 2;
		if (_currentIdx < instanceHosts.Count)
		{
			Network.Connect(instanceHosts[_currentIdx]);
		}
	}



}
