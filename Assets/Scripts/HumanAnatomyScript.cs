using System.Collections;
using UnityEngine;

public class HumanAnatomyScript : MonoBehaviour
{
    public GameObject brainPartGoUp;
    public GameObject brainPartGoLeft;
    public GameObject brainPartGoRight;

    private Vector3 _initialPositionGoUp;
    private Vector3 _initialPositionGoLeft;
    private Vector3 _initialPositionGoRight;

    public float moveDuration = 2f; // Time it takes to move

    private void Start()
    {
        // Store the initial local positions of the brain parts
        _initialPositionGoUp = brainPartGoUp.transform.localPosition;
        _initialPositionGoLeft = brainPartGoLeft.transform.localPosition;
        _initialPositionGoRight = brainPartGoRight.transform.localPosition;
    }

    public void ExpandBrain()
    {
        StartCoroutine(MoveObject(brainPartGoUp, _initialPositionGoUp + Vector3.up * 20));
        StartCoroutine(MoveObject(brainPartGoLeft, _initialPositionGoLeft + Vector3.left * 20));
        StartCoroutine(MoveObject(brainPartGoRight, _initialPositionGoRight + Vector3.right * 20));
    }

    public void CloseBrain()
    {
        StartCoroutine(MoveObject(brainPartGoUp, _initialPositionGoUp));
        StartCoroutine(MoveObject(brainPartGoLeft, _initialPositionGoLeft));
        StartCoroutine(MoveObject(brainPartGoRight, _initialPositionGoRight));
    }

    private IEnumerator MoveObject(GameObject obj, Vector3 targetPosition)
    {
        Vector3 startPosition = obj.transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            obj.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.localPosition = targetPosition; // Ensure final position is exact
    }
}