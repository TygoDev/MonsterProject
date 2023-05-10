using UnityEngine;
using UnityEngine.InputSystem;

// This script is designed to have the OnMove and
// OnJump methods called by a PlayerInput component

public class Movement : MonoBehaviour
{
    Vector2 moveAmount;
    private float speed = 10f;

    public void OnMove(InputAction.CallbackContext context)
    {
        // read the value for the "move" action each event call
        moveAmount = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        this.transform.position = (this.transform.position + (Vector3)moveAmount * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Entered platform");
        if (collision.CompareTag(Tags.T_Platform))
        {
            this.transform.parent = collision.transform;
        }

        if (collision.CompareTag(Tags.T_Button))
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.transform.parent = null;
    }
}