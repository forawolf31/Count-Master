using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text TapToPlay;
    [SerializeField] private GameObject Hand;

    void Start()
    {
        TapToPlay.transform.DOScale(1.1f, 1.2f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutFlash);
        Hand.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-250f, -550f), 1f).SetLoops(100000, LoopType.Yoyo).SetEase(Ease.InOutFlash);
    }

}
