﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuitCanadien : MonoBehaviour
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
    public SwitchScenes switchS;
    private SurvivorScript surv_script;

    void Start()
    {
        dialog1 = new List<string>();
        dialog2 = new List<string>();
        dialog1.Add("Sauter dans le puit sans corde vous tuera sur le coup.");
        dialog2.Add("Vous avez récupéré la clé claquée en descendant au fond du puit.");
        surv_script = GameObject.Find("Survivor").GetComponent<SurvivorScript>();
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
                scriptA.cle = true;
            }
            else
            {
                //Debug.Log(dialog1[0]);
            }
        }

        if (scriptA.corde)
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
            nom.text = "Puit Canadien (Description)";
            if (done)
            {
                corps.text = dialog2[0];
                if (!surv_script.once3)
                {
                    switchS.MiniGame2();
                    surv_script.once3 = true;
                }
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
