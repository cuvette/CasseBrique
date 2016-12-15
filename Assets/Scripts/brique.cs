using UnityEngine;
using System.Collections;

public class brique : MonoBehaviour
{

    public GameObject particuleBrique;

    void OnCollisionEnter(Collision other)
    {
        Instantiate(particuleBrique, transform.position, Quaternion.identity);
        GameManager.instance.DestroyBrick();
        Destroy(gameObject);
    }
}