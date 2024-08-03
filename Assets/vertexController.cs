using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertexController : MonoBehaviour
{
    public float gap;
    Vector3 o_position;
    public float speed;

    [SerializeField] GameObject right;
    [SerializeField] GameObject up;
    public void selfDestruct()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != o_position)
        {
            check();
        }
    }

    public void Connect()
    {
        o_position = transform.position;
    }

    void check()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gap - 0.127f);
    }
}
