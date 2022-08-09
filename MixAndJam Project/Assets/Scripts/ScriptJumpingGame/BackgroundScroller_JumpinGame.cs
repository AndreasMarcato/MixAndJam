using UnityEngine;

public class BackgroundScroller_JumpinGame : MonoBehaviour
{
    //--When making repeating background remember to go to the art used and  under Advanged settings make Wrap Mode be Repeat
    //--In (3d) Plane object where picture is attached, Turn Cast Shadows off and unmark Receive Shadows.
    //--For shaders choose Unlit -> Texture (Unlit/Texture) so picture won't be dark

    [Range(-1f, 1f)]    //--how much background will move before it repeats
    public float scrollSpeed = 0.5f;    //--Speed background will move
    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        //--Get the material
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;             //--Get offset
        mat.SetTextureOffset("_MainTex", new Vector2(offset,0));    //--Move the background
    }
}
