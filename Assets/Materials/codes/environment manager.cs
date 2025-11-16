using UnityEngine;
using TMPro; // Per testo 3D (TextMeshPro)

public class EnvironmentManager : MonoBehaviour
{
    [System.Serializable]
    public class EnvironmentOption
    {
        public string environmentName;
        public Material skyboxMaterial;
    }

    [Header("Lista ambienti disponibili")]
    public EnvironmentOption[] environments;

    [Header("Riferimento al testo dell'interfaccia")]
    public TextMeshProUGUI environmentLabel;

    private int currentIndex = 0;

    void Start()
    {
        if (environments.Length > 0)
            ApplyEnvironment(0);
    }

    public void NextEnvironment()
    {
        currentIndex = (currentIndex + 1) % environments.Length;
        ApplyEnvironment(currentIndex);
    }

    public void PreviousEnvironment()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = environments.Length - 1;
        ApplyEnvironment(currentIndex);
    }

    private void ApplyEnvironment(int index)
    {
        RenderSettings.skybox = environments[index].skyboxMaterial;
        DynamicGI.UpdateEnvironment();

        if (environmentLabel != null)
            environmentLabel.text = environments[index].environmentName;
    }
}