using UnityEngine;

public class Awls : MonoBehaviour
{
    private BoxCollider hitbox;
    private Quaternion[] ini_awl_rotations;

    string state;
    int animating_target;

    public GameObject[] awls;
    public Transform[] awl_pivots;

    void Start() {
        state = "idle";
        animating_target = 0;
        hitbox = GetComponent<BoxCollider>();

        ini_awl_rotations = new Quaternion[4];
        for (var i = 0; i < 4; i++) {
            ini_awl_rotations[i] = awls[i].GetComponent<Transform>().rotation;
        }
    }
    void Update() {
        if (animating_target < awls.Length) {
            switch (state) {
                case "moving":
                    LerpPos(awls[animating_target], awl_pivots[animating_target].transform.position + Vector3.up, 0.035f);
                    LerpRot(awls[animating_target], awl_pivots[animating_target].transform.rotation, 0.02f);
                    if (awls[animating_target].transform.position == awl_pivots[animating_target].transform.position + Vector3.up) {
                        state = "inserting";
                    }
                    break;

                case "inserting":
                    TranslatePos(awls[animating_target], awl_pivots[animating_target].transform.position, 1.45f);
                    if (awls[animating_target].transform.position == awl_pivots[animating_target].transform.position) {
                        animating_target++;
                        state = "moving";
                    }
                    break;
            }
        }
    }

    void OnMouseUp() {
        if (state == "idle") {
            hitbox.enabled = false;
            state = "moving";
        }
    }

    void LerpPos(GameObject obj, Vector3 new_pos, float lerp_speed)
    {
        obj.transform.position = Vector3.Lerp(obj.transform.position, new_pos, lerp_speed);
        if (Vector3.Distance(obj.transform.position, new_pos) < 0.01f)
        {
            obj.transform.position = new_pos;
        }
    }
    void LerpRot(GameObject obj, Quaternion new_rot, float lerp_speed)
    {
        obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, new_rot, lerp_speed);
    }
    void TranslatePos(GameObject obj, Vector3 new_pos, float speed)
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, new_pos, speed * Time.deltaTime);
        if (Vector3.Distance(obj.transform.position, new_pos) <= speed/10)
        {
            obj.transform.position = new_pos;
        }
    }
}
