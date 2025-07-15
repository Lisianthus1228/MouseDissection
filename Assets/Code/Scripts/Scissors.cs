using UnityEngine;

public class Scissors : MonoBehaviour
{
    private Animator mAnimator;
    private Vector3 ini_position;
    private Quaternion ini_rotation;
    private BoxCollider hitbox;

    string state;
    bool cut_open;

    public Transform pivot_start_cut;
    public Transform pivot_end_cut;
    public GameObject mouse_skin;
    public GameObject mouse_cut_skin;

    void Start() {
        mAnimator = GetComponent<Animator>();
        ini_position = this.GetComponent<Transform>().position;
        ini_rotation = this.GetComponent<Transform>().rotation;
        hitbox = GetComponent<BoxCollider>();

        state = "idle";
        cut_open = false;
    }

    void Update() {
        if (mAnimator != null) {
            if (state == "anim_cut") {
                mAnimator.Play("Scissor_Cut");
            } else {
                mAnimator.Play("Scissor_Idle");
            }
        }

        switch (state) {
            case "anim_begin":
                hitbox.enabled = false;
                LerpPos(this.gameObject, pivot_start_cut.position, 0.045f);
                LerpRot(this.gameObject, pivot_start_cut.rotation, 0.03f);
                if (transform.position == pivot_start_cut.position) {
                    state = "anim_cut";
                }
                break;
            case "anim_cut":
                TranslatePos(this.gameObject, pivot_end_cut.position, 1.2f);
                if (transform.position == pivot_end_cut.position) {
                    state = "anim_end";
                }
                break;
            case "anim_end":
                LerpPos(this.gameObject, ini_position, 0.03f);
                LerpRot(this.gameObject, ini_rotation, 0.03f);
                OpenMouse();
                if (transform.position == ini_position) {
                    state = "idle";
                    hitbox.enabled = true;
                    cut_open = true;
                }
                break;

        }
    }

    void OnMouseUp() {
        if (state == "idle" && !cut_open) state = "anim_begin";
    }
    void OpenMouse() {
        mouse_skin.GetComponent<MeshRenderer>().enabled = false;
        mouse_skin.GetComponent<BoxCollider>().enabled = false;

        mouse_cut_skin.GetComponent<MeshRenderer>().enabled = true;
        mouse_cut_skin.GetComponent<MeshRenderer>().material.color = mouse_skin.GetComponent<MeshRenderer>().material.color;
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
        if (Vector3.Distance(obj.transform.position, new_pos) <= speed)
        {
            obj.transform.position = new_pos;
        }
    }
}
