using TMPro;
using UnityEngine;

public class UI<T> : MonoBehaviour where T : Spawner
{
    [SerializeField] private T _spawner;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private TextMeshProUGUI _activeText;

    private void OnEnable()
    {
        _spawner.Spawn += ChangeCountText;
        _spawner.Release += ChangeActiveText;
    }

    private void OnDisable()
    {
        _spawner.Spawn -= ChangeCountText;
        _spawner.Release -= ChangeActiveText;
    }

    protected void ChangeCountText(int number)
    {
        _countText.text = number.ToString();
    }

    protected void ChangeActiveText(int number)
    {
        _countText.text = number.ToString();
    }
}

public class CubeSpawnerUI : UI<CubeSpawner>
{

}

public class BombSpawnerUI : UI<BombSpawner>
{

}