using UnityEngine;
using System.Collections;

public class Francotirador : MonoBehaviour {

    public GameObject player;

    public float fireRate;
    public float range;
    public float timeToShoot;
    public float damage;

    public GameObject bulletPrefab;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("Player not found");
        }
    }

	// Use this for initialization
	void Start () {
        range = 50.0f;
        fireRate = 5.0f;
        timeToShoot = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 enemyPos = new Vector2(transform.position.x,transform.position.y);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        //Vector2 playerPos = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(enemyPos, playerPos-enemyPos, range);
        Debug.DrawLine(enemyPos, playerPos);
        if(Time.time >= timeToShoot)
        {
            timeToShoot += 1 + Time.time / fireRate;
            fire();
        }
    }

    void fire()
    {
        Vector3 dif = player.transform.position - transform.position;
        dif.Normalize();
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0f, 0f, rotZ); 
        Instantiate(bulletPrefab, transform.position, rot);
    }
}
