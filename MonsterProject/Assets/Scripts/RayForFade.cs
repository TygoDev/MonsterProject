using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayForFade : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] players = new GameObject[2];

    List<FadeInOut> hitFades = new List<FadeInOut>();
    List<FadeInOut> hitFades1 = new List<FadeInOut>();
    private void Update()
    {
        Player1Check();
        Player2Check();
    }

    void Player1Check()
    {
        Vector3 dir = players[0].transform.position - transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                foreach (var item in hitFades1)
                {
                    if (!hitFades.Contains(item))
                        item.FadeIn();
                }
                hitFades1.Clear();
            }

            if (hit.collider.GetComponent<FadeInOut>())
            {
                foreach (var item in hitFades1)
                {
                    if (item != hit.collider.GetComponent<FadeInOut>())
                    {
                        item.FadeIn();
                    }
                }

                hit.collider.GetComponent<FadeInOut>().FadeOut();
                hitFades1.Add(hit.collider.GetComponent<FadeInOut>());
            }
        }
    }

    void Player2Check()
    {
        Vector3 dir = players[1].transform.position - transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                foreach (var item in hitFades)
                {
                    if (!hitFades1.Contains(item))
                        item.FadeIn();
                }
                hitFades.Clear();
            }

            if (hit.collider.GetComponent<FadeInOut>())
            {
                foreach (var item in hitFades)
                {
                    if (item != hit.collider.GetComponent<FadeInOut>())
                    {
                        item.FadeIn();
                    }
                }

                hit.collider.GetComponent<FadeInOut>().FadeOut();
                hitFades.Add(hit.collider.GetComponent<FadeInOut>());
            }
        }
    }
}
