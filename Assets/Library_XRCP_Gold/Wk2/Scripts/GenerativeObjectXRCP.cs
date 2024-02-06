using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativeObjectXRCP : MonoBehaviour
{
    public GameObject childPrefab;
    public float numChildren = 10;

    private List<GameObject> children = new List<GameObject>();
    private float deltaTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        // 2 PI is a full circle in radians, sin and cos expect radians so to conver degrees to radians you do this:
        float angleStep = Mathf.Deg2Rad * (360 / numChildren);
        float radius = 0.25f;

        for (int i = 0; i < numChildren; i++)
        {
            float x = Mathf.Sin(angleStep * i) * radius;
            float z = Mathf.Cos(angleStep * i) * radius;

            //Instantiate prefab in local space of parent (second parameter is parent's transform)
            GameObject c = Instantiate(childPrefab, transform, false);//third parameter set to false make it local space

            c.transform.localPosition = new Vector3(x, 0, z);// change local position using the sine + cosine


            //local scale is the scale inside of the parent gameobject
            float localX = c.transform.localScale.x;
            float localZ = c.transform.localScale.z;

            //check if i is odd or even
            if ( i % 2 == 0)
            {
                c.transform.localScale = new Vector3(localX*0.05f, c.transform.localScale.y, localZ * 0.05f);
            }
            else
            {
                c.transform.localScale = new Vector3(localX * 0.1f, c.transform.localScale.y, localZ * 0.1f);
            }

            children.Add(c);

        }

    }

    // Update is called once per frame
    void Update()
    {
        //Using the variables already created for you,
        //loop through children to animate their scale on the y axis using noise

        deltaTimeCounter += Time.deltaTime;


        //loop through our children list to animate them
        for (int i = 0; i < children.Count; i++)
        {
            Vector3 pos = children[i].transform.position;
            float t = deltaTimeCounter * 0.8f;

            float noise = Mathf.PerlinNoise(pos.x + t, pos.z + t);

            Vector3 localScale = children[i].transform.localScale;
            children[i].transform.localScale = new Vector3(localScale.x, noise * 0.5f, localScale.z);
        }


    }
}
