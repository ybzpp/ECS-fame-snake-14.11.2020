using UnityEngine;
using Leopotam.Ecs;

public class Food : MonoBehaviour
{
    public Collider Collider;
    public bool isTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            isTrigger = true;
        }
    }
}
