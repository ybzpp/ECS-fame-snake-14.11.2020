using UnityEngine;
using Leopotam.Ecs;

public class Apple : MonoBehaviour
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
