using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class HeartScript : MonoBehaviour  {
    public static int _dissectCount;

    public GameObject veins1;
    public GameObject veins2;
    public GameObject point8Outside;
    public GameObject point9Outside;
    public GameObject objectToMove;
    
    public AudioManagerScript audioManager;

    private float _sizeChangeRate = 0.8f;

    public static void ResetDissectCount() {
        _dissectCount = 0;
    }

    public static void IncreaseDissectCount() {
        _dissectCount++;
    }

    void Update() {
        Debug.Log(_dissectCount);
        if (_dissectCount >= 35) {
            veins1.SetActive(false);
            veins2.SetActive(false);
            point8Outside.SetActive(false);
            point9Outside.SetActive(false);
            _dissectCount++;
            audioManager.SetClip4();
            Destroy(objectToMove);
        }
    }

    public void IncreaseSizeHeart() {
        Vector3 newScale = new Vector3(
            gameObject.transform.localScale.x + _sizeChangeRate,
            gameObject.transform.localScale.y + _sizeChangeRate,
            gameObject.transform.localScale.z + _sizeChangeRate
        );

        StartCoroutine(SmoothScaleDown(gameObject, newScale, 1f));
    }

    public void DecreaseSizeHeart() {
        Vector3 newScale = new Vector3(
            gameObject.transform.localScale.x - _sizeChangeRate,
            gameObject.transform.localScale.y - _sizeChangeRate,
            gameObject.transform.localScale.z - _sizeChangeRate
        );

        StartCoroutine(SmoothScaleDown(gameObject, newScale, 1f));
    }
    
    public IEnumerator SmoothScaleDown(GameObject obj, Vector3 targetScale, float duration) {
        Vector3 initialScale = obj.transform.localScale;
        float elapsedTime = 0;

        while (elapsedTime < duration) {
            // Interpolate between initial and target scales
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final scale is set to the target scale
        obj.transform.localScale = targetScale;
    }
    
}
