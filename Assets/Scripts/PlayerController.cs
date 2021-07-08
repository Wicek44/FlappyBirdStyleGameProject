using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Animator Animator;
    [SerializeField] public Rigidbody2D rigidBody;
    [SerializeField] public float upForce;
    

    private float startingGravity;

    public bool PlayerClickedForTheFirstTime { get; private set; }
    public int Score { get; private set; } = 0;
    public Action<int> OnScoreChanged;
    public Action OnGameOver;

    public bool IsGameOver { get; private set; } = false;

    private void Awake()
    {
        startingGravity = rigidBody.gravityScale;
        rigidBody.gravityScale = 0;
    }

    void Update()
    {

        if(IsGameOver == true)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(!PlayerClickedForTheFirstTime)
            {
                rigidBody.gravityScale = startingGravity;
                PlayerClickedForTheFirstTime = true;
            }

            rigidBody.velocity = new Vector2(0, upForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Animator.SetTrigger(AnimatorKeys.PLAYER_DEAD_TRIGGER_KEY);
        Destroy(rigidBody);

        IsGameOver = true;
        OnGameOver?.Invoke();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score++;
        OnScoreChanged?.Invoke(Score);
    }
}
