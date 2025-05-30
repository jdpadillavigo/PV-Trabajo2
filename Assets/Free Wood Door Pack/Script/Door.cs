using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


public class Door : MonoBehaviour {
	public bool open;
	public float smooth = 1.0f;
	float DoorOpenAngle = -90.0f;
    float DoorCloseAngle = 0.0f;
	public AudioSource asource;
	public AudioClip openDoor,closeDoor;
	public bool playerInRange = false; // detecta si el jugador está cerca
	// Use this for initialization
	void Start()
    {
        asource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Detecta la tecla E
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }

        Quaternion targetRotation = open ?
            Quaternion.Euler(0, DoorOpenAngle, 0) :
            Quaternion.Euler(0, DoorCloseAngle, 0);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * 5 * smooth);
    }

    public void OpenDoor()
    {
        open = !open;
        asource.clip = open ? openDoor : closeDoor;
        asource.Play();
    }

    // Detecta si el jugador está dentro del área de la puerta
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
}