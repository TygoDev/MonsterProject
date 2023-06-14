using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayForFade : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] players = new GameObject[2];

    List<FadeInOut> fades = new List<FadeInOut>();
    private void Update()
    {
        if (players != default)
        {
            foreach (var p in players)
            {
                Vector3 dir = p.transform.position - transform.position;
                Ray ray = new Ray(transform.position, dir);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider == null)
                        return;

                    if (hit.collider.CompareTag(Tags.T_Player))
                    {
                        /*foreach (var fade in fades)
                        {
                            if (fade != null)
                            {
                                fade.doFade = false;
                            }
                        }*/
                    }
                    else
                    {
                        fades.Add(hit.collider.gameObject.GetComponent<FadeInOut>());
                        foreach (var fade in fades)
                        {
                            if (fades != null)
                            {
                                Debug.Log("Hobho");
                                fade.doFade = true;
                            }
                        }
                    }
                }
            }
            fades.Clear();
        }
    }
}
