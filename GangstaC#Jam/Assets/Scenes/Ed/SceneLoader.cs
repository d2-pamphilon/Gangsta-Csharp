using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private bool loading = false;

    public void testPrint()
    {
        Debug.Log("Button Pressed");
    }

    public void LoadNewScene(string scene)
    {
        if (!loading)
        {
            loading = true;
            SceneManager.LoadScene(scene);
        }
    }
    public void LoadNewScene(int scene)
    {
        if (!loading)
        {
            loading = true;
            SceneManager.LoadScene(scene);
        }

    }
}
