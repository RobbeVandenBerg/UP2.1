using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    //Only works in the compiled version (.exe)
    public void sluitAf()
    {
        Application.Quit();
    }
}
