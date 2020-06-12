using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
    public GameObject block;
    [HideInInspector]
    public bool redraw = false;
    public Sprite BlockSprite;
    public Sprite DefaultSprite;
    public GameObject Desk;

    private LineRenderer lineRenderer;
    private float maxLength = 30000;
    private Ray ray;
    private Vector3 direction;
    private bool draw;
    private Vector2 currentPosition = Vector2.zero;
    private int LayerMask;
    private int[] WinArray = new int[3];
    private Animator DeskAnim;
    private Canvas canvas;
    
    bool CheckRange(float min, float max, float number)
    {
        return number >= min && number <= max;
    }
    private void Awake()
    {
        LayerMask = 1 << 8;
        lineRenderer = GetComponent<LineRenderer>();
        draw = true;
        DeskAnim = Desk.GetComponent<Animator>();
    }

    void CreateInitialPoint()
    {
        ray = new Ray(transform.position, transform.right);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        draw = true;
    }
    
    bool CalculateWinValue()
    {
        bool win = false;
        RaycastHit DotHit;
        if(Physics.Raycast(ray, out DotHit, maxLength))
        {
            if(DotHit.collider.name == "Dot")
            {
                WinArray[0] = 1;
            }
            if(DotHit.collider.name == "Dot1")
            {
                WinArray[1] = 1;
            }
            if (DotHit.collider.name == "Dot2")
            {
                WinArray[2] = 1;
            }
           
        }
       
        if(WinArray[0] == 1 && WinArray[1] == 1 && WinArray[2] == 1)
        {
            win = true;
        }
        return win;
    }
    void DrawLaser()
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxLength, 1 << 12))
        {
            CalculateWinValue();
            if (hit.collider.tag == "border" || hit.collider.name == "Origin")
            {
                draw = false;
            }
            else
            {
                draw = true;
            }
           
            if (draw || CheckRange(1, 15, lineRenderer.positionCount))
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
            }
           
            if (draw && CheckRange(1, 15, lineRenderer.positionCount))
            {
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
            }
           
        }

    }
    void ReDrawLaser()
    {
        WinArray = new int[3];
        lineRenderer.positionCount = 0;
        CreateInitialPoint();
    }

    public void OnClickImage(GameObject Block)
    {
        Image img = Block.GetComponent<Image>();
        ClickableImage clickable = Block.GetComponent<ClickableImage>();
        clickable.Default = !clickable.Default;
        if (clickable.Default)
            img.sprite = DefaultSprite;
        else
            img.sprite = BlockSprite;

        Block.GetComponent<BoxCollider>().enabled = !clickable.Default;
        redraw = true;

    }
    private void Start()
    {
        CreateInitialPoint();
        canvas = GameObject.FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if (redraw)
        {
            ReDrawLaser();
            redraw = false;
        }
        DrawLaser();
        if (CalculateWinValue())
        {
            Desk.GetComponent<OpenLaser>().Win++;
        }
        
    }
    //IEnumerator Exit()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    gameObject.SetActive(false);
    //    canvas.enabled = false;

    //    DeskAnim.SetBool("Open", true);
    //    Destroy(gameObject);
    //}
    
}
