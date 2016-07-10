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
    }
	
	// Update is called once per frame
	void Update () {
        if (hp <= hpMax / 5)
        {
            hpState = 5;
        }
        else if(hp <= (hpMax / 5) * 2)
        {
            hpState = 4;
        }
        else if (hp <= (hpMax / 5) * 3)
        {
            hpState = 3;
        }
        else if (hp <= (hpMax / 5) * 4)
        {
            hpState = 2;
        }

        if (state == "Charging")
        {
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
                }else
                {
                    initial = false;
                }

                if (lluviaCounter == 3)
                {
                    state = "SpawnAttack";
                }else
                {
                    state = "RainAttack";
                    lluviaCounter++;
                }
                
            }
        }
        else if (state == "SpawnAttack")
        {
            Spawn();
        }
        else if (state == "RainAttack")
        {
            Llueve();
        }

	}

    IEnumerator Charge() {
        int sec = 10;
        if (hpState == 1)
        {
            sec = 7;
        }
        else if (hpState == 2)
        {
            sec = 6;
        }
        else if (hpState == 3)
        {
            sec = 5;
        }
        else if (hpState == 4)
        {
            sec = 4;
        }
        else if (hpState == 5)
        {
            sec = 3;
        }
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
        StartCoroutine(Charge());
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
        StartCoroutine(Charge());
        cd = false;
        state = "Charging";
    }
}
