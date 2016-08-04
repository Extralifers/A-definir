using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Room : MonoBehaviour {


	public string FileName;

	public int Entry1;
	public int Entry2;
	public int Entry3;

	public int Exit1;
	public int Exit2;
	public int Exit3;

	public int DeepRoom;
	public int GoldRoom;
	public int BossRoom;

	public Room(string filename, int entry1, int entry2, int entry3, int exit1, int exit2, int exit3, int deepRoom, int goldRoom, int bossRoom)
	{
		this.FileName = filename;
		this.Entry1 = entry1;
		this.Entry2 = entry2;
		this.Entry3 = entry3;
		this.Exit1 = exit1;
		this.Exit2 = exit2;
		this.Exit3 = exit3;
		this.DeepRoom = deepRoom;
		this.GoldRoom = goldRoom;
		this.BossRoom = bossRoom;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static List<Room> GetAllRooms()
	{
		return QueryRoom ("SELECT FILENAME, ENTRY1, ENTRY2, ENTRY3, EXIT1, EXIT2, EXIT3, DEEPROOM, GOLDROOM, BOSSROOM FROM ROOM");
	}

	public static List<Room> GetInitRooms()
	{
		return QueryRoom ("SELECT FILENAME, ENTRY1, ENTRY2, ENTRY3, EXIT1, EXIT2, EXIT3, DEEPROOM, GOLDROOM, BOSSROOM FROM ROOM WHERE NOT ENTRY1 AND NOT ENTRY2 AND NOT ENTRY3");
	}

	public static List<Room> GetClosedRooms()
	{
		return QueryRoom ("SELECT FILENAME, ENTRY1, ENTRY2, ENTRY3, EXIT1, EXIT2, EXIT3, DEEPROOM, GOLDROOM, BOSSROOM FROM ROOM WHERE NOT EXIT1 AND NOT EXIT2 AND NOT EXIT3");
	}

	public static List<Room> GetGoldRooms()
	{
		return QueryRoom ("SELECT FILENAME, ENTRY1, ENTRY2, ENTRY3, EXIT1, EXIT2, EXIT3, DEEPROOM, GOLDROOM, BOSSROOM FROM ROOM WHERE GOLDROOM");
	}

	public List<Room> GetBossRooms()
	{
		return QueryRoom ("SELECT FILENAME, ENTRY1, ENTRY2, ENTRY3, EXIT1, EXIT2, EXIT3, DEEPROOM, GOLDROOM, BOSSROOM FROM ROOM WHERE BOSSROOM AND ENTRY1 =" + this.Exit1 + " AND ENTRY2 =" + this.Exit2 + " AND ENTRY3 =" + this.Exit3);
	}

	public List<Room> GetPossibleOpenRooms()
	{
		return QueryRoom ("SELECT FILENAME, ENTRY1, ENTRY2, ENTRY3, EXIT1, EXIT2, EXIT3, DEEPROOM, GOLDROOM, BOSSROOM FROM ROOM WHERE (EXIT1 OR EXIT2 OR EXIT3) AND ENTRY1 =" + this.Exit1 + " AND ENTRY2 =" + this.Exit2 + " AND ENTRY3 =" + this.Exit3);
	}

	public List<Room> GetPossibleClosedRooms()
	{
		return QueryRoom ("SELECT FILENAME, ENTRY1, ENTRY2, ENTRY3, EXIT1, EXIT2, EXIT3, DEEPROOM, GOLDROOM, BOSSROOM FROM ROOM WHERE (NOT EXIT1 AND NOT EXIT2 AND NOT EXIT3) AND ENTRY1 =" + this.Exit1 + " AND ENTRY2 =" + this.Exit2 + " AND ENTRY3 =" + this.Exit3);
	}


	public static Room GetRdm(List<Room> lr)
	{
		return lr[(int)UnityEngine.Random.Range (0, lr.Count)];
	}

	private static List<Room> QueryRoom(string query)
	{
		List<Room> roomList = new List<Room> ();
		try
		{
			foreach(List<string> linea in DataBase.Query (query))
			{
				
				roomList.Add(new Room(linea[0].ToString(), int.Parse(linea[1]), int.Parse(linea[2]), int.Parse(linea[3]), int.Parse(linea[4]), int.Parse(linea[5]), int.Parse(linea[6]), int.Parse(linea[7]), int.Parse(linea[8]), int.Parse(linea[9])));
			
			}
		}
		catch(Exception ex) {
			Debug.Log (ex.Message + " - " + ex.StackTrace);
		}
		return roomList;
	}

}
