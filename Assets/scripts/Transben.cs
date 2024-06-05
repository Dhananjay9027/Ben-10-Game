using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Transben : MonoBehaviour
{
    [SerializeField] private GameObject ben; // Reference to the Ben object
    private GameObject CurrentPlayer; // The current player object
    private Player movement; // Reference to the player's movement script
    [SerializeField] private CameraFocus cameraFocus; // Reference to the CameraFocus script attached to the camera
    private GameObject Man;

    private void Start()
    {
        CurrentPlayer = gameObject;
        Man=CurrentPlayer;
        movement = CurrentPlayer.GetComponent<Player>();
        movement.enabled = true;
        cameraFocus.SetTarget(CurrentPlayer.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TransformBackToBen();
        }
    }

    private void TransformBackToBen()
    {
        // Disable current player's movement script and hide the current player
        movement.enabled = false;
        Man.SetActive(false);

        // Set the current player back to Ben
        CurrentPlayer = ben;
        movement = CurrentPlayer.GetComponent<Player>();
        movement.enabled = true;

        // Set the position and rotation of Ben to match the previous player's position and rotation
        CurrentPlayer.transform.position = transform.position;
        CurrentPlayer.transform.rotation = transform.rotation;

        // Show Ben
        CurrentPlayer.SetActive(true);

        // Enable the Transformation script on Ben
        CurrentPlayer.GetComponent<Transformation>().enabled = true;

        // Update the camera's target to Ben
        cameraFocus.SetTarget(CurrentPlayer.transform);

        // disable man script(Alein)
        Man.GetComponent<Transben>().enabled = false;
    }
}
