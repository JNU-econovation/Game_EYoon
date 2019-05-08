using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Vector3 mousePosition;
    public Transform firePosition;
    Camera Camera;
    public GameObject bullet;
    public GameObject target;
    Transform bulletPosition;
    public int speed;
    public float attackDelay;
    bool attackable = true;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && attackable)
        {
            StartCoroutine(attack());

            
        }
        

    }

    IEnumerator attack()
    {
        attackable = false;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        mousePosition = Input.mousePosition;
        mousePosition = Camera.ScreenToWorldPoint(mousePosition);
        Instantiate(target, mousePosition, Rotation);
        Instantiate(bullet, firePosition.position, Rotation);
        yield return new WaitForSeconds(attackDelay);
        attackable = true;
    }
}
