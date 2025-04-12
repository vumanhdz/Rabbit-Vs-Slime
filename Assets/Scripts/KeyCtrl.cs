using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCtrl : MonoBehaviour
{
    [SerializeField] private GameObject KeyOn;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            KeyOn.SetActive(true);
        }
    }

}
