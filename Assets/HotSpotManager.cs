using UnityEngine;

public class HotspotManager : MonoBehaviour
{
    public Transform[] hotspots; // Array to hold the hotspots
    public Transform playerCamera; // Reference to the main camera (or camera rig)
    private int currentHotspotIndex = 0;

    void Start()
    {
        // Set the initial position and rotation to the first hotspot
        MoveToHotspot(currentHotspotIndex);
    }

    void Update()
    {
        // Check for input to switch hotspots
        if (OVRInput.GetDown(OVRInput.Button.One)) // Using OVRInput.Button.One directly
        {
            SwitchHotspot();
        }
    }

    void SwitchHotspot()
    {
        currentHotspotIndex++;
        if (currentHotspotIndex >= hotspots.Length)
        {
            currentHotspotIndex = 0;
        }
        MoveToHotspot(currentHotspotIndex);
    }

    void MoveToHotspot(int index)
    {
        playerCamera.position = hotspots[index].position;
        playerCamera.rotation = hotspots[index].rotation;
    }
}
