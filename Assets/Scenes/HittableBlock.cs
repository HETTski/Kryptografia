using System;
using UnityEngine;
using UnityEngine.Events;

public class HittableBlock : MonoBehaviour
{
    public bool isHittable;

    [SerializeField]
    private UnityEvent _hit;

    
    private void OnCollisionEnter(Collision collision)
    {
      //  var player = collision.collider.GetComponent<Sphere>();
        if (collision.contacts[0].normal.y > 0)
        {
            _hit.Invoke();
           isHittable = true;
        }
    }
}
