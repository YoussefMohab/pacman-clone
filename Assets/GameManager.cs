using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject LeftWarpNode;
    public GameObject RightWarpNode;

    public AudioSource siren;
    public AudioSource munch;
    // Start is called before the first frame update
    void Start()
    {
        siren.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectedPellet(NodeController nodecontroller)
    {
            munch.Play();
    }
}
