using UnityEngine;
using System.Collections;

public class Francotirador : MonoBehaviour {

    public GameObject player;

    public float fireRate;
    public float range;
    public float timeToShoot;
    public float damage;

    public GameObject bulletPrefab;

	//movimiento
	public float speed;
	bool canMove = true;
	public bool facingRight;
	string state;
	public float distanceToRunAwayX;
	public float distanceToRunAwayY;
	Rigidbody2D rb;
	public float jump;
	public Transform pointToCheck;
	bool mustJump;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.Log("Player not found");
		rb = GetComponent<Rigidbody2D> ();
		if(rb == null){
			Debug.LogError ("There is no rigidbody2D attached to this gameobject");
		}
    }

	// Use this for initialization
	void Start () {
        range = 50.0f;
        fireRate = 5.0f;
        timeToShoot = 0;
		state = "seguir";
	}
	
	// Update is called once per frame
	void Update () {
		mustJump = Physics2D.OverlapPoint (pointToCheck.position);

		Vector2 enemyPos = new Vector2(transform.position.x,transform.position.y);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
       
        RaycastHit2D hit = Physics2D.Raycast(enemyPos, playerPos-enemyPos, range);
        Debug.DrawLine(enemyPos, playerPos);
        if(Time.time >= timeToShoot)
        {
            timeToShoot += 1 + Time.time / fireRate;
            fire();
        }
    }
		
	void FixedUpdate(){
		if ((Mathf.Abs (checkPlayer ().x) < distanceToRunAwayX) && (Mathf.Abs (checkPlayer ().y) < distanceToRunAwayY)) {
			state = "huir";
		} else {
			state = "seguir";
		}
		Move ();
	}
			
	Vector3 checkPlayer(){
		return player.transform.position - transform.position;
	}

	void Move(){

		switch (state) {
			
			case "seguir":
				if (checkPlayer ().x < 0) {
					if (canMove) {
					this.transform.Translate(new Vector2(-speed,0));
					} else if (facingRight) {
						flip ();
					this.transform.Translate(new Vector2(-speed,0));
					}
			}else{
				if(canMove){
					this.transform.Translate(new Vector2(speed,0));
				}else if(!facingRight){
					flip();
					this.transform.Translate(new Vector2(speed,0));
				}
			}
			break;

			case "huir":
			if(mustJump){
				rb.AddForce(new Vector2(0,jump));
			}
			if(checkPlayer().x < 0){
				this.transform.Translate(new Vector2(speed,0));
			}else{
				this.transform.Translate(new Vector2(-speed,0));
			}
			break;
		}

	}
		

	void flip(){
		facingRight = !facingRight;
		transform.Rotate (0,180,0);
	}

    void fire()
    {
        Vector3 dif = player.transform.position - transform.position;
        dif.Normalize();
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0f, 0f, rotZ); 
		GameObject bullet = Instantiate(bulletPrefab, transform.position, rot) as GameObject;
		bullet.transform.SetParent (this.gameObject.transform);
    }
}