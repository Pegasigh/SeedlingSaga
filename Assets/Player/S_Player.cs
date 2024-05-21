using System.Collections.Generic;
using UnityEngine;


public class S_Player : MonoBehaviour
{
    //movement and animation
    public float speed = 1.0f;
    private Rigidbody2D rb;
    private S_AnimationController_CozyPeople animationController;
    private Direction facing; 
    enum Direction
    {
        up,
        down,
        left,
        right
    }

    //interaction
    //TODO: change these interaction keys
    public KeyCode interactionKeyA = KeyCode.Space;
    public KeyCode interactionKeyB = KeyCode.KeypadEnter;
    private List<GameObject> interactableObjects = new List<GameObject>();




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<S_AnimationController_CozyPeople>();
    }

    void Update()
    {
        //movement
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontalMove, verticalMove) * speed;
        

        //animation
        if (animationController == null) { Debug.LogError("No controller attached to" + gameObject.name); }
        else
        {
            if (verticalMove != 0 || horizontalMove != 0) //is moving
            {
                if (horizontalMove < 0) { animationController.SetAnimation("walk_left"); facing = Direction.left; } //if moving left (-1)
                else if (horizontalMove > 0) { animationController.SetAnimation("walk_right"); facing = Direction.right; }//if moving right (-1)
                else if (verticalMove < 0) { animationController.SetAnimation("walk_down"); facing = Direction.down; } //if moving down (-1)
                else if (verticalMove > 0) { animationController.SetAnimation("walk_up"); facing = Direction.up; } //if moving up (1)
            }
            else //not moving
            {
                if (facing == Direction.left) animationController.SetAnimation("idle_left");
                else if (facing == Direction.right) animationController.SetAnimation("idle_right");
                else if (facing == Direction.down) animationController.SetAnimation("idle_down");
                else if (facing == Direction.up) animationController.SetAnimation("idle_up");
            }
        }


        //interaction
        if (Input.GetKeyDown(interactionKeyA) || Input.GetKeyDown(interactionKeyB))
        {
            GameObject closestObject;
            if(interactableObjects.Count > 0) //if within range of any interactable objects
            {
                //finding closest interactable object
                closestObject = interactableObjects[0];
                foreach (var obj in interactableObjects)
                {
                    if (Vector2.Distance(obj.transform.position, transform.position) < Vector2.Distance(closestObject.transform.position, transform.position)) //is closer than closest object
                    {
                        closestObject = obj;
                    }
                }

                //call object's interact function
                if (Input.GetKeyDown(interactionKeyA)) closestObject.GetComponent<S_InteractableObject>().InteractionA(this);
                if (Input.GetKeyDown(interactionKeyB)) closestObject.GetComponent<S_InteractableObject>().InteractionB(this);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<S_InteractableObject>())
        {
            interactableObjects.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<S_InteractableObject>())
        {
            interactableObjects.Remove(collision.gameObject);
        }
    }
}
