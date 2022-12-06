using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    //[SerializeField] InputAction movement;
    //[SerializeField] InputAction fire;

    [SerializeField] float controlSpeed = 0.2f;
    [SerializeField] float xRange = 12f;
    [SerializeField] float yRange = 10f;

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
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }
    void ProcessTranslation()
    {
        //float horizontalThrow = movement.ReadValue<Vector2>().x;
        //Debug.Log(horizontalThrow);
        //float verticalThrow = movement.ReadValue<Vector2>().y;
        //Debug.Log(verticalThrow);

        float horizontalThrow = Input.GetAxis("Horizontal");
        //Debug.Log(horizontalThrow);
        float verticalThrow = Input.GetAxis("Vertical");
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
