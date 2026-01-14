/*
 * ============================================================================
 * AppSettings.cs - 애플리케이션 설정 모델
 * ============================================================================
 *
 * [역할]
 * 프로그램의 모든 설정 데이터를 담는 클래스입니다.
 * - 명령어 목록 (런처에서 사용)
 * - UI 설정 (폰트, 색상)
 * - 마우스 제스처 설정
 *
 * [데이터 흐름]
 * 1. 프로그램 시작 시 ConfigManager가 JSON 파일에서 로드
 * 2. 설정 폼에서 수정
 * 3. ConfigManager가 JSON 파일로 저장
 *
 * [관련 파일]
 * - ConfigManager.cs: 설정 로드/저장 담당
 * - SettingsForm.cs: 설정 UI
 * - config.json: 저장된 설정 파일 (프로그램 폴더에 생성됨)
 *
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Freight.Models
{
    // ============================================================================
    // 제스처 액션 타입 열거형
    // ============================================================================

    /// <summary>
    /// 제스처 액션 타입
    ///
    /// [열거형(enum)이란?]
    /// 관련된 상수들을 그룹으로 묶은 것
    /// 예: GestureActionType.Home = "맨 위로" 액션
    ///
    /// [왜 열거형을 사용하는가?]
    /// 1. 문자열 대신 사용하면 오타 방지
    /// 2. 자동완성 지원 (IDE에서 사용 가능한 값 표시)
    /// 3. switch 문에서 모든 경우 처리 확인 가능
    ///
    /// [사용 예]
    /// GestureActionType action = GestureActionType.Home;
    /// if (action == GestureActionType.PageDown) { ... }
    /// </summary>
    public enum GestureActionType
    {
        /// <summary>
        /// 아무 동작 없음
        /// </summary>
        None,

        /// <summary>
        /// 맨 위로 (Home 키)
        /// - 브라우저: 페이지 맨 위로 스크롤
        /// - 텍스트: 문서 처음으로 이동
        /// </summary>
        Home,

        /// <summary>
        /// 맨 아래로 (End 키)
        /// - 브라우저: 페이지 맨 아래로 스크롤
        /// - 텍스트: 문서 끝으로 이동
        /// </summary>
        End,

        /// <summary>
        /// 페이지 위로 (Page Up 키)
        /// - 한 화면 분량 위로 스크롤
        /// </summary>
        PageUp,

        /// <summary>
        /// 페이지 아래로 (Page Down 키)
        /// - 한 화면 분량 아래로 스크롤
        /// </summary>
        PageDown,

        /// <summary>
        /// 뒤로 가기 (Backspace 키)
        /// - 브라우저: 이전 페이지로 이동
        /// </summary>
        Backspace,

        /// <summary>
        /// 앞으로 가기 (Alt+Right)
        /// - 브라우저: 다음 페이지로 이동 (뒤로 가기 후)
        /// </summary>
        Forward,

        /// <summary>
        /// 창/탭 닫기
        /// - 브라우저: Ctrl+F4 (탭 닫기)
        /// - 일반 앱: Alt+F4 (창 닫기)
        ///
        /// [왜 구분하는가?]
        /// 브라우저에서 Alt+F4를 누르면 전체 브라우저가 종료됨
        /// 탭 하나만 닫으려면 Ctrl+F4 필요
        /// </summary>
        CloseWindow,

        /// <summary>
        /// 탭 닫기 (Ctrl+W)
        /// - 브라우저, IDE 등에서 현재 탭 닫기
        /// </summary>
        CloseTab,

        /// <summary>
        /// 창 최소화
        /// - 창을 작업표시줄로 내림
        /// </summary>
        MinimizeWindow,

        /// <summary>
        /// 창 최대화/복원 토글
        /// - 최대화 상태 ↔ 이전 크기 전환
        /// </summary>
        MaximizeWindow
    }

    // ============================================================================
    // 제스처 설정 클래스
    // ============================================================================

    /// <summary>
    /// 마우스 제스처 설정
    ///
    /// [Serializable이란?]
    /// 이 클래스를 직렬화(파일로 저장/불러오기) 가능하게 만드는 특성
    /// JSON.NET이 이 클래스를 JSON으로 변환할 수 있게 함
    ///
    /// [설정 구조]
    /// - 활성화 여부 (Enabled)
    /// - 시각적 설정 (색상, 펜 두께)
    /// - 제스처별 액션 매핑 (Up → Home, Down → PageDown, 등)
    /// </summary>
    [Serializable]
    public class GestureSettings
    {
        /// <summary>
        /// 제스처 기능 활성화 여부
        /// - true: 마우스 제스처 사용
        /// - false: 마우스 제스처 비활성화
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 제스처 오버레이 색상 (ARGB 정수값)
        ///
        /// [ARGB란?]
        /// Alpha(투명도), Red, Green, Blue 각 8비트로 구성된 32비트 색상
        /// 0xC89B59B6 = 알파:C8(200), R:9B(155), G:59(89), B:B6(182)
        ///
        /// [unchecked란?]
        /// int는 부호가 있어서 0x80000000 이상이면 음수가 됨
        /// unchecked로 감싸면 오버플로우 검사 없이 비트 그대로 저장
        /// </summary>
        public int OverlayColor { get; set; } = unchecked((int)0xC89B59B6);  // 보라색 (Alpha:200, R:155, G:89, B:182)

        /// <summary>
        /// 제스처 궤적 선의 두께 (픽셀)
        /// </summary>
        public float PenWidth { get; set; } = 56f;  // 기본 펜 너비

        // ==================== 단일 방향 제스처 ====================

        /// <summary>
        /// ↑ 위 제스처 액션
        /// 기본값: 맨 위로 (Home)
        /// </summary>
        public GestureActionType UpAction { get; set; } = GestureActionType.Home;

        /// <summary>
        /// ↓ 아래 제스처 액션
        /// 기본값: 페이지 아래로 (Page Down)
        /// </summary>
        public GestureActionType DownAction { get; set; } = GestureActionType.PageDown;

        /// <summary>
        /// ← 왼쪽 제스처 액션
        /// 기본값: 뒤로 가기 (Backspace)
        /// </summary>
        public GestureActionType LeftAction { get; set; } = GestureActionType.Backspace;

        /// <summary>
        /// → 오른쪽 제스처 액션
        /// 기본값: 앞으로 가기 (Alt+Right)
        /// </summary>
        public GestureActionType RightAction { get; set; } = GestureActionType.Forward;

        // ==================== L자형 제스처 ====================
        // L자형 = 두 방향을 연속으로 그리는 제스처
        // 예: DownRight = ↓ 후 → (ㄴ자 모양)

        /// <summary>
        /// ↓→ ㄴ자 제스처 (아래 후 오른쪽)
        /// 기본값: 창 닫기
        /// </summary>
        public GestureActionType DownRightAction { get; set; } = GestureActionType.CloseWindow;

        /// <summary>
        /// ↓← ㄴ자 반대 제스처 (아래 후 왼쪽)
        /// 기본값: 창 최소화
        /// </summary>
        public GestureActionType DownLeftAction { get; set; } = GestureActionType.MinimizeWindow;

        /// <summary>
        /// ↑→ ㄱ자 제스처 (위 후 오른쪽)
        /// 기본값: 창 최대화
        /// </summary>
        public GestureActionType UpRightAction { get; set; } = GestureActionType.MaximizeWindow;

        /// <summary>
        /// ↑← ㄱ자 반대 제스처 (위 후 왼쪽)
        /// 기본값: 없음
        /// </summary>
        public GestureActionType UpLeftAction { get; set; } = GestureActionType.None;

        // ==================== 대각선 제스처 ====================
        // 대각선 = 45도 각도로 그리는 제스처
        // L자형과 구분: L자는 방향 전환이 있고, 대각선은 직선

        /// <summary>
        /// ↘ 대각선 (오른쪽 아래)
        /// </summary>
        public GestureActionType DiagDownRightAction { get; set; } = GestureActionType.None;

        /// <summary>
        /// ↙ 대각선 (왼쪽 아래)
        /// </summary>
        public GestureActionType DiagDownLeftAction { get; set; } = GestureActionType.None;

        /// <summary>
        /// ↗ 대각선 (오른쪽 위)
        /// </summary>
        public GestureActionType DiagUpRightAction { get; set; } = GestureActionType.None;

        /// <summary>
        /// ↖ 대각선 (왼쪽 위)
        /// </summary>
        public GestureActionType DiagUpLeftAction { get; set; } = GestureActionType.None;

        /// <summary>
        /// 기본 생성자
        /// - 프로퍼티 초기값이 설정되어 있으므로 비어있음
        /// </summary>
        public GestureSettings() { }
    }

    // ============================================================================
    // 애플리케이션 설정 클래스
    // ============================================================================

    /// <summary>
    /// 애플리케이션 설정을 나타내는 모델 클래스
    ///
    /// [모델(Model)이란?]
    /// MVC 패턴에서 데이터를 담는 클래스
    /// 로직 없이 데이터만 저장 (get/set만 있음)
    ///
    /// [이 클래스가 담는 설정]
    /// 1. 명령어 목록 (런처에서 입력할 수 있는 명령어들)
    /// 2. 기본 검색 엔진 URL
    /// 3. UI 설정 (폰트, 색상)
    /// 4. 마우스 제스처 설정
    ///
    /// [JSON 저장 예시]
    /// {
    ///   "Commands": [ { "Name": "chrome", "Path": "C:\\...", ... } ],
    ///   "FontName": "NanumGothicOTF",
    ///   "FontSize": 20,
    ///   "GestureSettings": { "Enabled": true, ... }
    /// }
    /// </summary>
    [Serializable]
    public class AppSettings
    {
        /// <summary>
        /// 명령어 목록
        ///
        /// [List란?]
        /// 동적 배열 - 크기가 자동으로 늘어나는 배열
        /// Add(), Remove(), Find() 등의 메서드 제공
        ///
        /// [CommandItem]
        /// 개별 명령어를 나타내는 클래스
        /// - Name: 명령어 이름 (예: "chrome")
        /// - Path: 실행 경로 (예: "C:\Program Files\Google\Chrome\chrome.exe")
        /// - IsEnabled: 활성화 여부
        /// </summary>
        public List<CommandItem> Commands { get; set; }

        /// <summary>
        /// 기본 검색 엔진 URL
        ///
        /// [사용 방법]
        /// DEFAULT 명령어 실행 시 이 URL 뒤에 검색어를 붙여서 열기
        /// 예: "https://www.google.com/search?q=" + "검색어"
        /// </summary>
        public string DefaultSearchEngine { get; set; }

        /// <summary>
        /// 설정 파일 버전 정보
        /// - 향후 설정 구조 변경 시 호환성 관리용
        /// </summary>
        public string Version { get; set; }

        // ==================== UI 설정 ====================

        /// <summary>
        /// 폰트 이름
        /// 예: "NanumGothicOTF", "맑은 고딕", "Consolas"
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// 폰트 크기 (포인트 단위)
        /// 예: 12F, 20F, 24F
        ///
        /// [float인 이유]
        /// 폰트 크기는 소수점 가능 (예: 10.5pt)
        /// F는 float 리터럴 접미사
        /// </summary>
        public float FontSize { get; set; }

        /// <summary>
        /// 배경색 (ARGB 정수값)
        ///
        /// [변환 방법]
        /// Color → int: color.ToArgb()
        /// int → Color: Color.FromArgb(value)
        ///
        /// [왜 int로 저장하는가?]
        /// Color는 구조체라서 JSON 직렬화가 복잡함
        /// int로 저장하면 간단하게 직렬화 가능
        /// </summary>
        public int BackgroundColor { get; set; }

        /// <summary>
        /// 텍스트 색상 (ARGB 정수값)
        /// </summary>
        public int TextColor { get; set; }

        /// <summary>
        /// 마우스 제스처 설정
        /// - 별도 클래스로 분리하여 관리
        /// </summary>
        public GestureSettings GestureSettings { get; set; }

        /// <summary>
        /// 기본 생성자
        ///
        /// [생성자란?]
        /// 객체가 생성될 때 자동으로 호출되는 메서드
        /// new AppSettings() 하면 이 코드가 실행됨
        ///
        /// [초기화 내용]
        /// 1. Commands 리스트 생성 (비어있음)
        /// 2. 기본 검색 엔진 설정 (Google)
        /// 3. UI 기본값 설정 (어두운 테마)
        /// 4. 제스처 설정 객체 생성
        /// </summary>
        public AppSettings()
        {
            // 빈 명령어 리스트 생성
            Commands = new List<CommandItem>();

            // 기본 검색 엔진: Google
            DefaultSearchEngine = "https://www.google.com/search?q=";

            // 설정 버전
            Version = "3.0";

            // ========== UI 기본 설정 (어두운 테마) ==========

            // 폰트: 나눔고딕 20pt
            FontName = "NanumGothicOTF";
            FontSize = 20F;

            // 배경색: 어두운 회색 RGB(30, 30, 30), 알파 255(불투명)
            // 0xFF1E1E1E = Alpha:FF(255), R:1E(30), G:1E(30), B:1E(30)
            BackgroundColor = unchecked((int)0xFF1E1E1E);

            // 텍스트 색상: 흰색
            // 0xFFFFFFFF = Alpha:FF(255), R:FF(255), G:FF(255), B:FF(255)
            TextColor = unchecked((int)0xFFFFFFFF);

            // 제스처 설정 (기본값은 GestureSettings 클래스에 정의됨)
            GestureSettings = new GestureSettings();
        }

        // ============================================================================
        // 명령어 관리 메서드
        // ============================================================================

        /// <summary>
        /// 명령어 추가
        ///
        /// [매개변수]
        /// command: 추가할 명령어 객체
        ///
        /// [동작]
        /// 1. null 체크
        /// 2. 이름이 비어있지 않은지 확인
        /// 3. 리스트에 추가
        /// </summary>
        public void AddCommand(CommandItem command)
        {
            // null이 아니고 이름이 있는 경우에만 추가
            if (command != null && !string.IsNullOrEmpty(command.Name))
            {
                Commands.Add(command);
            }
        }

        /// <summary>
        /// 명령어 제거
        ///
        /// [매개변수]
        /// commandName: 제거할 명령어 이름
        ///
        /// [반환값]
        /// 제거 성공 시 true, 실패(찾지 못함) 시 false
        ///
        /// [동작]
        /// 1. 이름으로 명령어 찾기 (대소문자 무시)
        /// 2. 찾으면 리스트에서 제거
        /// </summary>
        public bool RemoveCommand(string commandName)
        {
            // Find: 조건에 맞는 첫 번째 요소 반환
            // StringComparison.OrdinalIgnoreCase: 대소문자 무시 비교
            var command = Commands.Find(c => c.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));

            if (command != null)
            {
                return Commands.Remove(command);  // 제거 성공 시 true
            }
            return false;  // 찾지 못함
        }

        /// <summary>
        /// 명령어 찾기
        ///
        /// [매개변수]
        /// commandName: 찾을 명령어 이름
        ///
        /// [반환값]
        /// 찾은 CommandItem 객체, 없으면 null
        ///
        /// [동작]
        /// 1. 이름으로 검색 (대소문자 무시)
        /// 2. 활성화된(IsEnabled=true) 명령어만 반환
        /// </summary>
        public CommandItem FindCommand(string commandName)
        {
            // 람다 표현식: c => c.Name.Equals(...) && c.IsEnabled
            // c: Commands 리스트의 각 요소
            // 조건: 이름이 같고 활성화된 것
            return Commands.Find(c => c.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase) && c.IsEnabled);
        }
    }
}
