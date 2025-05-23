using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCotroller : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private Transform _playerTransform;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.destination = _playerTransform.position;
    }
}
