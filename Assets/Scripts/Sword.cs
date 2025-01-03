using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{

    private PlayerControls playerControls;
    private Animator myAnimator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();


    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Subscribing to the on click event. When on click occurs, the attack function fires
        playerControls.Combat.Attack.started += _ => Attack();
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    private void Attack()
    {
        // fire sword animation via trigger
        myAnimator.SetTrigger("Attack");
    }

    private void MouseFollowWithOffset()
    {
        // sword follows cursor
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenpoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        float angle = Mathf.Atan2(mousePos.y - playerController.transform.position.y, Mathf.Abs(mousePos.x - playerController.transform.position.x)) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenpoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 180, angle);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
