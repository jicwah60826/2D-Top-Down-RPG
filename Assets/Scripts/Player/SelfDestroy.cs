using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (ps && !ps.IsAlive())
        {
            DestroySelf();
        }

    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
