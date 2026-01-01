using System;

namespace Freight.Models
{
    /// <summary>
    /// 명령어 항목을 나타내는 모델 클래스
    /// </summary>
    [Serializable]
    public class CommandItem
    {
        /// <summary>
        /// 명령어 이름 (예: "google", "youtube", "w")
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 명령어 설명
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 실행할 경로 또는 URL
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 명령어 타입 (Application, URL, Script 등)
        /// </summary>
        public CommandType Type { get; set; }

        /// <summary>
        /// 활성화 여부
        /// </summary>
        public bool IsEnabled { get; set; }

        public CommandItem()
        {
            IsEnabled = true;
            Type = CommandType.URL;
        }

        public CommandItem(string name, string description, string path, CommandType type = CommandType.URL)
        {
            Name = name;
            Description = description;
            Path = path;
            Type = type;
            IsEnabled = true;
        }

        public override string ToString()
        {
            return $"{Name} - {Description}";
        }
    }

    /// <summary>
    /// 명령어 타입
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// 웹 URL
        /// </summary>
        URL,

        /// <summary>
        /// 응용 프로그램
        /// </summary>
        Application,

        /// <summary>
        /// 파일 경로
        /// </summary>
        FilePath,

        /// <summary>
        /// 스크립트
        /// </summary>
        Script
    }
}
