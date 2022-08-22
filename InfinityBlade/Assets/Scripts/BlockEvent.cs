using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEvent : MonoBehaviour
{
    public PlayMakerFSM fsm;
    public direction dir;

    // Start is called before the first frame update
    void Start()
    {
        fsm = GetComponent<PlayMakerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckDir>().dir;
        AttackBlocked();
    }

    public void AttackBlocked()
    {
        if (fsm.ActiveStateName == "AttackingRight" && dir == direction.right)
        {
            fsm.SetState("RightBlocked");
        }
        if (fsm.ActiveStateName == "AttackingRight" && dir == direction.right)
        {
            fsm.SetState("RightBlocked");
        }
    }
}
