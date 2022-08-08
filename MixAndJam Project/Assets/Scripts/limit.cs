using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class limit : MonoBehaviour
{
    float currentTime =0f;
    public float startingTime= 10f;
    public Text countDownText;
    public GameObject YouWIN;
    public GameObject startingText;
  
   
   
   

    // Start is called before the first frame update
   
     public void Start()
    {

            currentTime = startingTime;
         
        
    }
    // Update is called once per frame
    void Update()
    {



        if(!startingText)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = "Time Left:" + currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                YouWIN.SetActive(true);
               
                Time.timeScale = 0f;
            }
        }
        
           
            
        





    }
}
