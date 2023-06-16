using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInput : MonoBehaviour
{
   public void ShowDebugText(InputAction.CallbackContext context)
    {

        Debug.Log(context.ReadValue<float>());
    }
}
