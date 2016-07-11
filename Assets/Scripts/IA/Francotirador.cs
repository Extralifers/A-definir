using UnityEngine;
using System.Collections;

public class Francotirador : MonoBehaviour {

    public GameObject player;

    public float fireRate;
    public float range;
    public float timeToShoot;
    public float damage;

    public GameObject bulletPrefab;

    void awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	// Use this for initialization
	void Start () {
        range = 50.0f;
        fireRate = 5.0f;
        timeToShoot = 0;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position-transform.position, range);
        Debug.DrawLine(transform.position, player.transform.position);
        if(Time.time >= timeToShoot)
        {
            timeToShoot += 1 + Time.time / fireRate;
            fire();
        }
    }

    void fire()
    {
        Instantiate(bulletPrefab, transform.position,transform.rotation * Quaternion.Inverse(player.transform.rotation));
    }
}
