using System.Collections;
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

    [SerializeField] GameObject coinPrefab;
    [SerializeField] float dropForce = 5f;
    [SerializeField] float gotHitTimer = 1f;
    int numCoins = 0;

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

        if(collision.CompareTag(Tags.T_Candy))
        {
            collision.transform.gameObject.SetActive(false);
            numCoins++;
        }

        if (collision.CompareTag(Tags.T_Enemy))
        {
            DropCandy();
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

    IEnumerator StopHitboxForSeconds(float secondsToDeactivate)
    {   
        this.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(secondsToDeactivate);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void DropCandy()
    {
        StartCoroutine(StopHitboxForSeconds(gotHitTimer));
        for (int i = 0; i < numCoins; i++)
        {
            // Calculate a random position around the player
            Vector2 dropPosition = transform.position + Random.insideUnitSphere;

            // Instantiate a coin at the drop position
            GameObject coin = Instantiate(coinPrefab, dropPosition, Quaternion.identity);

            // Apply a force to the coin to make it scatter
            Rigidbody2D coinRigidbody = coin.GetComponent<Rigidbody2D>();
            if (coinRigidbody != null)
            {
                coinRigidbody.AddForce(Random.insideUnitCircle * dropForce, ForceMode2D.Impulse);
            }
        }
        numCoins = 0;
    }
}