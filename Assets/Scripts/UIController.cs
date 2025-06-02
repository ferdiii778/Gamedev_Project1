using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public PlayerMovement player; // Drag player dari scene ke sini

    public void OnLeftDown() => player.MoveLeft();
    public void OnRightDown() => player.MoveRight();
    public void OnMoveUp() => player.StopMove();
    public void OnJump() => player.Jump();
    public void OnAttack() => player.Attack();
}
