using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;


public sealed class PlayerController : MonoBehaviour
{
    #region Configuration
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] private float m_xSpeed = 25f;
    [Tooltip("In ms^-1")] [SerializeField] private float m_ySpeed = 25f;

    [Header("Constraints")] 
    [SerializeField] private float m_xConstraint = 12f;
    [SerializeField] private float m_yConstraint = 12f;

    [Header("Pitch/Yaw/Roll")]
    [SerializeField] private float m_positionPitchFactor = -3f;
    [SerializeField] private float m_controlPitchFactor = -10f;
    [SerializeField] private float m_positionYawFactor = 2f;
    [SerializeField] private float m_controlRollFactor = -20f;
    #endregion
   
    #region State
    private float m_xThrow;
    private float m_yThrow;
    private bool m_isControlEnabled = true;
    #endregion
    
    
    #region Unity Methods

    private void Update ()
    {
        if (!this.m_isControlEnabled)
        {
            return;
        }
        
        this.ProcessTranslation();
        this.ProcessRotation();
    }
    #endregion
   
    
    #region Private Methods
    
    private void ProcessTranslation ()
    {
        this.m_xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        this.m_yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = this.m_xThrow * this.m_xSpeed * Time.deltaTime;
        float yOffset = this.m_yThrow * this.m_ySpeed * Time.deltaTime;

        float updatedX = Mathf.Clamp(this.transform.localPosition.x + xOffset, -this.m_xConstraint, this.m_xConstraint);
        float updatedY = Mathf.Clamp(this.transform.localPosition.y + yOffset, -this.m_yConstraint, this.m_yConstraint);

        this.transform.localPosition = new Vector3(updatedX, updatedY, this.transform.localPosition.z);
    }

    private void ProcessRotation ()
    {
        float pitchDueToPosition = this.transform.localPosition.y * this.m_positionPitchFactor;
        float pitchDueToControlThrow = this.m_yThrow * this.m_controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        
        float yaw = this.transform.localPosition.x * this.m_positionYawFactor;

        float roll = this.m_xThrow * this.m_controlRollFactor;
        
        this.transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    // Called by string reference in CollisionHandler
    public void OnPlayerDeath ()
    {
        this.m_isControlEnabled = false;
    }
    #endregion
}
