using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBot : MonoBehaviour
{
    public uint repairBot = 1;
    Animator m_animator;
    SpriteRenderer m_spr;
    // Start is called before the first frame update
    void Start()
    {
        m_spr = this.gameObject.GetComponent<SpriteRenderer>();
        m_animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotRepair()
    {
        ++repairBot;
        //m_spr.sprite = Resources.Load()
        m_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(LoadAnimator());
    }

    string LoadAnimator()
    {
        if(repairBot == 1)
        {
            return "Animations/p1_player_0";
        } else if (repairBot == 2)
        {
            return "Animations/p2_player";
        } else if (repairBot == 3)
        {
            return "Animations/p3_player";
        } else if (repairBot == 4)
        {
            //The person who wrote that in all upper case should die.
            return "Animations/p4_PLAYER";
        } else if (repairBot == 5)
        {
            //NO PLAYER ANIMATOR FOR P5
            return "Animations/p4_PLAYER";
        } else
        {
            return "Animations/p1_player_0";
        }
    }
}
