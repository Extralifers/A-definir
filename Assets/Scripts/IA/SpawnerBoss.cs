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

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        state = "Charging";
        cd = true;
        posActual = pos1;
        initial = true;
    }
	
	// Update is called once per frame
	void Update () {

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
                    state = "RainAttack";
                }else
                {
                    state = "SpawnAttack";
                    lluviaCounter++;
                }
                
            }
        }
        else if (state == "SpawnAttack") {
            //boss en plataforma superior
            if(posActual == pos1)
            {
                Instantiate(enemy,pos2.transform.position, enemy.transform.rotation);
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
            state = "Charging";
        }else if (state == "RainAttack")
        {
            Llueve();
        }

	}

    IEnumerator Charge() {

        yield return new WaitForSeconds(7);
        cd = true;

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
        lluviaCounter = 0;
    }
}
