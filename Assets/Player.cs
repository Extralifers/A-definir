using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth = 100;
    public int damage = 2;

    //public class PlayerStats
    //{
    //    public int Health = 100;
    //}

    //public PlayerStats playerStats = new PlayerStats();

    public void getDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            GameMaster.killPlayer(this);
        }
    }
}
