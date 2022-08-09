using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
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
        if (index > images.Length)      //once we reach the end of all images, you can't click further
        {
            index = images.Length;
            startButton.gameObject.SetActive(true);     //--Start button will appear
        }


        if (index == 0)
        {
            images[0].gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        index += 1; //-- go to next page
        
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
        }
    }

    //--Load next scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
