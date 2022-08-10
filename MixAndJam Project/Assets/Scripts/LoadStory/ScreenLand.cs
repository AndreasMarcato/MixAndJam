using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLand : MonoBehaviour
{
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;                //--Force screen orientation
    }
}
