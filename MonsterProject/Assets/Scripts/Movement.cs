using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    #region Movement_Var
    private const float Speed = 300f;

    private float moveAmountUp;
    private float moveAmountDown;
    private float moveAmountRight;
    private float moveAmountLeft;

    private Vector2 moveAmount;

    private Vector2 smoothMove;
    Vector2 smoothMoveVelocity;


    public bool isOnPlatform = false;

    [SerializeField] private Tilemap pitTilemap;
    
    private Rigidbody rb;

    bool canDash = true;
    #endregion

    #region Candy_Dropping_Var
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float dropForce = 5f;
    [SerializeField] private float gotHitTimer = 1f;
    private int numCoins = 0;
    private BoxCollider boxCollider;
    #endregion

    public Transform checkpoint;

    [HideInInspector]
    public List<GameObject> platforms = new List<GameObject>();

    public int lives = 5;


    [SerializeField] GameObject bulletPrefab;
    Vector2 lastDirection = new Vector2(0f, 1f); //See, now I'm also a muzician
    bool canShoot = true;
    float angle = 0f;
    float orbitSpeed = 2f;
    [SerializeField] Transform targetToSpin;

    public List<Transform> canvasLives = new List<Transform>();

    #region Audio_and_footsteps
    public GameObject footstepPrefab;
    private Coroutine coroutineForFootsteps;

    AudioSource audioSource;
    [SerializeField] AudioClip walkingSound;
    [SerializeField] AudioClip loseHealth;

    #endregion

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = walkingSound;
    }

    private void Start()
    {
        pitTilemap = GameObject.FindGameObjectWithTag(Tags.T_Pit).GetComponent<Tilemap>();
    }

    public void OnMoveUp(InputAction.CallbackContext context)
    {
        //+
        if(context.ReadValue<float>() == 1)
        {
            moveAmountUp = 1f;
        }
        else
        {
            moveAmountUp = 0f;
        }
    }

    public void OnMoveDown(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            moveAmountDown = -1f;
        }
        else
        {
            moveAmountDown = 0f;
        }
    }

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            moveAmountLeft = -1f;
        }
        else
        {
            moveAmountLeft = 0f;
        }
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        //+
        if (context.ReadValue<float>() == 1)
        {
            moveAmountRight = 1f;
        }
        else
        {
            moveAmountRight = 0f;
        }
    }

    private void FixedUpdate()
    {
        if(lives == 0)
        {
            SceneSwitcher.Instance.SwitchToScene(0);
        }

        if (CheckIfOverPit() && !isOnPlatform && platforms.Count == 0)
        {
            ResetToCheckpoint();
        }

        if(isOnPlatform)
        {
            transform.rotation = Quaternion.Euler(-45f, 0, 0);
        }
        moveAmount = new Vector2(moveAmountLeft + moveAmountRight, moveAmountDown + moveAmountUp);
        if (moveAmount != default(Vector2))
        {
            lastDirection = moveAmount;
            if (coroutineForFootsteps == null)
            {
                coroutineForFootsteps = StartCoroutine(SpawnFootSteps());
            }
        }

        smoothMove = Vector2.SmoothDamp(smoothMove, moveAmount, ref smoothMoveVelocity, 0.1f);

        //transform.position += (Vector3)moveAmount * Time.smoothDeltaTime * Speed;
        if(canDash)
        rb.velocity = (Vector3)smoothMove * Time.deltaTime * Speed;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);

        transform.position = Camera.main.ViewportToWorldPoint(pos);


        transform.position = new Vector3(transform.position.x, transform.position.y, -0.4f);

        angle = Time.time * orbitSpeed;

        targetToSpin.position = this.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
    }

    IEnumerator SpawnFootSteps()
    {
        audioSource.Play();
        var footstep = Instantiate(footstepPrefab, transform.position/* - (Vector3)lastDirection*/, Quaternion.identity);
        footstep.transform.rotation = Quaternion.Euler(0,0, Vector2.Angle(Vector2.up, lastDirection));
        footstep.transform.position = new Vector3(footstep.transform.position.x, footstep.transform.position.y, 0.1f);
        yield return new WaitForSeconds(0.4f);
        coroutineForFootsteps = null;
    }
    public void Dash()
    {
        if(canDash)
        {
            canDash = false;
            StartCoroutine(DashIn());
        }
    }
    IEnumerator DashIn()
    {
        rb.velocity = (Vector3)lastDirection * Time.deltaTime * Speed * 5;
        yield return new WaitForSeconds(0.4f);
        canDash = true;
    }
    public void Shoot()
    {
        if(canShoot)
        {
            canShoot = false;
            StartCoroutine(SpawnBullet());
        }
    }

    IEnumerator SpawnBullet()
    {
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);
        var bullet = Instantiate(bulletPrefab, this.transform.position + new Vector3(x, y, 0) * 2f /*+ ((Vector3)lastDirection * 2f)*/, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = /*(Vector3)lastDirection*/ new Vector3(x, y, 0) * Time.deltaTime * (Speed * 7f);
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

    public void ResetToCheckpoint()
    {
        transform.position = checkpoint.position;
        lives--;
        audioSource.clip = loseHealth;
        audioSource.Play();
        audioSource.clip = walkingSound;
        canvasLives[lives].gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(Tags.T_Platform))
        {
            transform.parent = collision.transform;
            isOnPlatform = true;
        }

        if(collision.CompareTag(Tags.T_Crush))
        {
            ResetToCheckpoint();
        }

        if (collision.CompareTag(Tags.T_Rock))
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
            StartCoroutine(StopHitboxForSeconds(gotHitTimer, collision));
            DropCandy();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag(Tags.T_Platform))
        {
            transform.parent = null;
            this.transform.rotation = Quaternion.Euler(-45f, 0, 0);
            isOnPlatform = false;
        }
    }

    private bool CheckIfOverPit()
    {
        if (pitTilemap != null)
        {
            Vector3Int playerCellPos = pitTilemap.WorldToCell(transform.position);
            TileBase tile = pitTilemap.GetTile(playerCellPos);
            //Debug.Log(tile != null);
            return tile != null;
        }
        return false;
    }

    public void DropCandy()
    {
        var a = Mathf.Min(3, numCoins);
        GameManager.Instance.candyCount -= a;
        numCoins -= a;


        for (int i = 0; i < a; i++)
        {
            Vector2 dropPosition = transform.position + Random.insideUnitSphere;
            GameObject coin = Instantiate(coinPrefab, dropPosition, Quaternion.identity);
            Rigidbody coinRigidbody = coin.GetComponent<Rigidbody>();
            if (coinRigidbody != null)
            {
                coinRigidbody.AddForce(Random.insideUnitCircle * dropForce, ForceMode.Impulse);
            }
        }
        GameManager.Instance.candyCountText.text = GameManager.Instance.candyCount.ToString();
        numCoins = 0;
    }

    private IEnumerator StopHitboxForSeconds(float secondsToDeactivate, Collider collider)
    {
        collider.enabled = false;
        yield return new WaitForSeconds(secondsToDeactivate);
        collider.enabled = true;
    }

}
