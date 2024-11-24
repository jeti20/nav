using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Dodajemy przestrzeñ nazw dla NavMeshAgent

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    [SerializeField] private NavMeshAgent navMeshAgent; // Dodajemy NavMeshAgent
    private Vector3 targetPosition;

    private void Awake()
    {
        if (navMeshAgent == null)
            navMeshAgent = GetComponent<NavMeshAgent>(); // Inicjalizujemy NavMeshAgent, jeœli nie przypisano w inspektorze
    }

    private void Update()
    {
        // Animacja i ruch
        if (navMeshAgent.velocity.magnitude > 0.1f) // Sprawdzamy, czy agent siê porusza
        {
            unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }

        // Sprawdzamy klikniêcie myszk¹
        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
        }
    }

    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        navMeshAgent.SetDestination(targetPosition); // Ustawiamy miejsce docelowe dla NavMeshAgent
    }
}
