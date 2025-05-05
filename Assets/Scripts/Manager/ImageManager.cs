using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public static ImageManager instance;

    [System.Serializable]
    public class ImageArray
    {
        public UIState state;
        public Image[] images;
    }

    [SerializeField] private List<ImageArray> imageGroups;
    private Dictionary<UIState, Image[]> imageDict;
    private Image[] currentImages;
    private UIState currentState;

    public EventUI[] eventUIs;
    private int currentIndex;
    private bool isActive;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        imageDict = new Dictionary<UIState, Image[]>();
        if (imageGroups == null) return;
         foreach (var group in imageGroups)
        {
            imageDict[group.state] = group.images;
            foreach (var image in group.images)
            {
                if(image==null) return;
                image.gameObject.SetActive(false);
            }
        }
    }

    public void SetState(UIState _state)
    {
        currentState = _state;
    }

    public void OnViewChangeImage(InputValue value)
    {
        if (IsUIActive())
        {
            if (isActive)
                StopImagesView();
            else
            {
                StartImagesView(currentState);
            }
        }
        else
        {
            Debug.Log("event에 들어오지않음");
        }
    }

    public void StartImagesView(UIState state)
    {
        if (!imageDict.ContainsKey(state)) return;

        currentImages = imageDict[state];
        if (currentImages == null || currentImages.Length == 0) return;

        currentIndex = 0;
        isActive = true;
        foreach (var image in currentImages)
        {
            image.gameObject.SetActive(false);
        }

        currentImages[currentIndex].gameObject.SetActive(true);
    }
    
    public void NextImage()
    {
        if (!isActive || currentImages == null) return;
        currentImages[currentIndex].gameObject.SetActive(false);
        currentIndex++;

        if (currentIndex < currentImages.Length)
        {
            currentImages[currentIndex].gameObject.SetActive(true);
        }
        else
        {
            StopImagesView();
        }
    }

    public void PreviousImage()
    {
        if (!isActive || currentIndex <= 0) return;
        currentImages[currentIndex].gameObject.SetActive(false);
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = currentImages.Length - 1;
        currentImages[currentIndex].gameObject.SetActive(true);
    }

    public void StopImagesView()
    {
        isActive = false;
        if (currentImages == null) return;

        foreach (var image in currentImages)
        {
            if (image != null)
            {
                image.gameObject.SetActive(false);
            }
        }
    }

    private bool IsUIActive()
    {
        foreach (var ui in eventUIs)
        {
            if (ui != null && ui.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }


    void OnNext(InputValue value)
    {
        Debug.Log("이미지 다음");
        if (isActive)
            NextImage();
    }

    void OnPrevious(InputValue value)
    {
        Debug.Log("이미지 이전");
        if (isActive)
            PreviousImage();
    }
}