using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class Timer : MonoBehaviour
{
    public int Seconds = 5;
    public int Minutes;
    public Text countdownText;
 
    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
    }
 
    // Update is called once per frame
    void Update()
    {
        if(Seconds<10)
        {
            countdownText.text = ("Time Left = " + Minutes + " : " + "0"+ Seconds);
        }
        else
        {
            countdownText.text = ("Time Left = " + Minutes + " : " + Seconds);
        }
        

        if (Seconds <= 0 && Minutes <= 0)
        {
            StopCoroutine("LoseTime");


        }
        else if (Seconds <= 0 && Minutes > 0)
        {

            Minutes--;
            Seconds = 59;
        }
    }
 
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Seconds--;
        }
    }
}