using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifeTimeDuration = 5f;

    void OnEnable()
    {
        StartCoroutine(DestroyObjectAtTheEndOfLifetime());
    }

    IEnumerator DestroyObjectAtTheEndOfLifetime()
    {
        yield return new WaitForSeconds(lifeTimeDuration);
        Destroy(this.gameObject);
    }
}
