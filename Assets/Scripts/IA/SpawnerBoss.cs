using UnityEngine;
using System.Collections;

public class SpawnerBoss : MonoBehaviour {

    private GameObject posActual;

    //plataforma superior
    public GameObject pos1;
    //plataforma izquierda
    public GameObject pos2;
    //plataforma derecha
    public GameObject pos3;
    //centro suelo
    public GameObject pos4;

    public GameObject inicioLluvia;
    public GameObject lluvia;
    private int lluviaCounter;

    public GameObject enemy;

    public bool cd;
    public bool initial;
   
    public string state;

    public int hp;
    public int hpMax;
    public int hpState;
    public int sec100;
    public int sec80;
    public int sec60;
    public int sec40;
    public int sec20;
    private int secActual;
    private bool once80;
    private bool once60;
    private bool once40;
    private bool once20;

    public float radioExplosion;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        state = "Charging";
        cd = true;
        posActual = pos1;
        initial = true;
        hp = 100;
        hpMax = hp;
        hpState = 1;
        sec100 = 7;
        sec80 = 6;
        sec60 = 5;
        sec40 = 4;
        sec20 = 3;
        secActual = sec100;
        once80 = false;
        once60 = false;
        once40 = false;
        once20 = false;
        radioExplosion = 5.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if ((hp <= ((hpMax / 5) * 4)) && !once80)
        {
            secActual = sec80;
            once80 = true;
            state = "Exploid";
        }
        else if ((hp <= ((hpMax / 5) * 3)) && !once60)
        {
            secActual = sec60;
            once60 = true;
            state = "Exploid"; 
        }
        else if ((hp <= ((hpMax / 5) * 2)) && !once40)
        {
            secActual = sec40;
            once40 = true;
            state = "Exploid";
        }
        else if ((hp <= (hpMax / 5)) && !once20)
        {
            secActual = sec20;
            once20 = true;
            state = "Exploid";
        }
        switch (state)
        {
            case "Charging":
                if (cd)
                {
                    if (!initial)
                    {
                        if (posActual == pos1)
                        {
                            transform.Translate(pos2.transform.position - transform.position);
                            posActual = pos2;
                        }
                        else if (posActual == pos2)
                        {
                            transform.Translate(pos3.transform.position - transform.position);
                            posActual = pos3;
                        }
                        else if (posActual == pos3)
                        {
                            transform.Translate(pos1.transform.position - transform.position);
                            posActual = pos1;
                        }
                    }
                    else
                    {
                        initial = false;
                    }

                    if (lluviaCounter == 3)
                    {
                        state = "SpawnAttack";
                    }
                    else
                    {
                        state = "RainAttack";
                        lluviaCounter++;
                    }

                }
                break;
            case "SpawnAttack":
                Spawn();
                break;
            case "RainAttack":
                Llueve();
                break;
            case "Exploid":
                if (cd)
                {
                    Exploid();
                }
                break;
        }
	}

    IEnumerator Charge(int sec) {
        yield return new WaitForSeconds(sec);
        cd = true;

    }

    void Spawn()
    {
        //boss en plataforma superior
        if (posActual == pos1)
        {
            Instantiate(enemy, pos2.transform.position, enemy.transform.rotation);
            Instantiate(enemy, pos3.transform.position, enemy.transform.rotation);
            Instantiate(enemy, pos4.transform.position, enemy.transform.rotation);
        }
        //boss en plataforma izquierda
        else if (posActual == pos2)
        {
            Instantiate(enemy, pos1.transform.position, enemy.transform.rotation);
            Instantiate(enemy, pos3.transform.position, enemy.transform.rotation);
            Instantiate(enemy, pos4.transform.position, enemy.transform.rotation);
        }
        //boss en plataforma derecha
        else if (posActual == pos3)
        {
            Instantiate(enemy, pos1.transform.position, enemy.transform.rotation);
            Instantiate(enemy, pos2.transform.position, enemy.transform.rotation);
            Instantiate(enemy, pos4.transform.position, enemy.transform.rotation);
        }
        Debug.Log("ataca spawn");
        StartCoroutine(Charge(secActual));
        cd = false;
        lluviaCounter = 0;
        state = "Charging";
    }

    void Llueve()
    {
        Debug.Log("Ataca lluvia");
        for (int i = 0; i <= 43; i++)
        {
            Instantiate(lluvia, inicioLluvia.transform.position+new Vector3(i,0,0), lluvia.transform.rotation);
        }
        StartCoroutine(Charge(secActual));
        cd = false;
        state = "Charging";
    }

    void Exploid()
    {
        Debug.Log("Explosion");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,radioExplosion);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].tag == "Player")
            {
                //hacer daño al jugador
                //se puede añadir el efecto de repulsion por explosion pero primero consultar con equipo y tener otras cosas terminadas
            }
        }
        StartCoroutine(Charge(secActual));
        cd = false;
        state = "Charging";
    }
}
