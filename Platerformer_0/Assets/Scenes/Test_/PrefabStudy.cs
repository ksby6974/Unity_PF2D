using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStudy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    public CapsuleCollider2D capsuleCollider2D;
    public Animator animator;                   // �θ� ����
    public AudioSource audioSource;             // �ڽ� ����


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
