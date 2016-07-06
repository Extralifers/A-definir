using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ItemGenerator : MonoBehaviour {


	public static List<string> nameItems = new List<string> ();
    public List<GameObject> items = new List<GameObject>();

	// Use this for initialization
	void Start () {

        initializePools();

        string itemRandom = nameItems[(int)Random.Range(0F, items.Count)];
        //Item ItemRandom = items[0];
        //Debug.Log(ItemRandom.itemName);

        //Descubrir como saber la posicion de la habitacion en la que esta


        items.Add( (GameObject) Instantiate(Resources.Load(itemRandom), this.gameObject.transform.position+ new Vector3(0, -3F, 0F), new Quaternion(0, 0, 0, 0)));
    }

    // Update is called once per frame
    void Update () {
	
	}

    void initializePools()
    {
        string path = Application.dataPath + @"/Resources/ItemPrefabs";
        var info = new DirectoryInfo(path);
		FileInfo[] fileInfo = info.GetFiles("*.prefab");

        foreach (var file in fileInfo)
        {
            
            string[] namefile = file.Name.Split('.');
			nameItems.Add("ItemPrefabs/"+namefile[0]);
        

        }

    }
}
