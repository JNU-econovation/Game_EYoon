using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1;
    GameObject target;
    public Camera cam;
    public int damage;
    WindowHP windowhp;
    private void Start()
    {
        
        target = cam.GetComponent<Cam>().target;
        windowhp = target.GetComponent<WindowHP>();
      
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject == target)
        {
            windowhp.HP -= damage;
            print(windowhp.HP);
            Destroy(gameObject);
            windowhp.ChangeWindow();
        }
    }

}
