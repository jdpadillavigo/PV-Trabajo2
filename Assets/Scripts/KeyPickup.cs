using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Llave recogida");


            gameObject.SetActive(false); // o Destroy(gameObject);
        }
    }
}
