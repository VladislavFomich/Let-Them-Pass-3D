using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    private int _thisSceneIndex;

    public int ThisSceneNum { get => _thisSceneIndex + 1; }

    private void Start()
    {
        _thisSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(_thisSceneIndex);
    }
    
   public void NextScene()
    {
        if(_thisSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            return;
        }
         else
            SceneManager.LoadScene(_thisSceneIndex + 1);
    }

    public void PreviousScene()
    {
        if (_thisSceneIndex == 0)
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(_thisSceneIndex - 1);
        }
    }
}
