﻿using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject effect = ObjectPool.instance.GetPooledObject();

            if(effect!= null)
            {
                effect.transform.position = transform.position;
                effect.transform.rotation = effect.transform.rotation;
                effect.SetActive(true);
            }

            PlayerPrefs.SetInt("TotalGems", PlayerPrefs.GetInt("TotalGems", 0) + 1);
            FindObjectOfType<AudioManager>().PlaySound("PickUp");
           
            gameObject.SetActive(false);
        }
    }
}
