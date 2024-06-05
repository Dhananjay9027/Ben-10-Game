using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    [SerializeField] private GameObject[] Aliens; // List of alien objects
    private GameObject CurrentPlayer; // The current player object
    private Player movement; // Reference to the player's movement script
    [SerializeField] private CameraFocus cameraFocus; // Reference to the CameraFocus script attached to the camera
    private GameObject Ben;

    private void Start()
    {
        CurrentPlayer = gameObject; // Set the initial player object to Ben
        movement = CurrentPlayer.GetComponent<Player>();
        Ben = CurrentPlayer;
        movement.enabled = true; // Enable the movement script on the player
        cameraFocus.SetTarget(CurrentPlayer.transform); // Set initial camera target
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
                Morfh(0); // Transform to the first alien (assuming index 0)
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Morfh(1);
        }
        if(Input.GetKeyDown (KeyCode.Alpha3))
        {
            Morfh(2);
        }
       if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           Morfh(3);
        }

    }

    private void Morfh(int index)
    {
        if (index < 0 || index > Aliens.Length)
        {
            Debug.LogError("Invalid alien index");
            return;
        }

        movement.enabled = false;
        Ben.SetActive(false);

        Debug.Log(Aliens[index].ToString());
        // Set the new current player
        CurrentPlayer = Aliens[index];
        movement = CurrentPlayer.GetComponent<Player>();
        movement.enabled = true;

        // Set the position and rotation of the new character to match the player's previous position and rotation
        CurrentPlayer.transform.position = transform.position;
        CurrentPlayer.transform.rotation = transform.rotation;

        // Show the new character
        CurrentPlayer.SetActive(true);

        // Enable the Transben script on the new player
        CurrentPlayer.GetComponent<Transben>().enabled = true;

        // Update the camera's target to the new player
        cameraFocus.SetTarget(CurrentPlayer.transform);

        //disable ben 10 transformation menas this script
        Ben.GetComponent<Transformation>().enabled = false;
    }
}
