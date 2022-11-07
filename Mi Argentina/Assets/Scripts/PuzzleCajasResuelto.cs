using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCajasResuelto : MonoBehaviour
{
    public AudioSource puzzleResuelto;

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.name == "PuzzleCompletado")
        {
            puzzleResuelto.Play();
        }
    }
}
