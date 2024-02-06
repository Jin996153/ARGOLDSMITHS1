using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// we are going to use an enum to manage the state / what scene we are in
public enum AppState
{
    Menu,
    XRToolkit,
    Interactables,
    Simple
}

public class GameManager : MonoBehaviour
{

    //Singleton pattern
    //The static keyword is our clue here that we are 
    //creating a globally available variable 
    public static GameManager Instance { get; private set; }

    public AppState appState;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // if this is the first Instance set our static variable to this one 
            DontDestroyOnLoad(Instance);
            Debug.Log("First Game Manager Made!");
        }
        else
        {
            Destroy(gameObject); // if our Instance variable has already been set destroy any new ones
            Debug.Log("Darn a Game Manager beat me to it!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpdateState(AppState newState)
    {
        appState = newState;

        switch (appState)
        {
            case AppState.Menu:
                UpdateMenuScene();
                break;
            case AppState.XRToolkit:
                LoadXRToolkitSampleScene();
                break;
            case AppState.Interactables:
                //do something else
                LoadInteractableScene();
                break;
            case AppState.Simple:
                //do something else
                LoadSimpleScene();
                break;
        }
    }

    private void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Welcome moment
    private void UpdateMenuScene()
    {
        //Maybe there's something specific you need to do in code here.
        
        LoadNewScene("Menu_XRCP");
    }

    private void LoadXRToolkitSampleScene()
    {
        LoadNewScene("XRToolkitSample");
    }

    private void LoadInteractableScene()
    {
        LoadNewScene("SimpleInteractable");
    }

    private void LoadSimpleScene()
    {
        LoadNewScene("SimpleObject");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
