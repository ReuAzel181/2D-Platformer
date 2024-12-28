using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float x, y;

    void Update()
    {
        Rect uvRect = img.uvRect;
        uvRect.position += new Vector2(x, y) * Time.deltaTime;
        img.uvRect = uvRect;
    }
}
