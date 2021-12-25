using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //[SerializeField] private Slider healthBar;

    private Vector3 TargetPos;

    [SerializeField] private float speed;
    [SerializeField] private GameObject[] position;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Debug.Log(TargetPos);
        if (Vector3.Distance(transform.position, TargetPos) < 0.2f)
        {
            TargetPos = position[Random.Range(0, position.Length)].transform.position;
        }
        else
        {
            Move();
        }


    }

    void Move()
    {

        transform.position = Vector3.Lerp(transform.position, TargetPos, speed * Time.deltaTime);
    }
}
