using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    
   

    [System.Serializable]
     public struct Choices
    {
       public GameObject nextChoice;
       public KeyCode key;
        
    }
    public Choices[] obj = new Choices[10];
    
}
