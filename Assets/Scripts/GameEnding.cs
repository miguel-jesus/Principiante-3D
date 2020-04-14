using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public float displayImageDuration = 1f;

    bool m_IsPlayerAtExit;
    float m_Timer;
    

    void OnTriggerEnter(Collider other)
    {
        //en cuanto el pj entre al trigger y sea igual al player,nuestro booleano pasara a ser true
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        //cronómetro que empieza a contar desde el momento que lo cruza
        m_Timer += Time.deltaTime;
        //Duración del desvanecimiento y asi iremos incrementando el alpga cada vez mas porque llamaremos a esta funcion
        //desde el update
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}
