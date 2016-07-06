using UnityEngine;
using System.Collections;

public class ItemJump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().jump += 1000;
        Destroy(this.gameObject);
    }
}
