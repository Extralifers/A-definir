using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public float FireRate = 0; //cadencia de tiro, si es 0 es de un disparo cada vez que pulsas
    public float Damage = 10;
    public float Range = 30; // distancia a la que llegaran los disparos
    public LayerMask CanHit; //vendran las cosas a las que puedes disparar

    public float EffectRate = 10; //tiempo para que no se sature la pantalla con muchos disparos si la cadencia es muy grande
    private float TimeToEffect = 0; //tiempo calculado para saber cuanto falta para poder disparar
    private float TimeToFire = 0; //tiempo de carga entre disparos
    Transform FirePoint; //desde donde dispara el arma

    public GameObject bulletPrefab;
    private GameObject player;

    private Movement mv;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.Find("Personaje");
        mv = player.GetComponent<Movement>();
        FirePoint = transform.FindChild("FirePoint");
        if (FirePoint == null)
        {
            Debug.LogError("The firepoint is wrong");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.J)) //si esta pulsado el boton de disparar (esta puesto j ahora mismo)
            {
                Fire();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.J) && Time.time > TimeToFire)
            {
                TimeToFire = Time.time + 1 / FireRate;
                Fire();
            }
        }
    }

    void Fire()
    {
        int grades = 0 ;
        Vector2 FirePointPosition = new Vector2(FirePoint.position.x, FirePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(FirePointPosition, new Vector2(1, 0), Range, CanHit);
        if (!mv.grounded0 && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))) //caso de salto con disparo hacia abajo
        {
            hit = Physics2D.Raycast(FirePointPosition, new Vector2(0, -1), Range, CanHit);
            Debug.DrawLine(FirePointPosition, new Vector2(-1, 0) * 100);
            grades = -90;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            /*if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //caso de disparo diagonal arriba-derecha (pulsado der+arriba)
            {
                hit = Physics2D.Raycast(FirePointPosition, new Vector2(1, 1), Range, CanHit);
                Debug.DrawLine(FirePointPosition, new Vector2(1, 1) * 100);
                grades = 45;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //caso de disparo diagonal arriba-izquierda ( pulsado izq+arriba)
            {
                hit = Physics2D.Raycast(FirePointPosition, new Vector2(-1, 1), Range, CanHit);
                Debug.DrawLine(FirePointPosition, new Vector2(-1, 1) * 100);
                grades = 135;
            }*/
                //caso de disparo vertical hacia arriba (solo pulsado arriba)
            hit = Physics2D.Raycast(FirePointPosition, new Vector2(0, 1), Range, CanHit);
            Debug.DrawLine(FirePointPosition, new Vector2(0, 1) * 100);
            grades = 90;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // caso de disparo a la derecha (solo pulsado der)
        {
            hit = Physics2D.Raycast(FirePointPosition, new Vector2(1, 0), Range, CanHit);
            Debug.DrawLine(FirePointPosition, new Vector2(1, 0) * 100);
            grades = 0;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //caso de disparo a la izq (solo pulsado izq)
        {
            hit = Physics2D.Raycast(FirePointPosition, new Vector2(-1, 0), Range, CanHit);
            Debug.DrawLine(FirePointPosition, new Vector2(-1, 0) * 100);
            grades = 180;
        }
        else //disparar sin moverse
        {
            bool face = mv.facingRight;
            if (face)
            {
                hit = Physics2D.Raycast(FirePointPosition, new Vector2(1, 0), Range, CanHit);
                Debug.DrawLine(FirePointPosition, new Vector2(1, 0) * 100);
                grades = 0;
            }
            else
            {
                hit = Physics2D.Raycast(FirePointPosition, new Vector2(-1, 0), Range, CanHit);
                Debug.DrawLine(FirePointPosition, new Vector2(-1, 0) * 100);
                grades = 180;
            }
        }
        if (Time.time >= TimeToEffect)
        {
            FireEffect(grades);
            TimeToEffect = Time.time + 1 / EffectRate;
        }
        if (hit.collider != null) // caso en el que el disparo da con algo
        {

        }
    }

    void FireEffect(int rot)
    {
        GameObject bala=  Instantiate(bulletPrefab,FirePoint.position, Quaternion.Euler(new Vector3(0,0,rot))) as GameObject;
        bala.transform.parent=player.transform;

    }
}
