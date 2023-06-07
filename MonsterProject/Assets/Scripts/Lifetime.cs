using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifeTimeDuration = 5f;

    public bool fade = false;

    Renderer render;
    void OnEnable()
    {
        render = GetComponent<Renderer>();
        StartCoroutine(DestroyObjectAtTheEndOfLifetime());
    }

    IEnumerator DestroyObjectAtTheEndOfLifetime()
    {
        if (fade)
        {
            float t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / lifeTimeDuration;
                //Debug.Log(t);
                render.material.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(1f, 0f, t));
                yield return null;
            }
        }
        else
        {
            yield return new WaitForSeconds(lifeTimeDuration);
        }
        Destroy(this.gameObject);
    }
}
