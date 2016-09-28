using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float Speed = 10f;
    public bool facingRight = true;

    Animator anim;

    public bool grounded0 = false, grounded3 = false;
    private bool grounded1=false,grounded2=false;
    public Transform[] groundCheck;
    float GroundRadious = 0.2f;
    public LayerMask IsGround;
	private BoxCollider2D playerCollider;
    private float StandarSpeed;
    private Rigidbody2D rb;
	private float normalYColliderSize;
	private bool crounched = false;
    /*quitar la variable crounched en el caso de que se pueda mover mientras esta agachado
    private bool crounched = false;
    */

    public float jump;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<BoxCollider2D>();
		if (playerCollider == null) {
			Debug.LogError ("There is no boxCollider attached to the player!");
		}
		normalYColliderSize = playerCollider.size.y;
    }

	// Use this for initialization
	void Start () {
        StandarSpeed = Speed;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        grounded0 = Physics2D.OverlapCircle(groundCheck[0].position, GroundRadious, IsGround);
        grounded1 = Physics2D.OverlapCircle(groundCheck[1].position, GroundRadious, IsGround);
        grounded2 = Physics2D.OverlapCircle(groundCheck[2].position, GroundRadious, IsGround);
        grounded3 = Physics2D.OverlapCircle(groundCheck[2].position, GroundRadious, IsGround);
        float move = Input.GetAxis("Horizontal");

        // MOVERSE MIENTRAS TE AGACHAS (activar en crouch y uncrouch lineas de codigo que disminuyen la velocidad)
		if(Input.GetAxis("Vertical")<0 && !crounched)
        {
            crouch();
			crounched = true;
        }
		if (Input.GetAxis("Vertical")>=0 && crounched)
        {
            uncrouch();
			crounched = false;
        }
        rb.velocity = new Vector2(move * Speed, rb.velocity.y);

        //indica si tiene que cambiar la direccion a la que mira el personaje
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        /*AGACHARSE Y PODER MOVER LA DIRECCION
        if (grounded0 && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            crouch();
        }
        if (grounded0 && (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)))
        {
            uncrouch();
        }
        if (!crounched)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * Speed, GetComponent<Rigidbody2D>().velocity.y);
        }

        //indica si tiene que cambiar la direccion a la que mira el personaje
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
        */

        /*AGACHARSE Y NO PODER MOVER LA DIRECCION (si queremos esto tenemos que cambiar el script)
        if (grounded0 && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            crouch();
        }
        if (grounded0 && (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)))
        {
            uncrouch();
        }
        if (!crounched)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * Speed, GetComponent<Rigidbody2D>().velocity.y);
            //indica si tiene que cambiar la direccion a la que mira el personaje
            if (move > 0 && !facingRight)
            {
                flip();
            }
            else if (move < 0 && facingRight)
            {
                flip();
            }
        }
        */       
    }
    
    void Update()
    {
        //en caso de pulsar espacio salta
		if((grounded0 || grounded1 || grounded2) && Input.GetButtonDown("Jump"))
        {
            //anim.setBool("Ground", false);
            rb.AddForce(new Vector2(0, jump));
        }
    }

    //coloca el personaje mirando hacia la otra posicion
    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x = scale.x * -1;
        transform.localScale = scale;
    }

    void crouch()
    {
        //meter animacion de agacharse
		playerCollider.size = new Vector2(playerCollider.size.x,normalYColliderSize*0.5f);
        //linea que activa la velocidad reducida cuando el personaje se agacha
        Speed = Speed / 2;

        /*quitar en el caso de que se pueda mover mientras esta agachado
        crounched = true;
        */
    }
    void uncrouch()
    {
		playerCollider.size = new Vector2(playerCollider.size.x,normalYColliderSize);
        //linea que activa la velocidad normal cuando el personaje se levanta
        Speed = StandarSpeed;

        /*quitar en el caso de que se pueda mover mientras esta agachado
        crounched = false;
        */
    }
}
