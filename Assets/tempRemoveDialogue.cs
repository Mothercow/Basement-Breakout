using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempRemoveDialogue : MonoBehaviour
{
    public Text dialogueText;
    public GameObject hacksawTemp;

    bool removeDial;
    string emptyString = "";
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("WaitToEnd");
        if (removeDial == true)
        {
            dialogueText.text = emptyString;
        }
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(10);
        removeDial = true;
    }
}
