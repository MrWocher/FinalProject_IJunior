using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartWindow : MonoBehaviour
{
    private int _sceneNum = 0;

    public void SceneRestart()
    {
        SceneManager.LoadScene(_sceneNum);
    }
}
