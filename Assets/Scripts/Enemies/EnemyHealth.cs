using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private GameObject deathVfxPrefab;
    private int currentHealth;

    private KnockBack knockback;

    private Flash flash;

    private void Awake()
    {
        knockback = GetComponent<KnockBack>();
        flash = GetComponent<Flash>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        StartCoroutine(flash.FlashRoutine());
        knockback.GetKnockedBack(PlayerController.instance.transform, 5f);
        StartCoroutine(CheckDetectDeathCo());
    }

    private IEnumerator CheckDetectDeathCo()
    {
       yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVfxPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
