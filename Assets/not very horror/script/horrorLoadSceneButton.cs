using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horrorLoadSceneButton : MonoBehaviour
{
    public AppState sceneToChangeTo;

    // Update is called once per frame
    public void ChangeScene()
    {
        GameManager.Instance.UpdateState(sceneToChangeTo);
    }
}
