using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Updater : MonoBehaviour
{
    
    [SerializeField] protected List<Material> materials;

    private int currentSong;

    // Use this for initialization
    void Start()
    {
        Assert.IsTrue(materials.Count == 1 * Listener.possibleSongTypes);

        AssignTexture();

        currentSong = Listener.currentSong;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSong != Listener.currentSong)
        {
            AssignTexture();
            currentSong = Listener.currentSong;
        }
    }

    protected void AssignTexture()
    {
        GetComponent<Renderer>().material = materials[Listener.currentSong];
    }
}
