using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasDamageScript : MonoBehaviour
{
    public Texture tex1;
    public Texture tex2;
    public Texture tex3;
    public Texture tex4;

    public GameObject loseScreen;

    public float gasTimer = 30.0f;
    private bool gasTimerStarted = false;

    private void Update()
    {
       // Debug.Log(gasTimer);
       // Debug.Log(SawCollision.gasStart);

        if(SawCollision.gasStart == true)
        {
            gasTimerStarted = true;
        }

        if(gasTimerStarted == true)
        {
            gasTimer -= Time.deltaTime;
        }

        if(gasTimer <= 0)
        {
            gasTimer = 0;
            loseScreen.SetActive(true);
        }
    }

    private void OnGUI()
    {
        if(gasTimer <= 30.0f && gasTimerStarted == true)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex1);
        }
        if (gasTimer <= 20.0f && gasTimerStarted == true)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex2);
        }
        if (gasTimer <= 10.0f && gasTimerStarted == true)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex3);
        }
        if (gasTimer <= 5.0f && gasTimerStarted == true)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex4);
        }
    }

}
