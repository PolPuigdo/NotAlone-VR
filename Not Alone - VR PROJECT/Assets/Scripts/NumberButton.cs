using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberButton : MonoBehaviour
{
    public string romanNumber;
    public NumberShadowScript controller;

    public virtual void setNumberToCode()
    {
        controller.setNumber(romanNumber);
    }
}
