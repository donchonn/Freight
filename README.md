# Freight 3.0

키보드 단축키로 실행하는 빠른 런처 프로그램입니다. (Spotlight/Alfred 스타일)

## 주요 기능

- **F8 단축키**로 빠른 실행창 호출
- **모던한 UI** - 둥근 모서리, 그림자 효과
- **프로그램 내 설정** - 더 이상 엑셀 파일 수정 불필요
- **명령어 관리** - 추가/수정/삭제가 간편한 GUI
- **JSON 기반 설정** - config.json 파일로 관리

## 시스템 요구사항

- Windows 7 이상
- .NET Framework 4.8

## 빌드 방법

### Visual Studio에서 빌드

1. `Freight.sln` 파일 열기
2. NuGet 패키지 복원 (자동 또는 수동)
3. 빌드 (Ctrl+Shift+B)
4. 실행 (F5)

### 필요한 NuGet 패키지

- **Newtonsoft.Json** 13.0.3

## 사용 방법

### 기본 사용

1. **F8** 키를 눌러 검색창 표시
2. 명령어 입력 (예: `google 검색어`)
3. **Enter** 키로 실행
4. **ESC** 키로 취소

### 설정 관리

1. F8으로 검색창 표시
2. 우측 상단 **⚙** 버튼 클릭
3. 명령어 추가/수정/삭제

#### 명령어 추가 예시

- **명령어**: `google`
- **설명**: Google 검색
- **경로**: `https://www.google.com/search?q=`

#### 기본 명령어

최초 실행 시 다음 명령어가 자동으로 생성됩니다:

- `google` - Google 검색
- `youtube` - YouTube 검색
- `naver` - Naver 검색
- `DEFAULT` - 기본 검색 (명령어를 찾을 수 없을 때 사용)

### 추가 단축키

- **Ctrl+Shift+|** - 볼륨 음소거
- **Ctrl+Shift+F1** - 디스플레이 확장
- **Ctrl+Shift+F2** - 디스플레이 복제
- **Ctrl+Shift+F3** - 내부 디스플레이만
- **Ctrl+Shift+F4** - 외부 디스플레이만
- **Ctrl+Shift+S** - copypath.txt 내용 클립보드 복사

### 종료

검색창에 `꺼져` 또는 `종료` 또는 `exit` 입력

## 설정 파일

### 위치

실행 파일과 동일한 폴더에 `config.json` 파일이 생성됩니다.

### 형식

```json
{
  "Commands": [
    {
      "Name": "google",
      "Description": "Google 검색",
      "Path": "https://www.google.com/search?q=",
      "Type": "URL",
      "IsEnabled": true
    }
  ],
  "DefaultSearchEngine": "https://www.google.com/search?q=",
  "Version": "3.0"
}
```

## 프로젝트 구조

```
Freight/
├── Models/
│   ├── CommandItem.cs       # 명령어 데이터 모델
│   └── AppSettings.cs        # 설정 모델
├── Services/
│   └── ConfigManager.cs      # JSON 설정 관리
├── ModernForm.cs             # 모던 폼 베이스
├── ProgramForm1.cs           # 메인 검색창
├── SettingsForm.cs           # 설정 UI
├── Analyze.cs                # 명령어 분석
├── Run.cs                    # 명령어 실행
└── Program.cs                # 진입점
```

## 버전 히스토리

### v3.0 (2025)
- 모던 UI 디자인
- JSON 기반 설정 시스템
- 프로그램 내 설정 UI
- 코드 리팩토링 및 개선
- .NET Framework 4.8 업그레이드

### v2.3 (이전)
- Excel 기반 설정
- 기본 UI
- .NET Framework 3.5

## 라이선스

개인 프로젝트

## 의존성

- **Gma.UserActivityMonitor** - 전역 키보드/마우스 후킹
- **Newtonsoft.Json** - JSON 직렬화/역직렬화
