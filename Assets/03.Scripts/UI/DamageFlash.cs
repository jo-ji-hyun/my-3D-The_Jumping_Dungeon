using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // === image�� ����ϱ� ���� ===

public class DamageFlash : MonoBehaviour
{
    // === ��Ÿ�� �ð� ===
    public Image image;
    public float flashSpeed = 0.5f;

    // === �ڷ�ƾ ���� ===
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
            Debug.Log("condition�� Ȱ��ȭ ���� ����");
        }
    }

    // === ȭ�� ��½�� �޼��� ===
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

    // === ȭ���� ��½�� �ڷ�ƾ ===
    private IEnumerator FadeAway()
    {
        // === ȭ�� ������ ===
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
