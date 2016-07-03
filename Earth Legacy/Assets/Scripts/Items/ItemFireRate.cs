using UnityEngine;
using System.Collections;

public class ItemFireRate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D()
    {
        GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().FireRate += 20;
        Destroy(this.gameObject);
    }
}
