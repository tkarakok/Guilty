
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PathCreation.Examples;

public class DefandatController : MonoBehaviour
{
    public Sprite signature;
    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    public void Guilty(){
        _animator.SetBool("Idle",false);
        gameObject.GetComponent<PathFollower>().pathCreator = GamaManager.Instance.guiltyPath;
        gameObject.GetComponent<PathFollower>().endOfPathInstruction = PathCreation.EndOfPathInstruction.Loop;
    }

    public void NonGuilty(){
        _animator.SetBool("Idle",false);
        gameObject.GetComponent<PathFollower>().pathCreator = GamaManager.Instance.nonGuiltyPath;
        gameObject.GetComponent<PathFollower>().endOfPathInstruction = PathCreation.EndOfPathInstruction.Loop;
    }

    

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Stop"))
        {   
            gameObject.layer = 6;
            UIManager.Instance.OpenFilesPanel(true);
            UIManager.Instance.UpdateSignature(gameObject);
            _animator.SetBool("Idle",true);
        }
        else if (other.CompareTag("Destroy"))
        {
            gameObject.SetActive(false);
        }
    }
}
