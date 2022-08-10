using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureVisabilityScript : MonoBehaviour
{
    public Text startText = null;
    public bool winTextActive = false;

    // Start is called before the first frame update
    void Start()
    {
        EnableText();
        Invoke("DisableText", 3f);
        Invoke("DisablePicture", 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (winTextActive)
        {
            // display text
        }
    }


    private void DisablePicture()
    {
        this.gameObject.SetActive(false);
    }

    private void EnablePicture()
    {
        this.gameObject.SetActive(true);
    }


    private void DisableText()
    {
        startText.gameObject.SetActive(false);

    }


    private void EnableText()
    {
        startText.gameObject.SetActive(true);
    }




}
