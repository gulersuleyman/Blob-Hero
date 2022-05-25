using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject canonCylinder;
    [SerializeField] ParticleSystem smokeParticle;
    [SerializeField] ParticleSystem smokeParticle2;
    [SerializeField] ParticleSystem canonParticle1;
    [SerializeField] ParticleSystem canonParticle2;
    public float _moveSpeed;


    bool bezierMove;

    JoystickRotator _rotator;
    Rigidbody _rigidbody;
    DynamicJoystick _joystick;
    AnimationController _animationcontroller;
    UIManager _uiManager;
    Bezier _bezier;
    PlayerCollision _playercollision;
    EnemySpawner _spawner;
    ShieldCollision _shield;
    CinemachineVirtualCamera _vcam;
    // Start is called before the first frame update
    void Awake()
    {
        _rotator = GetComponent<JoystickRotator>();
        _rigidbody = GetComponent<Rigidbody>();
        _joystick = FindObjectOfType<DynamicJoystick>();
        _animationcontroller = GetComponent<AnimationController>();
        _uiManager = FindObjectOfType<UIManager>();
        _bezier = FindObjectOfType<Bezier>();
        _playercollision = GetComponent<PlayerCollision>();
        _spawner = FindObjectOfType<EnemySpawner>();
        _shield = GetComponentInChildren<ShieldCollision>();
        _vcam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameManager.Instance.isDead && !GameManager.Instance.isCanon)
		{
            Vector3 direction = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
            if (direction.x > 0.1f || direction.z > 0.1f || direction.x < -0.1f || direction.z < -0.1f)
            {
                _rigidbody.isKinematic = false;
                // _rigidbody.AddForce(direction * _moveSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
                _rigidbody.velocity = direction * (_moveSpeed+_uiManager.moveSpeedIncreaser) * Time.fixedDeltaTime;
                _animationcontroller.WalkAnimation(true);
            }

            if (direction == Vector3.zero)
            {
                _animationcontroller.WalkAnimation(false);
                _rigidbody.isKinematic = true;
            }
        }
        if(GameManager.Instance.isDead)
		{
            _rigidbody.isKinematic = true;
		}
        if(GameManager.Instance.isCanon && Input.GetMouseButtonDown(0) && !bezierMove)
		{
            BezierMove();
		}
        
    }
    void BezierMove()
	{
        bezierMove = true;
        _bezier.tapText.gameObject.SetActive(false);
        transform.DOMove(new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z - 1.5f), 0.4f);
        canonCylinder.transform.DOScaleY(canonCylinder.transform.localScale.y - 1f, 0.4f).OnComplete(() =>
           {
               canonCylinder.transform.DOScaleY(canonCylinder.transform.localScale.y + 1f, 0.1f).OnComplete(() =>
               {
                   StartCoroutine(FlyBegin());
               });
           });
        
            
	}
    IEnumerator FlyBegin()
	{
        _animationcontroller.FlyAnimation(true);
        smokeParticle.Play();
        canonParticle1.Play();
        canonParticle2.Play();
        CinemachineTransposer transposer = _vcam.GetCinemachineComponent<CinemachineTransposer>();
        for (int i = 0; i < 100; i++)
        {
            transform.position = _bezier.lineRenderer.GetPosition(i);
            yield return new WaitForSeconds(0.01f);
            if(i<50)
			{
                transposer.m_FollowOffset.y += 1f;
                transposer.m_FollowOffset.z -= 0.5f;
			}
			else
			{
                transposer.m_FollowOffset.y -= 1f;
                transposer.m_FollowOffset.z += 0.5f;
            }


        }
        _animationcontroller.FlyAnimation(false);
        transform.position = new Vector3(transform.position.x, -1.7f, transform.position.z);
        smokeParticle2.Play();
        GameManager.Instance.isCanon = false;
        _rotator.Working = true;
        transform.eulerAngles = Vector3.zero;
        _playercollision.stopActiver = false;
        bezierMove = false;
        _spawner.canSpawn = true;
        _shield.canon1.gameObject.SetActive(false);
        _spawner.canonJumpIndex++;



        yield return null;
    }
    
}
