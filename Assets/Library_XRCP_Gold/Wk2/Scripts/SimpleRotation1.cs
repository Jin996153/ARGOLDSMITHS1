using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation1 : MonoBehaviour
{
    private string helloString;
    public string myName;

    // Start is called before the first frame update
    void Start()
    {
        //from our hello world script in week 1
        helloString = "Hello World, my name is " + myName;
        Debug.Log(helloString);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1); // rotates 1 degree per frame on the x axis
    }
}
