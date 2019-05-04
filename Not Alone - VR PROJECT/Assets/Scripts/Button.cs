using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string color;
    public EnigmaColorsController controller;


    public virtual void setColorToCode()
    {
        controller.setColor(color);
    }
}
