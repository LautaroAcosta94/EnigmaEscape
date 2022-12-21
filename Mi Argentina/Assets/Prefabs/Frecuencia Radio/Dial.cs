using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dial : MonoBehaviour
{
    public AudioSource emisora60;
    public AudioSource emisora65;
    public AudioSource emisora70;
    public AudioSource emisora75;
    public AudioSource emisora80;
    public AudioSource emisora85;
    public AudioSource emisora90;
    public AudioSource emisora95;
    public AudioSource emisora100;
    public AudioSource emisora105;
    public AudioSource sintonizando;


    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.CompareTag("sintonizando"))
        {
            sintonizando.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora60"))
        {
            emisora60.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora65"))
        {
            emisora65.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora70"))
        {
            emisora70.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora75"))
        {
            emisora75.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora80"))
        {
            emisora80.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora85"))
        {
            emisora85.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora90"))
        {
            emisora90.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora95"))
        {
            emisora95.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora100"))
        {
            emisora100.Play();
        }

        if (col.transform.gameObject.CompareTag("emisora105"))
        {
            emisora105.Play();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.transform.gameObject.CompareTag("sintonizando"))
        {
            sintonizando.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora60"))
        {
            emisora60.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora65"))
        {
            emisora65.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora70"))
        {
            emisora70.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora75"))
        {
            emisora75.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora80"))
        {
            emisora80.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora85"))
        {
            emisora85.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora90"))
        {
            emisora90.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora95"))
        {
            emisora95.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora100"))
        {
            emisora100.Stop();
        }

        if (col.transform.gameObject.CompareTag("emisora105"))
        {
            emisora105.Stop();
        }
    }

}
