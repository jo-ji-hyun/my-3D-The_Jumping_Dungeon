using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // === image를 사용하기 위해 ===

public class DamageFlash : MonoBehaviour
{
    // === 나타낼 시간 ===
    public Image image;
    public float flashSpeed = 0.5f;

    // === 코루틴 설정 ===
    private Coroutine _coroutine;

    void Start()
    {
        if (GameManager.Instance.PlayerManager.Player.condition != null)
        {
            GameManager.Instance.PlayerManager.Player.condition.OnTakeDamage += Flash;
        }

    }
    private void Update()
    {
        if (GameManager.Instance.PlayerManager.Player.condition != null)
        {
            GameManager.Instance.PlayerManager.Player.condition.OnTakeDamage += Flash;
        }
        else
        {
            Debug.Log("condition이 활성화 되지 않음");
        }
    }

    // === 화면 번쩍임 메서드 ===
    void Flash()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        image.enabled = true;
        image.color = new Color(1f, 100 / 255f, 100 / 255f);
        _coroutine = StartCoroutine(FadeAway());
    }

    // === 화면을 번쩍일 코루틴 ===
    private IEnumerator FadeAway()
    {
        // === 화면 불투명도 ===
        float startAlpa = 0.5f;
        float a = startAlpa;

        while (a > 0)
        {
            a -= (startAlpa / flashSpeed) * Time.deltaTime;
            image.color = new Color(1f, 100 / 255f, 100 / 255f, a);
            yield return null;
        }

        image.enabled = false;
    }
}
