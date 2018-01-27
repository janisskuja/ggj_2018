using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIFade : MonoBehaviour {
    
   

   public void animFadeIn ()
    {
        for (int i = 1; i>20; i++)
        {
        gameObject.GetComponent<CanvasGroup>().alpha = gameObject.GetComponent<CanvasGroup>().alpha + 0.1f;
        }
    
    }
    public void animFadeOut ()
    {
        for (int i = 1;i>20;i++)
        {
        gameObject.GetComponent<CanvasGroup>().alpha = gameObject.GetComponent<CanvasGroup>().alpha - 0.05f;
        }
    
    }
}

