using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenUIManager : MonoBehaviour {
    
    public GameObject mainFrame;
    public GameObject informationFrame;
    public GameObject heartMainModel;
    
    public TextMeshProUGUI heartText;

    public string[] heartInformation = new string[21];
    

    public void StartHeartModel() {
        mainFrame.SetActive(false);
        heartMainModel.SetActive(true);
        informationFrame.SetActive(true);
    }

    public void HeartInformationShow(int val) {
        heartText.text = heartInformation[val - 1];
    }
}
