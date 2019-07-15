using UnityEngine;


public sealed class MusicPlayer : MonoBehaviour
{
    private void Awake ()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPlayer > 1)
        {
           Destroy(this.gameObject); 
        }
        
        DontDestroyOnLoad(this.gameObject);
    }
}
