using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenAnimation : MonoBehaviour
{
     private Animator animator;
    [SerializeField] private Player player;
    [SerializeField] private GameInput gameInput;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool("IsWalking", player.Is_Walking());
        animator.SetBool("Sprint", player.Is_Running());
    }
}
