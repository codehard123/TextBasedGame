using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDisplay : MonoBehaviour
{

    public Conversation conversation; //Holds the conversation
    public GameObject speakerLeft; // UI of left speaker
    public GameObject speakerRight; // UI of right speaker
    private SpeakerUI speakerUILeft;//Script of leftspeaker
    private SpeakerUI speakerUIRight;//Script of rightSpeaker
    [SerializeField] GameObject nextScreen;
    private int activeLineIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
        speakerUILeft.Speaker = conversation.speakerLeft;//Assigns Speaker of SpeakerUI Class
        speakerUIRight.Speaker = conversation.speakerRight;//Assigns Speaker of right SpeakerUI Class
    }
    void DisplayLine() 
    {

        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;
        if(speakerUILeft.SpeakerIs(character))
        {//Checks whether the Left Speaker is the character speaking
            SetDialog(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line.text);
        }
    }
    void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialog = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();

    }
    
    void AdvanceConversation() {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakerUILeft.Hide();
            speakerUIRight.Hide();
            activeLineIndex = 0;
            nextScreen.SetActive(true);
            
            ChoiceHandler.currentChoice = nextScreen;
            ChoiceHandler.prevChoice = gameObject;

            gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
    }
}
