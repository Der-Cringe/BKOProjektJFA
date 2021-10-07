using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    Rigidbody2D body;
    public Animator anim;

    float horizontal;
    float vertical;

    public float runSpeed = 1.0f;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.W)) {
            anim.SetBool("up", true);
            anim.SetBool("down", false);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("right", false);
            anim.SetBool("left", true);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("right", true);
            anim.SetBool("left", false);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            anim.SetBool("up", false);
            anim.SetBool("down", true);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
        }
    }

    private void FixedUpdate() {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
