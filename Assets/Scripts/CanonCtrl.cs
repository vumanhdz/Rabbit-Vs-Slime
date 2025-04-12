using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonCtrl : MonoBehaviour
{
    [SerializeField] private Transform playerCheck;
    [SerializeField] private float checkPoin;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject Apple;
    private GameObject Canon;
    private Animator ainm;
    private bool isPlayer;
    private bool isShotting;
    private GameObject existingApple;
    [SerializeField] private Transform childTransform;

    void Start()
    {
       
        Canon = GameObject.FindGameObjectWithTag("Canon");
        ainm = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        existingApple = GameObject.FindWithTag("Apple");
        if (existingApple == null)
        {
            isShotting = false;
        }
        isPlayer = Physics2D.Raycast(playerCheck.position, transform.up, checkPoin, playerLayer);
        if (isPlayer )
        {
            ShootApple();
            isShotting = true;
        }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {

        ainm.SetBool("isPlayer",isPlayer);
    }
    private void ShootApple()
    {
        if (!isShotting)
        {
            Instantiate(Apple, childTransform.position, Quaternion.identity);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x, playerCheck.position.y + checkPoin, playerCheck.position.z));
    }
}
