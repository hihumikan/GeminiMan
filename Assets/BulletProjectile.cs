using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    private Rigidbody BulletRigidbody;
    private void Awake()
    {
        BulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start(){
        float speed = 200f;
        BulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other){
    if (other.GetComponent<BulletTarget>() != null)
    {
        Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        Debug.Log("Hit"); // ログを表示する
        Destroy(other.gameObject);
        SceneManager.LoadScene("GameClear");
    } else {
        Instantiate(vfxHitRed, transform.position, Quaternion.identity);
    }
    if (other.GetComponent<BulletCitizen>() != null)
    {
        Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        Debug.Log("Hit"); // ログを表示する
        Destroy(other.gameObject);
        SceneManager.LoadScene("GameOver");
    }

    Destroy(gameObject);
    }
}
