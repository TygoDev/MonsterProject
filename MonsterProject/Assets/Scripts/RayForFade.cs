using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayForFade : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] players = new GameObject[2];

    FadeInOut fade;
    private void Update()
    {
        if(players != default)
        {
            foreach(var p in players)
            {
                Vector3 dir = p.transform.position - transform.position;
                Ray ray = new Ray(p.transform.position, dir);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.collider == null)
                        return;

                    if(hit.collider.CompareTag(Tags.T_Player))
                    {
                        if(fade != null)
                        {
                            fade.doFade = false;
                        }
                    }
                    else
                    {
                        fade = hit.collider.gameObject.GetComponent<FadeInOut>();
                        if(fade != null)
                        {
                            fade.doFade = true;
                        }
                    }
                }
            }
        }
    }
}
