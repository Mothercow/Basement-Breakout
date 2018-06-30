using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    //public bool NegativeProc = false;
    // public bool PositiveProc = false;

   // public int timeLeft = 5;
    bool activate = true;
    int timeleft ;
    public Text nameText;
    public Text dialogueText;

    //public Animator animator;

    private Queue<string> sentences;

    // Use this for initialization
    void Start() {
        
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        timeleft = FindObjectOfType<DialogueTrigger>().timeLeft;
       // animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();



    }
    public void Clear()
    {
        sentences.Clear();
    }

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
        StartCoroutine("LoseTime");
        StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
   
    void EndDialogue()
	{
	//	animator.SetBool("IsOpen", false);
	}
    private void Update()
    {
       // Debug.Log(timeleft);
       // if (activate == true)
        //{
          //  Debug.Log("Off");
            if (timeleft <= 0)
            {
               
                dialogueText.text = "";
                StopCoroutine("LoseTime");

               // activate = false;

            }
      //  }
        
       
        
    }
    IEnumerator LoseTime()
    {
            while (true)
            {
               
                    yield return new WaitForSeconds(1);
                    timeleft--;
                
                
            }
        
        
    }

}
