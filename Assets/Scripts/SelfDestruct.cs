using UnityEngine;


public sealed class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float m_delay = .75f;
    
    
    private void Start ()
    {
        Destroy(this.gameObject, this.m_delay);
    }
}
