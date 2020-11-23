using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestImage : MonoBehaviour
{
    Image image;
    Vector2 test;
    void Start()
    {
        image = GetComponent<Image>();
        //test = image.material.GetTextureOffset("Blur");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
