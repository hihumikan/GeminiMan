using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CitizenCon : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update () {
        agent.SetDestination(target.position);
    }
  // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit"); // ログを表示する
    }
}
