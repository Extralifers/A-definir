using UnityEngine;
using System.Collections;

public class ArmMovement : MonoBehaviour {

	

	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            /*poder disparar en direcciones diagonales
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 45f);
            }
            else
            {*/
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            //}
        }
        else if(!GameObject.Find("Personaje").GetComponent<Movement>().grounded0 && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
	}
}
