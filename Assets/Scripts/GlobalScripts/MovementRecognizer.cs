using System.Collections.Generic;
using PDollarGestureRecognizer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementRecognizer : MonoBehaviour
{
    [SerializeField]
    private bool _creationMode;
    [SerializeField]
    private string _newGestureName;
    [SerializeField]
    private XRNode _inputSource;
    [SerializeField]
    private InputHelpers.Button _inputButton;
    [SerializeField]
    private Transform _movementSource;
    [SerializeField]
    private float _recognizeThreshold;
    [SerializeField]
    private float _inputThreshold;
    [SerializeField]
    private float _movementThresholdDistance;
    [SerializeField]
    private ParticleSystem _drawParticle;
    [SerializeField]
    private UnityEvent<string> _onRecognized;
    private bool _isMoving;
    private readonly List<Vector3> _positions = new List<Vector3>();
    private readonly List<Gesture> _trainingSet = new List<Gesture>();

    private void Start()
    {
        _isMoving = false;
        var gestureFiles = Resources.LoadAll<TextAsset>("MovementRecognizeResources");
        foreach (var gestureFile in gestureFiles) _trainingSet.Add(GestureIO.ReadGestureFromXML(gestureFile.ToString()));
    }
    
    private void Update()
    {
        InputDevices.GetDeviceAtXRNode(_inputSource).IsPressed(_inputButton,out bool isPressed ,_inputThreshold);
        if (isPressed)
        {
            if (_isMoving) UpdateMovement();
            else StartMovement();
        }
        else if (_isMoving)
        {
            EndMovement();
        }
    }

    private void StartMovement()
    {
        _isMoving = true;
        _positions.Clear();
        _positions.Add(_movementSource.position);
    }
    
    private void UpdateMovement()
    {
        Vector3 movementSourcePosition = _movementSource.position;
        if (!(Vector3.Distance(movementSourcePosition, _positions[^1]) > _movementThresholdDistance)) return;
        _positions.Add(movementSourcePosition);
        Instantiate(_drawParticle,movementSourcePosition,Quaternion.identity);
    }
   
    private void EndMovement()
    {
        _isMoving = false;
        if (_positions.Count < 1) return;
        Point[] points = PositionsToScreenPoints();
        Gesture newGesture = new Gesture(points);
        if (_creationMode) WriteNewGestureToFile(newGesture, points);
        else RecognizeMovement(newGesture);
    }

    private Point[] PositionsToScreenPoints()
    {
        int positionsCount = _positions.Count;
        Point[] points = new Point[positionsCount];
        for (int i = 0; i < positionsCount; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(_positions[i]);
            points[i] = new Point(screenPoint.x, screenPoint.y, 0);
        }
        return points;
    }
    
    private void WriteNewGestureToFile(Gesture gesture, Point[] points)
    {
        gesture.Name = _newGestureName;
        _trainingSet.Add(gesture);
        string fileName = Application.persistentDataPath + "/" + _newGestureName + ".xml";
        GestureIO.WriteGesture(points, _newGestureName, fileName);
    }
    
    private void RecognizeMovement(Gesture gesture)
    {
        Result result = PointCloudRecognizer.Classify(gesture, _trainingSet.ToArray());
        if (result.Score <  _recognizeThreshold) return;
        _onRecognized.Invoke(result.GestureClass);
        print(result.GestureClass + " - " + result.Score);
    }
}
