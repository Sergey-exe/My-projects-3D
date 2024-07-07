using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour 
{
    [SerializeField] private CubeDesigner _cubeDesigner;

    public event UnityAction<Cube> IsCollision;
    private bool _isCollision = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isCollision == false)
        {
            if (other.GetComponent<Floor>())
            {
                _isCollision = true;
                _cubeDesigner.ChangeColor();
                IsCollision?.Invoke(this);
            }
        }
    }

    public void ResetCube()
    {
        _isCollision = false;
        _cubeDesigner.ResetMaterial();
    }
}
