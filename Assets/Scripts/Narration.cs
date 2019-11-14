using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Narration : MonoBehaviour
{
    GameObject NarrativeUI;
    GameObject DialogPanel;
    GameObject DialogText;
    Text DialogTexttext;
    public GameObject nextScreen;
    [System.Serializable]
    public struct Lines
    {
        [TextArea(2,5)]
        public string text;
    }
    public Lines[] line=new Lines[10];
    int currentLineIndex = 0;
    
    // Update is called once per frame
    private void Start()
    {
        NarrativeUI = GameObject.FindGameObjectWithTag("NarrativeUI");
        DialogPanel = NarrativeUI.transform.GetChild(0).gameObject;
        DialogText=NarrativeUI.transform.GetChild(1).gameObject;
        DialogPanel.SetActive(true);
        DialogText.SetActive(true);
        DialogTexttext = DialogText.GetComponent<Text>();
        DialogTexttext.text = line[0].text;
    }
    void AdvanceLine()
    {
        
        currentLineIndex = currentLineIndex + 1;
        if(currentLineIndex < line.Length)
        DialogTexttext.text = line[currentLineIndex].text;
        else
        {
            DialogPanel.SetActive(false);
            DialogText.SetActive(false);

            ChoiceHandler.currentChoice = nextScreen;
            ChoiceHandler.prevChoice = gameObject;
            nextScreen.SetActive(true);
            gameObject.SetActive(false);

        }
    }
    void Update()
    {
    if(Input.GetKeyDown("space"))
        {
            AdvanceLine();
        }
    }
}
