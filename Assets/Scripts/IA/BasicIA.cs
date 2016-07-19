using UnityEngine;
using System.Collections;

public class BasicIA : MonoBehaviour {

    // Use this for initialization
    protected Transform player;
    protected Transform enemy;
    protected float Speed;
	public float jump;
	protected bool grounded0 = false, grounded3 = false;
    protected bool grounded1=false,grounded2=false;
    public int maxHealth;
    public int currentHealth;
    public int damage;
	public Transform[] groundCheck;
	protected float GroundRadious = 0.2f;
	public LayerMask IsGround;
    protected bool impulsado;


    void Start () {
        maxHealth = 10;
        currentHealth = 10;
        damage = 2;
    }
	void FixedUpdate () {

		grounded0 = Physics2D.OverlapCircle (groundCheck [0].position, GroundRadious, IsGround);
		grounded1 = Physics2D.OverlapCircle (groundCheck [1].position, GroundRadious, IsGround);
		grounded2 = Physics2D.OverlapCircle (groundCheck [2].position, GroundRadious, IsGround);
		grounded3 = Physics2D.OverlapCircle (groundCheck [3].position, GroundRadious, IsGround);

	}



    private Vector3 checkPlayer()
    {
		return  player.position - enemy.position;
    }
    public void getDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

