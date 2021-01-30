using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrolling : MonoBehaviour
{
    public float scrollX = 0.5f;
    public float scrollY = 0.5f;

    private Renderer rend;

    private float OffsetTexX, OffsetTexY;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        OffsetTexX = Time.time * scrollX;
        OffsetTexY = Time.time * scrollY;
        
        rend.material.mainTextureOffset = new Vector2(OffsetTexX, OffsetTexY);
    }
}
