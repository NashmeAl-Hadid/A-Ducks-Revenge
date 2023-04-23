using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Controller : MonoBehaviour {

    public GameObject enemy;
    //public GameObject enemyTrap;
    public float respawnNumber;
    public float wait;
    public Transform Spawn;
    //public Transform Spawn2;
   // public string objectName;

	void OnTriggerEnter2D(Collider2D BoxCollider)
    {
        if(BoxCollider.gameObject.tag == "Player")
        {
            StartCoroutine(enemySpawner());
        }
    }

    //void EventController(string objectName)
    //{ 
    //    //switch (objectName)
    //    //{
    //    //    case "enemy":
    //    //        Instantiate(enemy, Spawn1.position, Spawn1.rotation);
    //    //        break;
    //    //    case "trap":
    //    //        Instantiate(enemyTrap, Spawn2.position, Spawn2.rotation);
    //    //        break;
    //    //    case "backtrap":
    //    //        Instantiate(enemyTrap, Spawn2.position, Spawn2.rotation);
    //    //        break;
    //    //}
    //}

    void OnTriggerExit2D(Collider2D BoxCollider)
    {
        if(BoxCollider.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    IEnumerator enemySpawner()
    {

        int i = 0;
        while(i < respawnNumber)
        {
            Instantiate(enemy, Spawn.position, Spawn.rotation);
            i++;

            yield return new WaitForSeconds(wait);
        }
    }
}
