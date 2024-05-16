using UnityEngine;

[RequireComponent(typeof(Ghost))]

/// <summary>
/// 고스트 단순 행동제어 함수
/// <summary>
public class GhostBehaviour : MonoBehaviour
{
    public Ghost Ghost { get; private set; }

    public float duration;

    // 게임시작후 오브젝트 생성 시 실행
    private void Awake() {
        this.Ghost = GetComponent<Ghost>();
        this.enabled = false;
    }

    // 특정 행동 제어 타이머 
    public void Enable() {
        // 인자 없이 enable실행시 기본 duration값 사용
        Enable(this.duration);
    }

    public virtual void Enable(float duration) {
        this.enabled = true;

        CancelInvoke(); // Invoke 끝나기 전에 다른 파워쿠키 먹으면 현재 Invoke 취소후 다시 Invoke
        Invoke(nameof(Disable), duration); // duration 지난 후 Disable
    }

    public virtual void Disable() {
        this.enabled = false;

        CancelInvoke();
    }

}