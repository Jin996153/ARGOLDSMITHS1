using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler1 : MonoBehaviour
{
    public GameObject objectToMakeVisible; // 需要被设为可见的对象

    // 当两个Collider发生碰撞时调用
    private void OnCollisionEnter(Collision collision)
    {
        // 确保碰撞的是另一个带有"Target"标签的游戏对象
        if (collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("Collision occurred with the target object!");
            
            // 将另一个对象设为可见
            if(objectToMakeVisible != null)
            {
                objectToMakeVisible.SetActive(true);
            }
        }
    }
}
