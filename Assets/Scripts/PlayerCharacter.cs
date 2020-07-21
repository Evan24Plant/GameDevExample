using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private int health;
    private int maxHealth = 5;
    private int keys;
    private bool fullHealth;

	// Use this for initialization
	void Start () {
        health = 5;
        keys = 0;
	    fullHealth = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit() {
        health -= 1;
        fullHealth = false;
        Debug.Log("Health: " + health);
        Messenger<int>.Broadcast(GameEvent.PLAYER_HIT, health);
        if (health == 0) {
            //Debug.Break();
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
        }
    }

    public void FirstAid() {
        if (health < maxHealth) {
            health += 2;
            if (health > maxHealth) {
                health = maxHealth;
            }
            Messenger<int>.Broadcast(GameEvent.HEALTH_CHANGED, health);
        }
        if (health == maxHealth) {
            fullHealth = true;
        }
    }

    public void NewKey() {
        keys++;
        Messenger<int>.Broadcast(GameEvent.KEY_COLLECTED, keys);
    }

    public bool IsFullHealth() {
        return fullHealth;
    }
}
