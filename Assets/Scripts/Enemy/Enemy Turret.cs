using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    public float projectileFireRate;
    float timeSinceLastFire;
    Shoot shootScript;

    public object OnProjectileSpawned { get; private set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();   //WHY?!!!!!  I can't find a reason for the inability to access the variables in a private class of the same type with override ANYWHERE.  Absolute baloney.
                          //misery update.  AddListener stopped working after the fix.
                          //something changed the shootScript unityEvent to unityEventQue and I'm very upset, but it's mostly fixed now
                          //HuZZAH  which is code for I hate my dyslexia but I'm glad the thing is fixed now

        shootScript = GetComponent<Shoot>();
        shootScript.OnProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
    }

    private void OnDisable()
    {
        shootScript.OnProjectileSpawned.RemoveListener(UpdateTimeSinceLastFire);  //I'm leaving this here
    }

    //it's like trying to out-logic an idiot...  even your solution isn't working for me.. I updated, restarted, idk.


    /*public override void Death()
    {
        base.Death();
    }*/

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] currentClips = anim.GetCurrentAnimatorClipInfo(0);

        if (currentClips[0].clip.name != "Fire")
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetTrigger("fire");
            }
        }
    }

    void UpdateTimeSinceLastFire()
    {
        timeSinceLastFire = Time.time;
    }
}
