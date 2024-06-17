using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;

    float widthMultiplier = 0.0005f;
    float heightMultiplier = 0.01f;

    [SerializeField] Renderer _renderer;
    [SerializeField] Transform topSpine;
    [SerializeField] Transform bottomSpine;

    [SerializeField] Transform _collider;

    [SerializeField] AudioSource increaseSound;
    private void Start()
    {
        SetWidth(Progress.Instance.Width);
        SetHeight(Progress.Instance.Height);
    }

    public void AddWidth(int value)
    {
        width += value;
        UpdateWidth();
        if(value > 0)
        {
            increaseSound.Play();
        }
    }

    public void AddHeight(int value) 
    { 
        height += value;
        UpdateHeight();
        if (value > 0)
        {
            increaseSound.Play();
        }
    }

    public void SetWidth(int value) 
    { 
        width = value;
        UpdateWidth();
    }

    public void SetHeight(int value)
    {
        height = value;
        UpdateHeight();
    }

    public void HitBarrier()
    {
        if (height > 0)
        {
            height -= 50;
            UpdateHeight();
        }
        else if (width > 0)
        {
            width -= 50;
            UpdateWidth() ;
        }
        else
        {
            Die();
        }
    }
    void UpdateWidth()
    {
        _renderer.material.SetFloat("_PushValue", width * widthMultiplier);
    }
    void UpdateHeight()
    {
        float offsetY = height * heightMultiplier + 0.17f;
        topSpine.position = bottomSpine.position + new Vector3(0, offsetY, 0);
        _collider.localScale = new Vector3(1, 1.84f + height * heightMultiplier, 1);
    }

    void Die()
    {
        FindObjectOfType<GameManager>().ShowFinishWindow();
        Destroy(gameObject);
    }
}
