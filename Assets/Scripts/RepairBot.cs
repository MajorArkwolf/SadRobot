using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBot : MonoBehaviour
{
    public uint repairBot = 1;
    Animator m_animator;
    SpriteRenderer m_spr;
    PlayerPhysics m_pp;
    // Start is called before the first frame update
    void Start()
    {
        m_spr = this.gameObject.GetComponent<SpriteRenderer>();
        m_animator = this.gameObject.GetComponent<Animator>();
        m_pp = this.gameObject.GetComponent<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BotRepair()
    {
        ++repairBot;
        string loaddir;
        if (repairBot == 1)
        {
            loaddir = "Animations/p1_player_0";
        }
        else if (repairBot == 2)
        {
            loaddir = "Animations/p2_player";
        }
        else if (repairBot == 3)
        {
            loaddir = "Animations/p3_player";
        }
        else if (repairBot == 4)
        {
            //The person who wrote that in all upper case should die.
            loaddir = "Animations/p4_PLAYER";
        }
        else if (repairBot == 5)
        {
            //NO PLAYER ANIMATOR FOR P5
            loaddir = "Animations/p4_PLAYER";
        }
        else
        {
            loaddir = "Animations/p1_player_0";
        }
        m_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(loaddir);
    }
}