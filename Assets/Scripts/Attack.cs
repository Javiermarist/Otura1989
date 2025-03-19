using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public GameObject sphere;
    private float attackDelay = 1.10f;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            sphere.SetActive(true);
            StartCoroutine(DeactivateSphereAfterDelay());
        }
    }

    private IEnumerator DeactivateSphereAfterDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        sphere.SetActive(false);
        isAttacking = false;
    }
}