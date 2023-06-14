using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 2;
    [SerializeField] float fadeAmount = 0.2f;

    float initialOpacity;
    Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        initialOpacity = mat.color.a;
    }

    public void FadeIn()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, initialOpacity, fadeSpeed));
        mat.color = smoothColor;
    }

    public void FadeOut()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed));
        mat.color = smoothColor;
    }
}