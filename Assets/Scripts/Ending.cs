using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public Animator endText;
    public Animator win;
    private bool isInFinal;
    public GameObject endingScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInFinal)
        {
            endingScreen.SetActive(true);
            win.SetTrigger("Win");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            endText.SetBool("Showing", true);
            isInFinal= true;
        }
    }
}
