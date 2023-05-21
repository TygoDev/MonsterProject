using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    private const float Speed = 10f;

    private Vector2 moveAmount;
    public bool isOnPlatform = false;

    [SerializeField] private Tilemap pitTilemap;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float dropForce = 5f;
    [SerializeField] private float gotHitTimer = 1f;
    private int numCoins = 0;
    private BoxCollider boxCollider;

    public Transform checkpoint;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        pitTilemap = GameObject.FindGameObjectWithTag(Tags.T_Pit).GetComponent<Tilemap>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (!isOnPlatform && CheckIfOverPit())
        {
            transform.position = checkpoint.position;
        }

        transform.position += (Vector3)moveAmount * Time.deltaTime * Speed;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(Tags.T_Platform))
        {
            transform.parent = collision.transform;
            isOnPlatform = true;
        }

        if (collision.CompareTag(Tags.T_Platform))
        {
            isOnPlatform = true;
        }

        if (collision.CompareTag(Tags.T_Candy))
        {
            Destroy(collision.gameObject);
            numCoins++;
            GameManager.Instance.candyCount++;
        }

        if (collision.CompareTag(Tags.T_Enemy))
        {
            DropCandy();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag(Tags.T_Platform))
        {
            transform.parent = null;
            isOnPlatform = false;
        }
    }

    private bool CheckIfOverPit()
    {
        Vector3Int playerCellPos = pitTilemap.WorldToCell(transform.position);
        TileBase tile = pitTilemap.GetTile(playerCellPos);
        return tile != null;
    }

    public void DropCandy()
    {
        StartCoroutine(StopHitboxForSeconds(gotHitTimer));
        GameManager.Instance.candyCount -= numCoins;
        for (int i = 0; i < numCoins; i++)
        {
            Vector2 dropPosition = transform.position + Random.insideUnitSphere;
            GameObject coin = Instantiate(coinPrefab, dropPosition, Quaternion.identity);
            Rigidbody2D coinRigidbody = coin.GetComponent<Rigidbody2D>();
            if (coinRigidbody != null)
            {
                coinRigidbody.AddForce(Random.insideUnitCircle * dropForce, ForceMode2D.Impulse);
            }
        }
        numCoins = 0;
    }

    private IEnumerator StopHitboxForSeconds(float secondsToDeactivate)
    {
        boxCollider.enabled = false;
        yield return new WaitForSeconds(secondsToDeactivate);
        boxCollider.enabled = true;
    }

}
