using UnityEngine;
using System.Collections;

public class SpawnerBossRain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.tag == "Player")
        {
            //hacer daño
            Destroy(this.gameObject);
        }
        else
        {*/
            Destroy(this.gameObject);
        //}
    }
}
