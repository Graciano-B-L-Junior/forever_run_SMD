using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rigid;
    public int power = 1;
    private bool onScreen;

    void Start()
    {
        onScreen = false;
        rigid.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {   
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy)
        {
            enemy.TakeDamage(power);
        }

        Destroy(gameObject);
    }
    
    void OnBecameInvisible() {
        Debug.Log("Elpenes");
        Destroy(gameObject);
    }
}
