using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] colors;

    // Start is called before the first frame update

    void Start()
    {
        
        int r = Random.Range(0, colors.Length - 1);
        Debug.Log(r);
        GetComponent<SpriteRenderer>().sprite = colors[r];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
