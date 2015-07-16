using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int maxHealth;
    private int health;

    // Use this for initialization
    void Start() {
        maxHealth = 100;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        
    }

    void Hit(int dmg) {
        health -= dmg;
    }
}
