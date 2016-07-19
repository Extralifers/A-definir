using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public int Speed;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
        Destroy(this.gameObject, 1);
	}

    void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }
}
