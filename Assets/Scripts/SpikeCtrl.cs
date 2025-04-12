using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerCheck;
    [SerializeField] private float checkPoin;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject Spike;
    private bool isPlayer;
    void Start()
    {
        
    }
    void Update()
    {
        isPlayer = Physics2D.Raycast(playerCheck.position, transform.right, checkPoin, playerLayer);
        SpikeUp();
    }

    private void SpikeUp()
    {
        if (isPlayer)
        {
            Spike.SetActive(true);
        }
        else { Spike.SetActive(false);}
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + checkPoin, playerCheck.position.y, playerCheck  .position.z));
    }
}
