using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public GameManager GameManager;

    public bool CanMoveRight = false;
    public bool CanMoveLeft = false;
    public bool CanMoveUp = false; 
    public bool CanMoveDown = false;

    public GameObject NodeRight;
    public GameObject NodeLeft;
    public GameObject NodeUp;
    public GameObject NodeDown;

    public bool IsWarpRightNode = false;
    public bool IsWarpLeftNode = false;

    public bool isPelletNode = false;
    public bool hasPellet = false;

    public SpriteRenderer pelletSprite;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        if(transform.childCount > 0)
        {
            hasPellet = true;
            isPelletNode = true;
            pelletSprite = GetComponentInChildren<SpriteRenderer>();
        }

        RaycastHit2D[] hitsDown;
        hitsDown = Physics2D.RaycastAll(transform.position, -Vector2.up);
        for (int i = 0; i < hitsDown.Length; i++ )
        {
            float distance = Mathf.Abs(hitsDown[i].point.y - transform.position.y);
            if (distance < 0.25f && hitsDown[i].collider.tag == "Node")
            {
                CanMoveDown = true;
                NodeDown = hitsDown[i].collider.gameObject;
            }
            
        }
        RaycastHit2D[] hitsUp;
        hitsUp = Physics2D.RaycastAll(transform.position, Vector2.up);
        for (int i = 0; i < hitsUp.Length; i++ )
        {
            float distance = Mathf.Abs(hitsUp[i].point.y - transform.position.y);
            if (distance < 0.25f && hitsUp[i].collider.tag == "Node")
            {
                CanMoveUp = true;
                NodeUp = hitsUp[i].collider.gameObject;
            }
            
        }
        RaycastHit2D[] hitsLeft;
        hitsLeft = Physics2D.RaycastAll(transform.position, -Vector2.right);
        for (int i = 0; i < hitsLeft.Length; i++ )
        {
            float distance = Mathf.Abs(hitsLeft[i].point.x - transform.position.x);
            if (distance < 0.25f && hitsLeft[i].collider.tag == "Node")
            {
                CanMoveLeft = true;
                NodeLeft = hitsLeft[i].collider.gameObject;
            }
            
        }
        RaycastHit2D[] hitsRight;
        hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right);
        for (int i = 0; i < hitsRight.Length; i++ )
        {
            float distance = Mathf.Abs(hitsRight[i].point.x - transform.position.x);
            if (distance < 0.25f && hitsRight[i].collider.tag == "Node")
            {
                CanMoveRight = true;
                NodeRight = hitsRight[i].collider.gameObject;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetNodeFromDirection(string direction)
    {
        if (direction == "left" && CanMoveLeft)
        {
            return NodeLeft;
        }
        else if (direction == "right" && CanMoveRight)
        {
            return NodeRight;
        }
        else if (direction == "up" && CanMoveUp)
        {
            return NodeUp;
        }
        else if (direction == "down" && CanMoveDown)
        {
            return NodeDown;
        }
        else 
        {
            return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && hasPellet)
        {
            hasPellet = false;
            pelletSprite.enabled = false;
            GameManager.CollectedPellet(this);
        }
    }
}
