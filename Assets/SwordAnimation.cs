using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Fighter : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;

 private bool hit1Played = false;
private bool hit2Played = false;
private bool hit3Played = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
 
         if (anim.GetCurrentAnimatorStateInfo(0).IsName("hit1")) {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && !hit1Played) {
            anim.SetBool("hit1", false);
            hit1Played = true;
        }
    } else {
        hit1Played = false;
    }



                if (anim.GetCurrentAnimatorStateInfo(0).IsName("hit2")) {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && !hit2Played) {
            anim.SetBool("hit2", false);
            hit2Played = true;
        }
    } else {
        hit2Played = false;
    }



                if (anim.GetCurrentAnimatorStateInfo(0).IsName("hit3")) {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && !hit3Played) {
            anim.SetBool("hit3", false);
            hit3Played = true;
        }
    } else {
        hit3Played = false;
    }
 
 
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
 
        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                OnClickk();
 
            }
        }
    }
 
    void OnClickk() {
    if (Time.time - lastClickedTime > maxComboDelay) {
        noOfClicks = 0;
    }

    lastClickedTime = Time.time;
    noOfClicks++;
        if (noOfClicks == 1)
        {
            anim.SetBool("hit1", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
 
        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", true);
        }
        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            anim.SetBool("hit2", false);
            anim.SetBool("hit3", true);
        }
    }
}