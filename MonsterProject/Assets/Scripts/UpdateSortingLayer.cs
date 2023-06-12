using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSortingLayer : MonoBehaviour
{
    [SerializeField] bool updateTheLayer;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = -Mathf.RoundToInt(this.transform.position.y);
    }

    private void FixedUpdate()
    {
        if(updateTheLayer)
        {
            spriteRenderer.sortingOrder = -Mathf.RoundToInt(this.transform.position.y);
        }
    }
}
