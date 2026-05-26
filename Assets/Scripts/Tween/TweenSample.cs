using UnityEngine;
using DG.Tweening;
using TMPro;

public class TweenSample : MonoBehaviour
{
    [Header("효과를 위한 UI/Object 타겟")]
    public RectTransform UITarget;
    public GameObject ObjectTarget;

    [Header("글자 연출 타겟")]
    public TMP_Text countText;
    public int currentValue = 0;
    public int addValue = 100;

    private int targetValue;

    [Header("색 변형 연출 타겟")]
    public Color flashColor = Color.yellow;

    private Color originalColor;

    [Header("페이드 UI 그룹")]
    public CanvasGroup fadeTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countText.text = currentValue.ToString();

        originalColor = countText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayPunchUIScale();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayPunchObjectSclae();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayUIShake();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayCountUp();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayColorFlash();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayFade();
        }
    }

    public void PlayPunchUIScale()
    {
        if (UITarget == null) return;
        UITarget.DOKill();
        UITarget.localScale =Vector3.one;
        UITarget.DOPunchScale(Vector3.one * 0.3f, 0.25f, 8, 1.0f);
    }

    public void PlayPunchObjectSclae()
    {
        if (UITarget == null) return;
        ObjectTarget.transform.DOKill();
        ObjectTarget.transform.localScale = Vector3.one;
        ObjectTarget.transform.DOPunchScale(Vector3.one * 0.3f, 0.25f, 8, 1.0f);
    }

    public void PlayUIShake()
    {
        if (UITarget == null) return;
        UITarget.DOKill();
        UITarget.DOShakeAnchorPos(0.3f, 20f, 20, 90f);
    }

    public void PlayCountUp()
    {
        if (countText == null) return;

        targetValue += addValue;
        DOTween.Kill("CountTween", true);

        DOTween.To(
            () => currentValue,
            value =>
            {
                currentValue = value;
                countText.text = currentValue.ToString();
            },
            targetValue,
            0.5f
        )
        .SetEase(Ease.OutQuad)
        .SetId("CountTween");
    }

    public void PlayColorFlash()
    {
        if (countText == null) return;
        countText.DOKill();
        countText.color = originalColor;

        countText.DOColor(flashColor, 0.1f)
        .OnComplete(() =>
        {
            countText.DOColor(originalColor, 0.2f);
        });
    }

    public void PlayFade()
    {
        if(fadeTarget == null) return;
        fadeTarget.DOKill();
        fadeTarget.alpha = 0f;

        Sequence seq = DOTween.Sequence();

        seq.Append(fadeTarget.DOFade(1f, 0.2f));
        seq.AppendInterval(0.5f);
        seq.Append(fadeTarget.DOFade(0f, 0.3f));
    }
}
