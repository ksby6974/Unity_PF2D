using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStudy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    public CapsuleCollider2D capsuleCollider2D;
    public Animator animator;                   // 부모 소유
    public AudioSource audioSource;             // 자식 소유


    // Start is called before the first frame update
    void Start()
    {
        // GetComponent
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponentInParent<AudioSource>();

        spriteRenderer.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
