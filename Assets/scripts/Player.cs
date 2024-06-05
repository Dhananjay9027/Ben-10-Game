using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;//erialisze.. use to show it on unity so that we can change it from thier
    [SerializeField] private GameInput gameInput;
    private bool IsWalking;
    private float sprintspeed = 5f;
    private float basespeed = 2f;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementNormalized();
        Vector3 moveDir= new Vector3(inputVector.x,0f,inputVector.y);
        if(gameInput.IsRunning())
        {
            transform.position += moveDir * sprintspeed * Time.deltaTime;
        }
        else
        {
            transform.position += moveDir * basespeed * Time.deltaTime;
        }
        IsWalking=moveDir!=Vector3.zero;
        float rotateSpeed = 30f;
        transform.forward=Vector3.Slerp(transform.forward,moveDir,Time.deltaTime*rotateSpeed);
    }
    public bool Is_Walking()
    {
        return IsWalking;
    }
    
    public bool Is_Running()
    {
        return gameInput.IsRunning() && Is_Walking();
    }
}
