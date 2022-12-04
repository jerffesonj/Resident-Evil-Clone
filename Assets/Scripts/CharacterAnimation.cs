using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    Animator anim;
    CharacterMovement charController;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        charController = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        anim.SetBool("Moving", charController.Moving);   
        anim.SetFloat("Speed", charController.MoveDir.magnitude * Input.GetAxisRaw("Vertical"));   
        anim.SetFloat("Rotation", charController.RotationSpeed);   
    }
}
