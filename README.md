# Unity Warp System

이 프로젝트는 Unity 2D 환경에서 **플레이어가 특정 영역에 들어가서 키(F)를 누르면 지정된 위치로 순간이동**하는 워프 시스템입니다.

---

## 📦 주요 기능

- **Trigger 기반 워프 감지**
  - 플레이어가 워프 존에 들어가면 `F` 키 입력 대기
- **WarpManager로 중앙 관리**
  - 워프 이름과 목적지를 매핑해 한곳에서 관리
- **Inspector 설정**
  - WarpTrigger: 워프 이름만 지정
  - WarpManager: 이름과 대상 위치 설정

---

## 🛠️ 프로젝트 구성

- `WarpTrigger.cs`: 각 워프 영역에 붙이는 스크립트 (F 키로 워프 실행)
- `WarpManager.cs`: 플레이어 위치 이동 처리, 목적지 매핑 관리

---

/Assets/Scripts/
├── WarpManager.cs
├── WarpTrigger.cs

## ⚙️ 사용법

1️⃣ **씬에 WarpManager 배치**
- `Player` 오브젝트 할당
- `warpEntries` 리스트에 Warp 이름과 대상 위치 등록

2️⃣ **각 WarpTrigger 오브젝트에 스크립트 추가**
- Collider2D (IsTrigger ON)
- WarpTrigger.cs 붙이고 `warpName` 지정 (예: A, B)

3️⃣ **Player 오브젝트**
- Rigidbody2D + Collider2D 필요
- Tag를 `Player`로 설정

4️⃣ **실행**
- 플레이어가 워프 존에 들어가서 `F` 키를 누르면 워프 실행

---

## 🚀 확장 아이디어

- 워프 이펙트/사운드 추가
- Inspector에서 쿨타임 시간 조절
- UI 표시 ("F 키를 눌러 이동")
- Gizmos로 워프 라인 시각화
- Editor 자동 등록 툴

---

🎮 개인 프로젝트 트러블슈팅 모음
이 저장소는 개인 프로젝트를 진행하면서 겪었던 코드 문제와 해결 과정을 정리한 기록입니다.
자세한 소스코드는 👉 GitHub Repository에서 확인할 수 있습니다.

📂 주요 트러블슈팅
⚙️ EventUI, MiniGameManager, AnimationHandler
🚨 문제 [ EventUI에서 Panel 활성화 안 됨 ]
enum 기반 UIState로 Panel 전환하려 했으나 Inspector 배열 연결 누락 및 enum 매핑 문제 발생

✅ 해결

Inspector에서 배열 필드 채우기

eventUIs[index].SetUIShow() 호출

enum → 배열 index 매핑 명확히 관리

null 체크 방어 코드 추가

🚨 문제 [ MiniGameManager에서 BestScore 갱신 안 됨 ]
PlayerPrefs 값은 갱신됐지만 UI에 즉시 반영되지 않음

✅ 해결

MiniGameManager.Instance.ResetBestScore() 호출 후

eventUI.UpdateBestScore()로 UI 반영

Awake/Start에서 PlayerPrefs 불러오기 코드 점검

🚨 문제 [ AnimatorHandler에서 Move 멈추자마자 Sleep 실행 ]
움직임 멈춘 즉시 idleTimer가 3초로 판정되어 바로 Sleep 진입

✅ 해결

playerStopTimer = 0f로 리셋

Time.deltaTime 누적 방식으로 경과 시간 계산

마지막 움직임 시간 기록 방식으로 전환

🚨 문제 [ Animator에서 Sleep → Sleeping 전환 안 됨 ]
Animator 파라미터 연결 실수, transition 조건 설정 미비

✅ 해결

Animator Parameters에 IsSleep, IsSleeping 추가

Sleep → Sleeping 전환 조건 설정

Sleeping 애니메이션에 Loop Time 활성화

🚨 문제 [ SpriteRenderer로 Sleep 애니메이션 만들 때 루프 깨짐 ]
15번 프레임 실행 후 69번 반복해야 하는데, 코루틴 인덱스 관리 꼬임

✅ 해결

1~5 프레임은 단발 실행 (foreach)

6~9 프레임은 while (true) 반복

반복 루프 종료 조건 명확히 구분

✏️ 정리
✅ 모든 문제는 코드 + Inspector + Animator의 연결 관계를 꼼꼼히 점검해 해결했습니다.
✅ 확장성과 유지보수를 고려해 enum, PlayerPrefs, Animator Parameter를 정리하고 코드 설계를 개선했습니다.

## 💬 문의

개발 중 문의나 피드백이 필요하면 언제든 연락주세요!
