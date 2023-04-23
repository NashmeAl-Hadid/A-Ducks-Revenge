using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint_Controller : MonoBehaviour {

    //Declarations
    private Game_Master gm;
    private SpriteRenderer setSpriteRenderer;
    public TextMeshProUGUI text;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
        setSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            //Play checkpoint sound
            OtherSound_Controller.OtherSound("CheckpointSound");
            //Save checkpoint
            gm.lastCheckPointPos = transform.position;
            StartCoroutine(Flash());
        } 
    }
    
    //Flash Green
    IEnumerator Flash()
    {
        setSpriteRenderer.color = Color.green;
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        setSpriteRenderer.color = Color.white;
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(false);
    }
}
