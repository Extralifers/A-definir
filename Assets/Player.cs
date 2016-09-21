using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth = 100;
    public int damage = 2;
	public GameObject deadMenu;

    //public class PlayerStats
    //{
    //    public int Health = 100;
    //}

    //public PlayerStats playerStats = new PlayerStats();

	void Start(){
		if(deadMenu==null){
			Debug.LogError ("deadMenu is not attached!");
		}
	}

	void Update(){
		if(currentHealth <= 0)
		{
			deadMenu.SetActive (true);
			GameMaster.killPlayer(this);
		}
	}

    public void getDamage(int damage)
    {
        currentHealth -= damage;
    }
}
