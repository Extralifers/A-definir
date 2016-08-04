using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public int Speed;
    private GameObject DamageEngine;

    void Awake() {

        DamageEngine = GameObject.Find("DamageEngine");
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
        Destroy(this.gameObject, 1);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.transform.parent.gameObject.ToString());
        Debug.Log(collision.gameObject.ToString());
        DamageEngine.GetComponent<DamageEngine>().ObjectCollision(gameObject.transform.parent.gameObject, collision.gameObject);
        Destroy(this.gameObject);
    }
}
