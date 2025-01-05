using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{


    [SerializeField] private float knockBackTime;

    private Rigidbody2D rb;



    // private set public get - can only be set here privately, but data will be available publicly.
    public bool gettingKnocked {  get; private set; }




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    public void GetKnockedBack(Transform damageSource, float knockBackThrust)
    {
        gettingKnocked = true;
        // applies force to the item being knocked back and takes into account that items rigidbody mass amount

        Vector2 difference = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass;

        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(GettingKnockedCo());

    }

    private IEnumerator GettingKnockedCo()
    {
        yield return new WaitForSeconds(knockBackTime);
        rb.velocity = Vector2.zero;
        gettingKnocked = false;
    }



}
