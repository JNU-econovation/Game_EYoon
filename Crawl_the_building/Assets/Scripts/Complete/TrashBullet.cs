using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBullet : MonoBehaviour
{
    public float speed;
    [SerializeField]
    float lifeTime = 5.0f;

    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed);        
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
