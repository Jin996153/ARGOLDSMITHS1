using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRCPLoadSceneButton : MonoBehaviour
{
    public AppState sceneToChangeTo;

    // Update is called once per frame
    public void ChangeScene()
    {
        GameManager.Instance.UpdateState(sceneToChangeTo);
    }
}
