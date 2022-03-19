using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DefandatController : MonoBehaviour
{
    public Sprite signature;
    
    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    public void Guilty(){
        _animator.SetBool("Idle",false);
        transform.DORotate(new Vector3(0,-90,0),.5f).OnComplete(() => {
            transform.DOMoveX(5,3);
            gameObject.SetActive(false);
        });
    }

    public void NonGuilty(){
        _animator.SetBool("Idle",false);
        transform.DORotate(new Vector3(0,90,0),.5f).OnComplete(() => {
            transform.DOMoveX(-5,3);
            gameObject.SetActive(false);
        });
    }

    

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Stop"))
        {
            UIManager.Instance.OpenFilesPanel(true);
            UIManager.Instance.UpdateSignature(gameObject);
            _animator.SetBool("Idle",true);
        }
    }
}
