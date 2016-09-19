using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public int Speed;
    private GameObject damageEngine;

    void Awake() {

		damageEngine = GameObject.FindGameObjectWithTag("GameController");
		if (damageEngine == null)
			Debug.LogError ("GameController not found!");
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
        Destroy(this.gameObject, 1);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
		damageEngine.GetComponent<DamageEngine>().ObjectCollision(gameObject.transform.parent.gameObject, collision.gameObject);
        Destroy(this.gameObject);
    }
}
