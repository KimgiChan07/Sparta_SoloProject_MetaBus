using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheStack : MonoBehaviour
{
    private const float BoundSize = 3.5f;
    private const float MovingBoundsSize = 3f;
    private const float StackMovingSpeed = 5.0f;
    private const float BlockMovingSpeed = 3.5f;
    private const float ErrorMargin = 0.1f;

    public GameObject originBlock = null;

    private Vector3 prevBlockPos;
    private Vector3 desiredPos;
    private Vector3 stackBounds = new Vector3(BoundSize, BoundSize);

    private Transform lastBlock = null;

    private float blockTransition = 0f;
    private float secondaryPos = 0f;

    private int stackCount = -1;

    public int Score
    {
        get { return stackCount; }
    }

    private int comboCount = 0;

    public int Combo
    {
        get { return comboCount; }
    }

    private int maxCombo = 0;

    public int MaxCombo
    {
        get => maxCombo;
    }

    private int maxScore = 0;

    public int MaxScore
    {
        get => maxScore;
    }

    public Color prevColor;
    public Color nextColor;

    int bestScore = 0;

    public int BestScore
    {
        get => bestScore;
    }

    int bestCombo = 0;

    public int BestCombo
    {
        get => bestCombo;
    }

    private const string BestScoreKey = "BestScore";
    private const string BestComboKey = "BestComboKey";

    private bool isGameOver = true;

    private bool isMoingX = true;

    void Start()
    {
        if (originBlock == null)
        {
            return;
        }

        if (MiniGameManager.Instance != null)
        {
            bestScore = MiniGameManager.Instance.GetBestScore("TheStack");
        }
        else
        {
            bestScore = 0;
        }

        bestCombo = PlayerPrefs.GetInt(BestComboKey, 0);

        prevColor = GetRandomColor();
        nextColor = GetRandomColor();

        prevBlockPos = Vector3.down;
        SpawnBlock();
        SpawnBlock();
    }

    void Update()
    {
        if (isGameOver) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (PlaceBlock())
                SpawnBlock();
            else
            {
                UpdateScore();
                isGameOver = true;
                GameOverEffect();
                The_UIManager.Instance.SetScoreUI();
            }
        }

        MoveBlock();

        transform.position = Vector3.Lerp(transform.position, desiredPos, StackMovingSpeed * Time.deltaTime);
    }

    bool SpawnBlock()
    {
        if (lastBlock != null)
        {
            prevBlockPos = lastBlock.localPosition;
        }

        GameObject newBlock = null;
        Transform newTrans = null;
        newBlock = Instantiate(originBlock);
        if (newBlock == null)
            return false;

        ColorChange(newBlock);

        newTrans = newBlock.transform;
        newTrans.parent = this.transform;
        newTrans.localPosition = prevBlockPos + Vector3.up;
        newTrans.localRotation = Quaternion.identity;
        newTrans.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

        stackCount++;

        desiredPos = Vector3.down * stackCount;
        blockTransition = 0f;
        lastBlock = newTrans;

        isMoingX = !isMoingX;
        The_UIManager.Instance.UpdateScore();
        return true;
    }

    Color GetRandomColor()
    {
        float r = Random.Range(100f, 250f) / 255f;
        float g = Random.Range(100f, 250f) / 255f;
        float b = Random.Range(100f, 250f) / 255f;
        return new Color(r, g, b);
    }

    void ColorChange(GameObject go)
    {
        Color applyColor = Color.Lerp(prevColor, nextColor, (stackCount % 11) / 10f);

        Renderer rn = go.GetComponent<Renderer>();

        if (rn == null)
        {
            return;
        }

        rn.material.color = applyColor;
        Camera.main.backgroundColor = applyColor - new Color(0.1f, 0.1f, 0.1f);

        if (applyColor.Equals(nextColor) == true)
        {
            prevColor = nextColor;
            nextColor = GetRandomColor();
        }
    }

    void MoveBlock()
    {
        blockTransition += Time.deltaTime * BlockMovingSpeed;

        float movePos = Mathf.PingPong(blockTransition, MovingBoundsSize) - BoundSize / 2;

        if (isMoingX)
        {
            lastBlock.localPosition = new Vector3(MovingBoundsSize * movePos, stackCount, secondaryPos);
        }
        else
        {
            lastBlock.localPosition = new Vector3(secondaryPos, stackCount, MovingBoundsSize * -movePos);
        }
    }

    bool PlaceBlock()
    {
        Vector3 lastPos = lastBlock.localPosition;

        if (isMoingX)
        {
            float deltaX = prevBlockPos.x - lastPos.x;

            bool isNegativeNum = (deltaX < 0) ? true : false;

            deltaX = Mathf.Abs(deltaX);
            if (deltaX > ErrorMargin)
            {
                stackBounds.x -= deltaX;
                if (stackBounds.x <= 0)
                {
                    return false;
                }

                float middle = (prevBlockPos.x + lastPos.x) / 2;
                lastBlock.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

                Vector3 tempPos = lastBlock.localPosition;
                tempPos.x = middle;
                lastBlock.localPosition = lastPos = tempPos;

                float rubbleHalfScale = deltaX / 2;
                CreateRubble(
                    new Vector3(
                        isNegativeNum
                            ? lastPos.x + stackBounds.x / 2 + rubbleHalfScale
                            : lastPos.x - stackBounds.x / 2 - rubbleHalfScale, lastPos.y, lastPos.z),
                    new Vector3(deltaX, 1, stackBounds.y)
                );
                comboCount = 0;
            }
            else
            {
                ComboCheck();
                lastBlock.localPosition = prevBlockPos + Vector3.up;
            }
        }
        else
        {
            float deltaZ = prevBlockPos.z - lastPos.z;

            bool isNegativeNum = (deltaZ < 0) ? true : false;
            deltaZ = Mathf.Abs(deltaZ);
            if (deltaZ > ErrorMargin)
            {
                stackBounds.y -= deltaZ;
                if (stackBounds.y <= 0)
                {
                    return false;
                }

                float middle = (prevBlockPos.z - lastPos.z) / 2;
                lastBlock.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

                Vector3 tempPos = lastBlock.localPosition;
                tempPos.z = middle;
                lastBlock.localPosition = lastPos = tempPos;

                float rubbleHalfScale = deltaZ / 2;
                CreateRubble(
                    new Vector3(lastPos.x, lastPos.y,
                        isNegativeNum
                            ? lastPos.z + stackBounds.y / 2 + rubbleHalfScale
                            : lastPos.z - stackBounds.y / 2 - rubbleHalfScale),
                    new Vector3(stackBounds.x, 1, deltaZ)
                );
                comboCount = 0;
            }
            else
            {
                ComboCheck();
                lastBlock.localPosition = prevBlockPos + Vector3.up;
            }
        }

        secondaryPos = (isMoingX) ? lastBlock.localPosition.x : lastBlock.localPosition.z;

        return true;
    }

    void CreateRubble(Vector3 pos, Vector3 scale)
    {
        GameObject go = Instantiate(lastBlock.gameObject);
        go.transform.parent = this.transform;

        go.transform.localPosition = pos;
        go.transform.localScale = scale;
        go.transform.localRotation = Quaternion.identity;

        go.AddComponent<Rigidbody>();
        go.name = "Rubble";
    }

    void ComboCheck()
    {
        comboCount++;
        if (comboCount > maxCombo)
            maxCombo = comboCount;

        if ((comboCount % 5) == 0)
        {
            stackBounds += new Vector3(0.5f, 0.5f);
            stackBounds.x = (stackBounds.x > BoundSize) ? BoundSize : stackBounds.x;
            stackBounds.y = (stackBounds.y > BoundSize) ? BoundSize : stackBounds.y;
        }
    }

    void UpdateScore()
    {
        if (bestScore < stackCount)
        {
            bestScore = stackCount;
            bestCombo = maxCombo;
            
            MiniGameManager.Instance.UpdateScore("TheStack", bestScore);
            PlayerPrefs.SetInt(BestComboKey, bestCombo);
        }
    }

    void GameOverEffect()
    {
        int childCount = this.transform.childCount;

        for (int i = 1; i < 20; i++)
        {
            if (childCount < i)
                break;
            GameObject go = transform.GetChild(childCount - i).gameObject;
            if (go.name.Equals("Rubble"))
                continue;
            Rigidbody rig = go.AddComponent<Rigidbody>();

            rig.AddForce((Vector3.up * Random.Range(0f, 10f) + Vector3.right * (Random.Range(0, 10f) - 5f)) * 100f);
        }
    }

    public void ReStart()
    {
        int childCount = this.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        isGameOver = false;
        lastBlock = null;
        desiredPos = Vector3.zero;
        stackBounds = new Vector3(BoundSize, BoundSize);

        stackCount = -1;
        isMoingX = true;
        blockTransition = 0f;

        comboCount = 0;
        maxCombo = 0;
        prevBlockPos = Vector3.down;

        prevColor = GetRandomColor();
        nextColor = GetRandomColor();

        SpawnBlock();
        SpawnBlock();
    }
}