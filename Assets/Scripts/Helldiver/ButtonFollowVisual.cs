using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{

    [SerializeField] private Transform visualObject;
    [SerializeField] private Vector3 _localAxis;
    [SerializeField] private float _resetSpeed = 5;
    [SerializeField] private float _followAngle;

    private bool _freeze = false;

    private Vector3 _initLocalPos;

    private Vector3 _offset;
    private Transform _pokeAttachTransform;

    private XRBaseInteractable interactable;
    private bool _isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        _initLocalPos = visualObject.localPosition;
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);
    }


    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;

            _pokeAttachTransform = interactor.attachTransform;
            _offset = visualObject.position - _pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(_offset, visualObject.TransformDirection(_localAxis));

            if(pokeAngle < _followAngle) 
            {
                _isFollowing = true;
                _freeze = false;
            }
        }
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            _isFollowing = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            _freeze = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_freeze) return;
        
        if (_isFollowing)
        {
            Vector3 localTragetPos = visualObject.InverseTransformPoint(_pokeAttachTransform.position + _offset);
            Vector3 constrainedLocalTargetPos = Vector3.Project(localTragetPos, _localAxis);

            visualObject.position = visualObject.TransformPoint(constrainedLocalTargetPos);
        }
        else
        {
            visualObject.localPosition = Vector3.Lerp(visualObject.localPosition,_initLocalPos,Time.deltaTime * _resetSpeed);
        }
    }
}
