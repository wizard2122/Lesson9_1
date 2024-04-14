using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sherif : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    private IMover _mover;

    public float Speed => _speed;

    public Transform Transform => transform;


    private void Update()
    {
        _mover.Update();
    }

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }
}
