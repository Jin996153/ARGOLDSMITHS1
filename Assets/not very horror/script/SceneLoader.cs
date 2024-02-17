using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 在Unity编辑器中指定目标场景的名称
    public string targetSceneName;

    // 当按下按钮时调用此方法
    public void LoadTargetScene()
    {
        // 加载目标场景
        SceneManager.LoadScene(targetSceneName);
    }
}
