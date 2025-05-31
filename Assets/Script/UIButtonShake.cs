using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class UIButtonShake : MonoBehaviour
{
    public float shakeAmount = 5f;     // Titreþim mesafesi (px)
    public float shakeDuration = 0.2f; // Toplam süre

    private UIDocument uiDoc;

    private void OnEnable()
    {
        uiDoc = GetComponent<UIDocument>();
        if (uiDoc == null) return;

        var root = uiDoc.rootVisualElement;
        var buttons = root.Query<Button>().ToList();

        foreach (var button in buttons)
        {
            button.RegisterCallback<PointerEnterEvent>(evt =>
            {
                StartCoroutine(ShakeButton(button));
            });
        }
    }

    private IEnumerator ShakeButton(VisualElement button)
    {
        Vector3 originalPos = button.transform.position;

        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float offsetX = Random.Range(-shakeAmount, shakeAmount);
            button.transform.position = originalPos + new Vector3(offsetX, 0f, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        button.transform.position = originalPos; // Eski haline döndür
    }
}
