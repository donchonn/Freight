using System;
using System.Collections.Generic;

namespace Freight.Models
{
    /// <summary>
    /// 애플리케이션 설정을 나타내는 모델 클래스
    /// </summary>
    [Serializable]
    public class AppSettings
    {
        /// <summary>
        /// 명령어 목록
        /// </summary>
        public List<CommandItem> Commands { get; set; }

        /// <summary>
        /// 기본 검색 엔진 (DEFAULT 명령어에 사용)
        /// </summary>
        public string DefaultSearchEngine { get; set; }

        /// <summary>
        /// 버전 정보
        /// </summary>
        public string Version { get; set; }

        // ===== 일반 설정 =====

        /// <summary>
        /// 폰트 이름
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// 폰트 크기
        /// </summary>
        public float FontSize { get; set; }

        /// <summary>
        /// 배경색 (ARGB 값)
        /// </summary>
        public int BackgroundColor { get; set; }

        /// <summary>
        /// 텍스트 색상 (ARGB 값)
        /// </summary>
        public int TextColor { get; set; }

        public AppSettings()
        {
            Commands = new List<CommandItem>();
            DefaultSearchEngine = "https://www.google.com/search?q=";
            Version = "3.0";

            // 기본 일반 설정
            FontName = "NanumGothicOTF";
            FontSize = 20F;
            BackgroundColor = unchecked((int)0xFF1E1E1E);  // 어두운 회색 (30, 30, 30)
            TextColor = unchecked((int)0xFFFFFFFF);        // 흰색
        }

        /// <summary>
        /// 명령어 추가
        /// </summary>
        public void AddCommand(CommandItem command)
        {
            if (command != null && !string.IsNullOrEmpty(command.Name))
            {
                Commands.Add(command);
            }
        }

        /// <summary>
        /// 명령어 제거
        /// </summary>
        public bool RemoveCommand(string commandName)
        {
            var command = Commands.Find(c => c.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));
            if (command != null)
            {
                return Commands.Remove(command);
            }
            return false;
        }

        /// <summary>
        /// 명령어 찾기
        /// </summary>
        public CommandItem FindCommand(string commandName)
        {
            return Commands.Find(c => c.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase) && c.IsEnabled);
        }
    }
}
