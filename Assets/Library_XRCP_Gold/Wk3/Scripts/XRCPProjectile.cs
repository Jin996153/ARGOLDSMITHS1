using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//Using the Input Action System
//https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html

public class XRCPProjectile : MonoBehaviour
{
    public GameObject m_ProjectilePrefab;
    public float m_InitialSpeed = 25;

    InputAction m_PressAction;

    void Awake()
    {
        //creating a new input action in code and setting up the binding
        //https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/api/UnityEngine.InputSystem.InputAction.html
        m_PressAction = new InputAction("touch", binding: "<Pointer>/press");

        //subscribing the events
        m_PressAction.started += ctx =>
        {
            if (ctx.control.device is Pointer device)
            {
                //our custom function, see below, will be called on the event, in this case passing a Vector3 as the param 
                OnPressBegan(device.position.ReadValue());
            }
        };

        m_PressAction.performed += ctx =>
        {
            if (ctx.control.device is Pointer device)
            {
                OnPress(device.position.ReadValue());
            }
        };

        m_PressAction.canceled += _ => OnPressCancel();
    }

    //Enable input action when gameobject is enabled
    void OnEnable()
    {
        m_PressAction.Enable();
    }

    //Dispable input action when gameobject is disabled
    void OnDisable()
    {
        m_PressAction.Disable();
    }

    //Dispose of input action when gameobject is destroyed
    void OnDestroy()
    {
        m_PressAction.Dispose();
    }

    //Implement your code down here for each action state

    void OnPress(Vector3 position) {
        Debug.Log("On Press");
    }

    void OnPressBegan(Vector3 position) {
        Debug.Log("On Press Began");

        if (m_ProjectilePrefab == null)
        {
            return;
        }

        Ray ray = GetComponent<Camera>().ScreenPointToRay(position);
        GameObject projectile = Instantiate(m_ProjectilePrefab, ray.origin, Quaternion.identity);
        Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
        rigidbody.velocity = ray.direction * m_InitialSpeed;
    }

    void OnPressCancel() {
        Debug.Log("On Press Cancel");
    }
}



