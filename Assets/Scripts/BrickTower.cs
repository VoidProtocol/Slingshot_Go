using UnityEngine;

public class BrickTower : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GameObject _brick;

    [Header("Config")]
    [SerializeField] private float _xAxisBrickAmount;
    [SerializeField] private float _yAxisBrickAmount;
    [SerializeField] private float _zAxisBrickAmount;

    [SerializeField] private float _brickOffset;

    private Renderer _brickRenderer;
    private Vector3 _brickSize;

    private void Start()
    {
        if (_brick.TryGetComponent(out _brickRenderer))
        {
            _brickSize = new Vector3(_brickRenderer.bounds.size.x + _brickOffset, _brickRenderer.bounds.size.y + _brickOffset, _brickRenderer.bounds.size.z + _brickOffset);
            Debug.Log(_brickSize);
        }

        GenerateBrickTower();
    }

    private void GenerateBrickTower()
    {
        float xAxisTowerLength= _brickSize.x * _xAxisBrickAmount / 2.0f;
        float zAxisTowerLength = _brickSize.z * _zAxisBrickAmount / 2.0f;

        float xAxisCurrentBrickPosition = xAxisTowerLength;
        float yAxisCurrentBrickPosition = _brickSize.y / 2.0f;
        float zAxisCurrentBrickPosition = zAxisTowerLength;

        for (int i = 0; i < _yAxisBrickAmount; i++)
        {
            for (int j = 0; j < _xAxisBrickAmount; j++)
            {
                for (int k = 0; k < _zAxisBrickAmount; k++)
                {
                    Instantiate(_brick, new Vector3(xAxisCurrentBrickPosition + transform.position.x, yAxisCurrentBrickPosition + transform.position.y, 
                        zAxisCurrentBrickPosition + transform.position.z), Quaternion.identity, transform);
                    zAxisCurrentBrickPosition -= _brickSize.z;
                }

                zAxisCurrentBrickPosition = zAxisTowerLength;
                xAxisCurrentBrickPosition -= _brickSize.x;
            }

            xAxisCurrentBrickPosition = xAxisTowerLength;
            yAxisCurrentBrickPosition += _brickSize.y;
        }
    }
}
