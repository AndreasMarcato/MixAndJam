using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    //--This script is used every time there is a Cut Scene and story is being told
    public GameObject[] images;
    int index;
    public Button startButton;  //--For starting button

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= images.Length)      //once we reach the end of all images, you can't click further
        {
            index = images.Length;
            startButton.gameObject.SetActive(true);     //--Start button will appear
        }


        if (index == 0)
        {
            images[0].gameObject.SetActive(true);       //--At the start we set the first image active
        }
    }

    public void Next()
    {
        index += 1; //-- go to next page
        
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);       //--Last image is now hidden
            images[index].gameObject.SetActive(true);   //--Show next image
        }
    }

    //--Load next scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
