using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    public GameObject[] elementsToSpawn;
    
    private float tiempo;
    public float tEspera;
    public float timeToDestroy;
    public int limit, count = 0;
    public GameObject[] elementsSpawned;
    void Start()
    {
        elementsSpawned = new GameObject[limit];
    }

        void Update() {
        if (count < limit)
        {
        
        if (tiempo <= 0) {
                Debug.Log("Stoy spawn");
                elementsSpawned[count] = Instantiate(elementsToSpawn[0], new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
                StartCoroutine(waitForDestroy(count));
                tiempo = tEspera;
                count++;
        } else {
            tiempo -= Time.deltaTime;
        }
        }else
        {
            if (elementsSpawned[0] == null)
            {
                count = 0;
            }
            
        }
    }
    //Cuando salga del mapa se destruye
    private IEnumerator waitForDestroy(int pos)
    {
        yield return new WaitForSecondsRealtime(timeToDestroy);
        Destroy(elementsSpawned[pos]);
    }
}