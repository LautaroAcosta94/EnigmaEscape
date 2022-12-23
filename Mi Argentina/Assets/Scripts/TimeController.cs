using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    [SerializeField] int min, seg;
    public TextMeshPro tiempo;

    float restante;
    public static bool enMarcha;

    void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
    }

    void Update()
    {
       if (enMarcha)
        {
            restante -= Time.deltaTime;
            if (restante < 1)
            {
                enMarcha = false;
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        } 
    }
}
