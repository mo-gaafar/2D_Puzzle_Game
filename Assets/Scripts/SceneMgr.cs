using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void LoadScene (string sceneName) {
        SceneManager.LoadScene (sceneName);
    }

    public void QuitGame () {
        Application.Quit ();
    }

    public void LoadNextScene () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

    public void LoadPreviousScene () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
    }
}