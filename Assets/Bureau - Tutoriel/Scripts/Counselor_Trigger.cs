using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counselor_Trigger : MonoBehaviour
{
    private List<string> list;
    public GoalAchievement goal;
    public CharacterMovement movement;
    public GameObject nom;
    public GameObject corps;
    public GameObject end;
    public Image image;
    private bool is_OK;
    // Start is called before the first frame update
    void Start()
    {
        list = new List<string>();
        string s0 = "Conseiller d'orientation (Description)";
        string s1 = "Un vieil homme, qui semble avoir été vidé de son âme par son expérience passée. Il ne doit pas être très loin de la retraite, mais je ne souhaite à personne de le remplacer et de subir le même sort.";
        list.Add(s0);
        list.Add(s1);
        is_OK = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (goal.is_interacting && is_OK)
        {
            nom.SetActive(true);
            nom.GetComponent<Text>().text = list[0];

            corps.SetActive(true);
            corps.GetComponent<Text>().text = list[1];

            end.SetActive(true);
            image.enabled = true;

           
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (goal.must_interact || goal.has_interacted)
        {
            if (Input.GetButtonDown("Interact")) 
            { 
                //movement.is_stunned = true;
                goal.is_interacting = true;
                goal.has_interacted = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        is_OK = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        is_OK = false;
        nom.SetActive(false);
        corps.SetActive(false);
        end.SetActive(false);
        image.enabled = false;
        goal.is_interacting = false;
        movement.is_stunned = false;
    }
}
