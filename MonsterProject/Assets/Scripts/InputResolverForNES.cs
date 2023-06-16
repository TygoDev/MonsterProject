using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputResolverForNES : MonoBehaviour
{
    public float readValue;
    public void ReturnPressedValue(InputAction.CallbackContext context)
    {
        readValue =  context.ReadValue<float>();
    }
}
