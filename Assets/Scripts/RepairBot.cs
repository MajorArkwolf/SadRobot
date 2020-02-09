using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBot : MonoBehaviour
{
    public uint repairBot = 1;
    Animator m_animator;
    SpriteRenderer m_spr;
    PlayerPhysics m_pp;
    Transform m_t;
    // Start is called before the first frame update
    void Start()
    {
        m_spr = this.gameObject.GetComponent<SpriteRenderer>();
        m_animator = this.gameObject.GetComponent<Animator>();
        m_pp = this.gameObject.GetComponent<PlayerPhysics>();
        m_t = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BotRepair()
    {
        ++repairBot;
    if (repairBot == 2)
        {
            var x = Instantiate(Resources.Load<GameObject>("Prefab/Phase2"), m_t.position, Quaternion.identity);
            Camera.main.GetComponent<CameraFollow>().target = x;
        }
        else if (repairBot == 3)
        {
            var x = Instantiate(Resources.Load<GameObject>("Prefab/Phase3"), m_t.position, Quaternion.identity);
            Camera.main.GetComponent<CameraFollow>().target = x;
        }
        else if (repairBot == 4)
        {
            var x = Instantiate(Resources.Load<GameObject>("Prefab/Phase4"), m_t.position, Quaternion.identity);
            Camera.main.GetComponent<CameraFollow>().target = x;
        }
        else if (repairBot == 5)
        {
            var x = Instantiate(Resources.Load<GameObject>("Prefab/Phase5"), m_t.position, Quaternion.identity);
            Camera.main.GetComponent<CameraFollow>().target = x;
            
        }
        else
        {
            var x = Instantiate(Resources.Load<GameObject>("Prefab/Phase1"), m_t.position, Quaternion.identity);
            Camera.main.GetComponent<CameraFollow>().target = x;
        }
        Destroy(this.gameObject);
    }
}
