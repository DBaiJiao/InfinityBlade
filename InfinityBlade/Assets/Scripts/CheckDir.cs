using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HutongGames.PlayMaker;
public enum direction
{
    none,
    right,
    left
}

public class CheckDir : MonoBehaviour
{
    public Vector2 lastPosition;

    public direction dir;

    public PlayMakerFSM fsm;

    public float checkLength;
    
    // Start is called before the first frame update
    void Start()
    {
        fsm = GetComponent<PlayMakerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDirection();
        Attack();
    }

    public void Attack()
    {
        if ((fsm.ActiveStateName == "Idle") && (dir == direction.right) && (FsmVariables.GlobalVariables.GetFsmInt("Stamina").Value > 0))
        {
            fsm.SetState("AttackingToRight");
        }
        if ((fsm.ActiveStateName == "Idle") && (dir == direction.left) && (FsmVariables.GlobalVariables.GetFsmInt("Stamina").Value > 0))
        {
            fsm.SetState("AttackingToLeft");
        }
    }

    public void CheckDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 currPosition = Input.mousePosition;

            if (currPosition.x > lastPosition.x + checkLength)
            {
                dir = direction.right;
            }
            if (currPosition.x < lastPosition.x - checkLength)
            {
                dir = direction.left;
            }
            lastPosition = currPosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            dir = direction.none;
        }
        Debug.Log(dir);
    }
}
