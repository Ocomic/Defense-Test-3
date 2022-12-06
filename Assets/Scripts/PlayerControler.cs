using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    //[SerializeField] InputAction movement;
    //[SerializeField] InputAction fire;

    [SerializeField] float controlSpeed = 0.1f;
    [SerializeField] float xRange = 12f;
    [SerializeField] float yRange = 10f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -35f;
    [SerializeField] float positionYawFactor = -1f;
    [SerializeField] float controlRollFactor = 30f;

    float horizontalThrow;
    float verticalThrow;

    void Start()
    {
        
    }

    /// <summary>
    /// needed with new Input System to enable movements/ Input System
    /// </summary>
    //private void OnEnable()
    //{
    //    movement.Enable();
    //}
    /// <summary>
    /// Disable, when it is not needed
    /// </summary>
    //private void OnDisable()
    //{
    //    movement?.Disable();
    //}
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = verticalThrow * controlPitchFactor;

        float pitchY = pitchDueToPosition + pitchDueToControlThrow;
        float yawX = transform.localPosition.x * positionYawFactor;
        float rollZ = horizontalThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitchY, yawX, rollZ);
    }
    void ProcessTranslation()
    {
        //float horizontalThrow = movement.ReadValue<Vector2>().x;
        //Debug.Log(horizontalThrow);
        //float verticalThrow = movement.ReadValue<Vector2>().y;
        //Debug.Log(verticalThrow);

        horizontalThrow = Input.GetAxis("Horizontal");
        //Debug.Log(horizontalThrow);
        verticalThrow = Input.GetAxis("Vertical");
        //Debug.Log(verticalThrow);
        float fire1ButtonPushed = Input.GetAxis("Fire1");
        //Debug.Log(fire1ButtonPushed);
        float xOffset = horizontalThrow * controlSpeed;
        float yOffset = verticalThrow * controlSpeed;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
