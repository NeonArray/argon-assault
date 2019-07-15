using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class SceneLoader : MonoBehaviour
{
    private void Start ()
    {
        this.Invoke("LoadFirstScene", 4f);
    }
    
    private void LoadFirstScene ()
    {
        SceneManager.LoadScene(1);
    }
}
