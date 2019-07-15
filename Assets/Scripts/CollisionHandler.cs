using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class CollisionHandler : MonoBehaviour
{
    [Tooltip("In Seconds")][SerializeField] private float m_loadLevelDelay = 1f;
    [SerializeField] private string m_playerDeathMethod = "OnPlayerDeath";
    [Tooltip("Particle FX on PLayer")][SerializeField] private GameObject m_deathFx;
    
    
    #region Unity Methods
    
    private void OnTriggerEnter (Collider other)
    {
        this.StartDeathSequence();
        this.m_deathFx.SetActive(true);
        this.Invoke("ReloadScene", this.m_loadLevelDelay);
    }
    #endregion
   
    
    #region Private Methods

    private void StartDeathSequence ()
    {
        this.gameObject.SendMessage(this.m_playerDeathMethod);
    }

    // String referenced
    private void ReloadScene ()
    {
        SceneManager.LoadScene(1);
    }
    #endregion
}
