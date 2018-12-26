using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day : MonoBehaviour
{
    public CheckPoint checkPoint;

    private Text targetText;

    private int hyouji;
   

    // Start is called before the first frame update
    void Start()
    {
        int hyouji = checkPoint.nissuu;   
    }

    // Update is called once per frame
    void Update()
    {
        this.targetText = this.GetComponent<Text>();
        //this.targetText.text = hyouji;
    }
}
/*
public class Next : MonoBehaviour
{

    private GameObject FloorText;
    private int Floor;
    public AudioClip m_clearSe;

    void Start()
    {
        NewGame.addfloor();
        int resultFloor = NewGame.getFloor();
        Floor = resultFloor;
        this.FloorText = GameObject.Find("FloorText");
        this.FloorText.GetComponent<Text>().text = this.Floor + "F";

        if (Floor != 1)
        {
            Debug.Log(Floor);
            AudioSource.PlayClipAtPoint(m_clearSe, transform.position);
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //LoadNextScene();

        this.FloorText.GetComponent<Text>().text = this.Floor + "F";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
*/    