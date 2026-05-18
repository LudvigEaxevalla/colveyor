using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColorHouseScript : MonoBehaviour
{

    public GameObject output;
    public bool active = false;
    public float spawnTime = 5f;

    private void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        active = true;
        Debug.Log("Active is " + active);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
        Debug.Log(active);
    }


    IEnumerator SpawnTimer()
    {
        while (true)
        {
            if (active)
            { 
                Instantiate(output, new Vector3(1,0,0), Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }

            else
            {
                yield return null;

            }
        }
    }
    
}

