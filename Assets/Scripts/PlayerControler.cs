using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    // Start is called before the first frame update
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
        float xOffset = 1f;
        float newXPos = transform.localPosition.x + xOffset;

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
