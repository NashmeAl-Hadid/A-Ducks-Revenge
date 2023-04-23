using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick_Controller : MonoBehaviour {

    private Game_Master gm;
    private Vector2 startPosition;
    public float upDownSpeed;
    public float distance;

    void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
        startPosition = this.transform.position;
    }
	
	//Setting the weapon picked true in game master, so that it gets saved upon player dying
	void Update ()
    {
		if(gm.gunPicked==true)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector3(startPosition.x, startPosition.y + (Mathf.Sin(Time.time * upDownSpeed))*distance, 0);
    }
}
