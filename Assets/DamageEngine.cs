using UnityEngine;
using System.Collections;

public class DamageEngine : MonoBehaviour {

    public void ObjectCollision(GameObject sender, GameObject receiver) {


        Player player;
        BasicIA enemy;

        if (sender.tag == "Player" && receiver.tag=="Enemy") {
            player = sender.GetComponent<Player>();
            enemy = receiver.GetComponent<BasicIA>();   
            enemy.getDamage(player.damage);
        }
         else if (receiver.name=="Player" && sender.tag == "Enemy")
        {
            player = receiver.GetComponent<Player>();
            enemy = sender.GetComponent<BasicIA>();
            player.getDamage(enemy.damage);
        }    
    }

}
