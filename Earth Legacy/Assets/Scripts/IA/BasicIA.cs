using UnityEngine;
using System.Collections;

public class BasicIA : MonoBehaviour {

    // Use this for initialization
    private Transform player;
    private Transform enemy;
    private float Speed;
	public float jump;
	public bool grounded0 = false, grounded3 = false;
	private bool grounded1=false,grounded2=false;
	public Transform[] groundCheck;
	float GroundRadious = 0.2f;
	public LayerMask IsGround;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		enemy = this.transform;
		Speed = 4.5f;
    }
	void FixedUpdate () {

		grounded0 = Physics2D.OverlapCircle (groundCheck [0].position, GroundRadious, IsGround);
		grounded1 = Physics2D.OverlapCircle (groundCheck [1].position, GroundRadious, IsGround);
		grounded2 = Physics2D.OverlapCircle (groundCheck [2].position, GroundRadious, IsGround);
		grounded3 = Physics2D.OverlapCircle (groundCheck [2].position, GroundRadious, IsGround);

	}
    // Update is called once per frame
    void Update() {
		Vector3 distance =  player.position - enemy.position;
        if (distance.x>10 || distance.x<-10) { 
		    if (distance.x > 0)
		    {
			    enemy.Translate(Vector3.right* Time.deltaTime* Speed);
		    }
		    else
		    {
			    enemy.Translate(Vector3.left * Time.deltaTime * Speed);
		    }
        }
        else
        {
            if (distance.x>0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(120, 0));
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-120, 0));
            }
        }
        if ((grounded0 || grounded1 || grounded2)&& Mathf.Abs (distance.x) <= 10 && distance.y >= 3) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
		}

	}


    private Vector3 checkPlayer()
    {
		return  player.position - enemy.position;
    }
}
