using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{

    [SerializeField] private int damageAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        
            Debug.Log("Enemy Hit!");
        // check iof object has the enemyHealth class. If so, take damage
            enemyHealth?.TakeDamage(damageAmount);
    }
}
