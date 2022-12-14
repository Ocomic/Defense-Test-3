using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [Header("General Setup Settings")]
    //[SerializeField] InputAction movement;
    //[SerializeField] InputAction fire;

    [Tooltip("How fast ship moves")][SerializeField] float controlSpeed = 0.2f;
    [Tooltip("How fast Player moves horizontally")][SerializeField] float xRange = 12f;
    [Tooltip("How fast Player moves vertically")][SerializeField] float yRange = 10f;

    [Header("Laser Gun Array")]
    [Tooltip("Add Player Lasers here")][SerializeField] GameObject[] lasers;

    [Header("Screen Position based Tuning")]
    [Tooltip("Pitch Factor to adjust pitch")][SerializeField] float positionPitchFactor = -1f;
    [Tooltip("Yaw Factor to adjust yaw")][SerializeField] float positionYawFactor = -1f;

    [Header("Player Input based Tuning")]
    [Tooltip("Adjust pitch Factor based on Player controls")][SerializeField] float controlPitchFactor = -35f;
    [Tooltip("Asjust the Roll Factor based on Player Controls")][SerializeField] float controlRollFactor = -30f;

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
        ProcessFiring();

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

    void ProcessFiring()
    {
        //if pushing fire button
        //then print shooting
        //else DontDestroyOnLoad't print shooting

        if(Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    
}
