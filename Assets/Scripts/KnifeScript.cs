using System.Collections;
using UnityEngine;

public class KnifeScript : MonoBehaviour {
    private Renderer _renderer;

    private void Start() {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Dissect")) {
            HeartScript.IncreaseDissectCount();
            StartCoroutine(ChangeColorToSemiTransparentBlue(other.gameObject));
        }
    }

    private IEnumerator ChangeColorToSemiTransparentBlue(GameObject obj) {
        Renderer objRenderer = obj.GetComponent<Renderer>();

        obj.GetComponent<BoxCollider>().enabled = false;
        
        // Ensure the material is set to a shader that supports transparency
        objRenderer.material.SetFloat("_Mode", 3);  // Set to "Transparent" mode for Standard shader
        objRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        objRenderer.material.renderQueue = 3000;

        Color startColor = objRenderer.material.color;
        Color targetColor = new Color(0f, 1f, 0f, 0.5f); // Semi-transparent blue
        float duration = 1.0f; // Duration of the color change
        float elapsed = 0f;

        while (elapsed < duration) {
            objRenderer.material.color = Color.Lerp(startColor, targetColor, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objRenderer.material.color = targetColor;
        Destroy(obj, 1.0f); // Destroy object after changing color (optional delay of 1 second)
    }
}
