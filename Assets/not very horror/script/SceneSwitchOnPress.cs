using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneSwitchOnPress : MonoBehaviour
{
    public string sceneToLoad; // 要加载的场景名称
    private InputAction m_PressAction;

    void Awake()
    {
        m_PressAction = new InputAction("touch", binding: "<Pointer>/press");

        m_PressAction.started += ctx =>
        {
            if (ctx.control.device is Pointer device)
            {
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

    void OnEnable()
    {
        m_PressAction.Enable();
    }

    void OnDisable()
    {
        m_PressAction.Disable();
    }

    void OnDestroy()
    {
        m_PressAction.Dispose();
    }

    void OnPress(Vector3 position)
    {
        Debug.Log("On Press");
    }

    void OnPressBegan(Vector3 position)
    {
        Debug.Log("On Press Began");
        // 点击物体时切换到指定场景
        SceneManager.LoadScene(sceneToLoad);
    }

    void OnPressCancel()
    {
        Debug.Log("On Press Cancel");
    }
}
