using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Text;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject dialogueBox;
    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;
    public float delay =-0.001f;
    public Queue<DialogueBase.Info> dialogueInfo;//Fifo collection

    //option stuff
    private bool isDialogueOption;
    public GameObject dialogueOptionUI;
    private bool inDialogue;
    public GameObject[] optionButtons;
    private void Awake()
    {
      if(instance !=null)
        {
            Debug.LogWarning("fix this" + gameObject.name);

        }else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnqueueDialogue(DialogueBase db)
    {
        if (inDialogue) return;
        inDialogue = true;
        dialogueBox.SetActive(true);
        dialogueInfo.Clear();
        if(db is DialogueOption)
        {
            isDialogueOption = true;
        }
        else
        {
            isDialogueOption = false;
        }
        foreach(DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }
        DequeueDialogue();
    }
    public void DequeueDialogue()
    {
        if (dialogueInfo.Count == 0)
        {
            EndofDialogue();
            return;
        }
        DialogueBase.Info info =dialogueInfo.Dequeue();

        dialogueName.text = info.myName;
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;

        StartCoroutine(Typetext(info));
    }

    IEnumerator Typetext(DialogueBase.Info info)
    {
        dialogueText.text = "";
        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            yield return null;
        }
    }
    public void EndofDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        OptionsLogic();
       
    }
    private void OptionsLogic()
    {
        if (isDialogueOption == true)
        {
            dialogueOptionUI.SetActive(true);
        }
    }
}
