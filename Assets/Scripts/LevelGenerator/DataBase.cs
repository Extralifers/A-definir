using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System;


public class DataBase {

	public static List<List<string>> Query(string query)
	{
		
			
		List<List<string>> result = new List<List<string>>();
		try{
			string conn = "URI=file:" + Application.dataPath + "/setupdb.s3db"; //Path to database.
			IDbConnection dbconn;
			dbconn = (IDbConnection) new SqliteConnection(conn);
			dbconn.Open(); //Open connection to the database.
			IDbCommand dbcmd = dbconn.CreateCommand();
			string sqlQuery = query;
			dbcmd.CommandText = sqlQuery;
			IDataReader reader = dbcmd.ExecuteReader();
			while (reader.Read())
			{
				List<string> linea = new List<string> ();
				for (int i = 0; i < reader.FieldCount; i++) {
					linea.Add(reader.GetValue(i).ToString());
				
				}
				result.Add (linea);
			}
			reader.Close();
			reader = null;
			dbcmd.Dispose();
			dbcmd = null;
			dbconn.Close();
			dbconn = null;
		}

		catch(Exception ex) {
			Debug.Log (ex.Message + " - " + ex.StackTrace);
			Debug.Log (query);
		}
		return result;
	}


}
