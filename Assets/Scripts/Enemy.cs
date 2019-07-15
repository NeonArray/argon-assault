using UnityEngine;


public sealed class Enemy : MonoBehaviour
{
    #region Private Members

    [SerializeField] private Transform parent;
    [SerializeField] private GameObject m_deathFx; 
    private BoxCollider m_boxCollider;
    #endregion 
    
   
    #region Unity Methods
   
    private void Start ()
    {
       this.AddNonTriggerBoxCollider();
    }
    
    private void OnParticleCollision (GameObject other)
    {
        GameObject fx = Instantiate(this.m_deathFx, this.transform.position, Quaternion.identity);
        fx.transform.parent = this.parent;
        Destroy(this.gameObject);
    }
    #endregion
   
    
    #region Private Methods

    private void AddNonTriggerBoxCollider ()
    {
        this.m_boxCollider = this.gameObject.AddComponent<BoxCollider>();
        this.m_boxCollider.isTrigger = false;  
    }
    #endregion
}
