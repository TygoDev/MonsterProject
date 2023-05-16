using UnityEngine;

public class CameraGroupAssign : MonoBehaviour
{
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(Tags.T_Player);
        GetComponent<Cinemachine.CinemachineTargetGroup>().AddMember(players[0].transform, 1, 2f);
        GetComponent<Cinemachine.CinemachineTargetGroup>().AddMember(players[1].transform, 1, 2f);
    }
}
