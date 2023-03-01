using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControll : MonoBehaviour
{
    public Transform player;
    [SerializeField] float camSpeed;

    private void Awake()
    {
        Vector3 playerPosition = new Vector3(player.position.x, player.position.y, -10f);

    }

    void FixedUpdate()
    {
        Vector3 playerPosition = new Vector3(player.position.x, player.position.y, -10f);
        //Vector3 camPosition = new Vector3(transform.position.x, transform.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, playerPosition, Time.deltaTime * camSpeed);
    }
}
