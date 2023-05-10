using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

// This script is designed to have the OnMove and
// OnJump methods called by a PlayerInput component

public class Movement : MonoBehaviour
{
    Vector2 moveAmount;
    private float speed = 10f;

    [SerializeField] Tilemap pitTilemap;
    bool isOnPlatform = false;

    public void OnMove(InputAction.CallbackContext context)
    {
        // read the value for the "move" action each event call
        moveAmount = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        if(!isOnPlatform && CheckIfOverPit())
        {
            this.transform.position = new Vector3();
        }
        this.transform.position = (this.transform.position + (Vector3)moveAmount * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Entered platform");
        if (collision.CompareTag(Tags.T_Platform))
        {
            this.transform.parent = collision.transform;
            isOnPlatform = true;
        }

        if (collision.CompareTag(Tags.T_Button))
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.T_Platform))
        {
            this.transform.parent = null;
            isOnPlatform = false;
        }
    }

    private bool CheckIfOverPit()
    {
        // Get the player's current position
        Vector3Int playerCellPos = pitTilemap.WorldToCell(transform.position);

        // Check if the tile at the player's position is a pit tile
        TileBase tile = pitTilemap.GetTile(playerCellPos);

        // Return true if the tile is a pit tile, false otherwise
        return tile != null;
    }
}