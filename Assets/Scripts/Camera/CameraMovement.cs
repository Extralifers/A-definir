using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private GameObject player;
    private Transform gameCamera;
    private Transform user;
    private float delayToFind = 0;
    public float cameraOffset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        user = player.transform;
        gameCamera = this.transform;
    }

    void Update () {
        
        if (player == null)
        {
            LookForPlayer();
            return;
        }

        //this.transform.position = player.transform.position;
        gameCamera.position = new Vector3(user.position.x, user.position.y, cameraOffset);

	}

    void LookForPlayer()
    {
        if(delayToFind <= Time.time)
        {
            GameObject founded = GameObject.FindGameObjectWithTag("Player");
            if(founded != null)
            {
                player = founded;
            }
            else
            {
                delayToFind = Time.time + 0.5f;
            }
        }
    }

}
