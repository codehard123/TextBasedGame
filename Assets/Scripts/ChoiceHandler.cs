using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceHandler : MonoBehaviour
{
     public static GameObject currentChoice;
     public  static GameObject prevChoice;
   
     private void Start()
    {
        prevChoice = GameObject.FindGameObjectWithTag("Empty");
        currentChoice = GameObject.FindGameObjectWithTag("Start").transform.GetChild(0).gameObject;

        prevChoice.SetActive(false);
        currentChoice.SetActive(true);
        choice = currentChoice.GetComponent<Choice>();
    }
    Choice choice;
    void Starts()
    {
        prevChoice.SetActive(false);
        currentChoice.SetActive(true);
        if(currentChoice.GetComponent<Choice>()!=null)
        choice = currentChoice.GetComponent<Choice>();

    }

    
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("CurrentChoice" + currentChoice.name);
            Debug.Log("PrevChoice" + prevChoice.name);
            Starts();
            if (choice != null)
            {
                for (int i = 0; i < choice.obj.Length; i++)
                {
                    if (Input.GetKeyDown(choice.obj[i].key))
                    {
                        Debug.Log("Kos");
                        prevChoice = currentChoice;
                        currentChoice = choice.obj[i].nextChoice;
                        Starts();
                    }
                }
            }
        }
      
    }
}
