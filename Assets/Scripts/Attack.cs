using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public GameObject sphere;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            animator.SetTrigger("Attack");
            sphere.SetActive(true);
        }
    }
}