using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OriginInfoHandler : MonoBehaviour {

    public string originScene;
    private static GameObject instanceRef;

    void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        originScene = SceneManager.GetActiveScene().name;
    }
}

