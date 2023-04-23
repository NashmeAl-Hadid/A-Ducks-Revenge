using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WeaponText_Controller : MonoBehaviour {

    private Game_Master gm;
    public TextMeshProUGUI text;

 void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();

    }

    //Shows no weapon text on screen when the player shoots and doesn't have the weapon 
  public void CheckWeapon()
  {
    if (gm.gunPicked == false)
    {
            StartCoroutine(TextFlash());
    }
  }

  IEnumerator TextFlash()
  {
    text.gameObject.SetActive(true);
    yield return new WaitForSeconds(1f);

    yield return new WaitForSeconds(1f);
    text.gameObject.SetActive(false);
  }
}
