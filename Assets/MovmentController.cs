using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentController : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject CurrentNode;
    public float speed = 4f;
    public string Direction = "";
    public string LastMovingDirection = "";
    public bool CanWarp = true;
    public bool isGhost = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        NodeController CurrentNodeController = CurrentNode.GetComponent<NodeController>();
        transform.position = Vector2.MoveTowards(transform.position, CurrentNode.transform.position, speed*Time.deltaTime);
       

         if (transform.position.x == CurrentNode.transform.position.x && transform.position.y == CurrentNode.transform.position.y)
        {
        

                if (CurrentNodeController.IsWarpLeftNode && CanWarp)
            {
                CurrentNode = GameManager.RightWarpNode;
                Direction = "left";
                LastMovingDirection = "left";
                transform.position = CurrentNode.transform.position;
                CanWarp = false;
            }
            else if (CurrentNodeController.IsWarpRightNode && CanWarp)
            {
                CurrentNode = GameManager.LeftWarpNode;
                Direction = "right";
                LastMovingDirection = "right";
                transform.position = CurrentNode.transform.position;
                CanWarp = false;
            }
            else
            {
                GameObject NewNode = CurrentNodeController.GetNodeFromDirection(Direction);
                if (NewNode != null)
                {
                    CurrentNode = NewNode;
                    LastMovingDirection = Direction;
                }
                else
                {
                    Direction = LastMovingDirection;
                    NewNode = CurrentNodeController.GetNodeFromDirection(Direction);
                    if (NewNode != null)
                    {
                        CurrentNode = NewNode;
                    }
                }
            }
            
        }
         else 
        {
            CanWarp = true;
        }
    }
    
    public void SetDirection(string NewDirection)
    {
        Direction = NewDirection;

    }
}




 // bool ReverseDirection = false;
        // if (
        //     (Direction == "left" && LastMovingDirection == "right")
        //     ||
        //     (Direction == "right" && LastMovingDirection == "left")
        //     ||
        //     (Direction == "up" && LastMovingDirection == "down")
        //     ||
        //     (Direction == "down" && LastMovingDirection == "up")
        //     )
        // {
        //     ReverseDirection = true;
        // }