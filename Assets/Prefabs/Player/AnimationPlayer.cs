using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play("Run");
    }

    private void Update()
    {
        if (anim.isPlaying == false)
        {
            anim.Play("Run");
        }
    }

    public void Jump() {
        anim.Play("Jump");
    }
}
