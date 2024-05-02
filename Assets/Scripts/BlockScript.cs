using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class BlockScript : MonoBehaviour
{
    public bool isHittable;

    [SerializeField]
    private UnityEvent _hit;

    public int hits = 0;
    int hitsNeeded;
    int number;
    string name;
   private string order;



    void Start()
    {
        
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("destructable"))
        {
            if (collision.contacts[0].normal.y > 0)
            {
                _hit.Invoke();
                hits++;
            }
        }
        else if (gameObject.CompareTag("not_destructable"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void Update()
    {
        GameObject Manager = GameObject.Find("CubeManager");

        name = gameObject.name;
        number = int.Parse(name);
        order = "ob" + number;
        hitsNeeded = (int)Manager.GetComponent<CubeManagerScript>().GetType().GetField(order).GetValue(Manager.GetComponent<CubeManagerScript>());

        if (hits >= hitsNeeded)
        {
            Manager.GetComponent<CubeManagerScript>().DestroyNextObject();
            Destroy(gameObject);
        }
    }
}
