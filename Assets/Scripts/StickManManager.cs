using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StickManManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("red")&& other.transform.parent.childCount >0)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        switch (other.tag)
        {
            case "red":
                if (other.transform.parent.childCount >0)
                {
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
            
                break;

            case "jump":
                transform.DOJump(transform.position, 1f, 1, 1f).SetEase(Ease.Flash).OnComplete(PlayerManager.PlayerManager›nstance.FormatStickMan);

                break;
        }

        if (other.CompareTag("stair"))
        {
            transform.parent.parent = null; // for instance tower_0
            transform.parent = null; // stickman
            GetComponent<Rigidbody>().isKinematic = GetComponent<Collider>().isTrigger = false;
            //StickManAnimator.SetBool("run", false);

            if (!PlayerManager.PlayerManager›nstance.moveTheCamera)
                PlayerManager.PlayerManager›nstance.moveTheCamera = true;

            if (PlayerManager.PlayerManager›nstance.player.transform.childCount == 2)
            {
                other.GetComponent<Renderer>().material.DOColor(new Color(0.4f, 0.98f, 0.65f), 0.5f).SetLoops(1000, LoopType.Yoyo)
                    .SetEase(Ease.Flash);
                StartCoroutine(sayac());
            }

        }

        IEnumerator sayac()
        {
            yield return new WaitForSeconds(2);
            Time.timeScale = 0;

        }
    }
}
