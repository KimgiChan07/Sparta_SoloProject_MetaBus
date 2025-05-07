using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpTrigger : MonoBehaviour
{
    [SerializeField] GameObject PressF_Image;
    [SerializeField] ParticleSystem Warp_Particle;

    [Header("Warp TargetName")]
    [SerializeField] private string warpName;
    private string playerTag="Player";
    private bool isPlayerInside = false;

    private void Awake()
    {
        PressF_Image= transform.Find("PressF").gameObject;
        Warp_Particle=  transform.Find("WarpParticle").gameObject.GetComponent<ParticleSystem>();
        PressF_Image.SetActive(false);
        Warp_Particle.Stop();
    }

    private void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.F))
        {
            if(WarpManager.Instance == null)return;
            
            WarpManager.Instance.WarpPlayer(warpName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;
        Warp_Particle.Play();
        PressF_Image.SetActive(true);
        isPlayerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;
        Warp_Particle.Stop();
        PressF_Image.SetActive(false);
        isPlayerInside = false;
    }
}
