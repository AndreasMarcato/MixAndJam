using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPort : MonoBehaviour
{

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;                //--Force screen orientation
    }
}
