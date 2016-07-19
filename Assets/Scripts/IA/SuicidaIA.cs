using UnityEngine;
using System.Collections;

public class SuicidaIA : BasicIA {



    protected Vector3 distance;
    // Use this for initialization
    void Start () {

        Speed = 2f;
        impulsado = false;
        distance = new Vector3();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = this.transform;
    }
    void FixedUpdate()
    {
        
        grounded0 = Physics2D.OverlapCircle(groundCheck[0].position, GroundRadious, IsGround);
        grounded1 = Physics2D.OverlapCircle(groundCheck[1].position, GroundRadious, IsGround);
        grounded2 = Physics2D.OverlapCircle(groundCheck[2].position, GroundRadious, IsGround);
        grounded3 = Physics2D.OverlapCircle(groundCheck[3].position, GroundRadious, IsGround);
        if ((grounded0 || grounded1 || grounded2) && Mathf.Abs(distance.x) <= 10 && distance.y >= 3)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));

        }
    }
    // Update is called once per frame
    void Update()
    {
        distance = player.position - enemy.position;

        if (distance.x > 10 || distance.x < -10)
        {
            if (distance.x > 0)
            {
                enemy.Translate(Vector3.right * Time.deltaTime * Speed);
                impulsado = false;
            }
            else
            {
                enemy.Translate(Vector3.left * Time.deltaTime * Speed);
                impulsado = false;
            }
        }
        else if (!impulsado)
        {
            impulsado = true;
            if (distance.x > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(2000, 0));
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000, 0));
            }
        }


    }
}
