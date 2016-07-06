using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {


	public int InCode;
	public int OutCode;
	public string RoomName;

	public Room(int inCode, int outCode, string roomName)
	{
		this.InCode = inCode;
		this.OutCode = outCode;
		this.RoomName = roomName;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
