using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MovmentController MovmentController;
    public Animator Animator;
    public SpriteRenderer Sprite;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
        Sprite = GetComponentInChildren<SpriteRenderer>();
        MovmentController = GetComponent<MovmentController>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetBool("Moving",true);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovmentController.SetDirection("left");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovmentController.SetDirection("right");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MovmentController.SetDirection("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MovmentController.SetDirection("down");
        }

        bool FlipX = false;
        bool FlipY = false;
        if (MovmentController.LastMovingDirection == "left")
        {
            Animator.SetInteger("Direction", 0);
        }
        else if (MovmentController.LastMovingDirection == "right")
        {
            Animator.SetInteger("Direction", 0);
            FlipX = true;
        }
        else if (MovmentController.LastMovingDirection == "up")
        {
            Animator.SetInteger("Direction", 1);
        }
        else if (MovmentController.LastMovingDirection == "down")
        {
            Animator.SetInteger("Direction", 1);
            FlipY = true;
        }

        Sprite.flipY = FlipY;
        Sprite.flipX = FlipX;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
