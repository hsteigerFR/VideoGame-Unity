﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonhommeLAC : MonoBehaviour
{
    // Start is called before the first frame update
    
    public CharacterMovement1 script;
    public QuestAchievements scriptA;
    private bool is_OK;
    private bool done;
    private List<string> dialog1;
    private List<string> dialog2;
    private bool dialog;

    public Image img;
    public Text nom;
    public Text corps;
    public Image end;

    public GameObject box;
    public GameObject box2;

    void Start()
    {
        dialog1 = new List<string>();
        dialog2 = new List<string>();
        dialog1.Add("Ouin ! Ouin ! J'ai perdu mon jouet au fond du lac.");
        dialog2.Add("Vous ... Vous avez récupéré mon jouet ! Merci beaucoup, prenez cette carte IZLY en échange !");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && is_OK)
        {
            dialog = true;
            box.SetActive(false);
            box2.SetActive(true);
            if (done)
            {
                //Debug.Log(dialog2[0]);
                scriptA.carte_izly = true;
            }
            else
            {
                //Debug.Log(dialog1[0]);
            }

        }

        if (scriptA.jouet || scriptA.carte_izly)
        {
            done = true;
        }
        else
        {
            done = false;
        }

        if (dialog)
        {
            img.enabled = true;
            nom.enabled = true;
            corps.enabled = true;
            end.enabled = true;
            nom.text = "Bonhomme LAC (Dialogue)";
            if (done ) {
                corps.text = dialog2[0];
                scriptA.jouet = false;
            }
            else
            {
                corps.text = dialog1[0];
            }
        }

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        is_OK = true;
        box.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        is_OK = false;
        dialog = false;

        img.enabled = false;
        nom.enabled = false;
        corps.enabled = false;
        end.enabled = false;

        box.SetActive(false);
        box2.SetActive(false);
    }
}
