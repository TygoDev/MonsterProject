using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGroupAssign : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(Tags.T_Player);
        this.GetComponent<Cinemachine.CinemachineTargetGroup>().AddMember(players[0].transform, 1, 2f);
        this.GetComponent<Cinemachine.CinemachineTargetGroup>().AddMember(players[1].transform, 1, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
