using TMPro;
using UnityEngine;

public class UI<T, K> : MonoBehaviour where T : Spawner<K> where K : MonoBehaviour 
{
    [SerializeField] private T _spawner;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private TextMeshProUGUI _activeText;

    private void OnEnable()
    {
        _spawner.Spawn += ChangeCountText;
        _spawner.ChangeActiveObject += ChangeActiveText;
    }

    private void OnDisable()
    {
        _spawner.Spawn -= ChangeCountText;
        _spawner.ChangeActiveObject -= ChangeActiveText;
    }

    protected void ChangeCountText(int number)
    {
        _countText.text = number.ToString();
    }

    protected void ChangeActiveText(int number)
    {
        _activeText.text = number.ToString();
    }
}