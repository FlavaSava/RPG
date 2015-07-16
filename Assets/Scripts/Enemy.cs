using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public const int MAX_HEALTH = 100;

    public float aggroRange = 15;
    public float rotationSpeed = 0.24f;
    public float moveSpeed = 2;
    public int dmg = 5;

    private GameObject target;
    private int health;

	// Use this for initialization
	void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
	    health = MAX_HEALTH;
	}
	
	// Update is called once per frame
	void Update() {
        if (health <= 0) {
            Die();
        }
        float dist = (target.transform.position - transform.position).magnitude;
        if (dist <= aggroRange) {
            Rotate (target.transform.position);
            if (dist > 2) {
                Move (target.transform.position);
            } else {
                Attack();
            }
        }
	}

    void Rotate(Vector3 target) {
        Vector3 relPos = target - transform.position;
        Quaternion destRot = Quaternion.LookRotation(relPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, destRot, rotationSpeed * Time.deltaTime);
    }

    void Move(Vector3 target) {
        Vector3 moveDir = (target - transform.position).normalized;
        moveDir *= (moveSpeed * Time.deltaTime);
        transform.position += moveDir;
    }

    void Attack() {
        target.SendMessage("Hit", dmg);
    }

    void Die() {
        Item it = GetComponent<Item>();
        if (it != null) {
            Inventory.instance.AddItem(it);
        }
        Destroy(gameObject);
    }

    void Hit(int dmg) {
        health -= dmg;
        Debug.Log("Aua! Life left: " + health + "/" + MAX_HEALTH);
    }
}
