using System;
using System.Collections.Generic;
using System.Drawing;

namespace Freight
{
    /// <summary>
    /// 마우스 제스처 인식 클래스
    /// </summary>
    public class MouseGesture
    {
        // 제스처 타입
        public enum GestureType
        {
            None,
            Up,
            Down,
            Left,
            Right,
            DownRight,      // 아래 + 오른쪽 (ㄴ자)
            DownLeft,       // 아래 + 왼쪽 (ㄱ자 반대)
            UpRight,        // 위 + 오른쪽
            UpLeft,         // 위 + 왼쪽
            DiagDownRight,  // 대각선 오른쪽 아래 (↘)
            DiagDownLeft,   // 대각선 왼쪽 아래 (↙)
            DiagUpRight,    // 대각선 오른쪽 위 (↗)
            DiagUpLeft      // 대각선 왼쪽 위 (↖)
        }

        // 제스처 이벤트 인자
        public class GestureEventArgs : EventArgs
        {
            public GestureType Gesture { get; }
            public Point StartPoint { get; }
            public Point EndPoint { get; }

            public GestureEventArgs(GestureType gesture, Point start, Point end)
            {
                Gesture = gesture;
                StartPoint = start;
                EndPoint = end;
            }
        }

        // 제스처 감지 이벤트
        public event EventHandler<GestureEventArgs> GestureDetected;

        // 포인트 목록
        private List<Point> points = new List<Point>();
        private bool isRecording = false;
        private Point startPoint;

        // 최소 거리 임계값 (픽셀) - 이 이상 움직여야 제스처로 인식
        private const int MinDistance = 50;
        // 포인트 샘플링 간격 (픽셀)
        private const int SampleDistance = 5;

        public bool IsRecording => isRecording;
        public List<Point> GesturePoints => new List<Point>(points);

        /// <summary>
        /// 제스처 기록 시작
        /// </summary>
        public void StartRecording(Point point)
        {
            points.Clear();
            points.Add(point);
            startPoint = point;
            isRecording = true;
        }

        /// <summary>
        /// 포인트 추가 (마우스 이동 시)
        /// </summary>
        public void AddPoint(Point point)
        {
            if (!isRecording) return;

            // 마지막 포인트와의 거리가 샘플링 간격 이상일 때만 추가
            if (points.Count > 0)
            {
                Point lastPoint = points[points.Count - 1];
                double distance = GetDistance(lastPoint, point);
                if (distance >= SampleDistance)
                {
                    points.Add(point);
                }
            }
        }

        /// <summary>
        /// 제스처 기록 종료 및 인식
        /// </summary>
        public GestureType EndRecording()
        {
            if (!isRecording)
                return GestureType.None;

            isRecording = false;

            if (points.Count < 2)
                return GestureType.None;

            Point endPoint = points[points.Count - 1];
            double totalDistance = GetDistance(startPoint, endPoint);

            // 최소 거리 미만이면 제스처 없음
            if (totalDistance < MinDistance)
                return GestureType.None;

            GestureType gesture = CalculateGesture();

            if (gesture != GestureType.None)
            {
                GestureDetected?.Invoke(this, new GestureEventArgs(gesture, startPoint, endPoint));
            }

            return gesture;
        }

        /// <summary>
        /// 제스처 타입 계산
        /// </summary>
        private GestureType CalculateGesture()
        {
            if (points.Count < 2)
                return GestureType.None;

            // 먼저 복합 제스처(L자형) 체크
            GestureType compoundGesture = DetectCompoundGesture();
            if (compoundGesture != GestureType.None)
                return compoundGesture;

            // 단일 방향 및 대각선 제스처 체크
            Point start = points[0];
            Point end = points[points.Count - 1];

            int deltaX = end.X - start.X;
            int deltaY = end.Y - start.Y;

            // 대각선 제스처 체크 (45도 ± 20도 범위)
            double angle = Math.Atan2(deltaY, deltaX) * 180 / Math.PI;  // -180 ~ 180
            double absDeltaX = Math.Abs(deltaX);
            double absDeltaY = Math.Abs(deltaY);

            // 대각선인지 확인: X와 Y 이동량이 둘 다 최소 거리의 60% 이상
            bool isDiagonal = absDeltaX > MinDistance * 0.6 && absDeltaY > MinDistance * 0.6;

            if (isDiagonal)
            {
                // 대각선 방향 결정
                if (angle >= 20 && angle <= 70)
                {
                    return GestureType.DiagDownRight;  // ↘
                }
                else if (angle >= 110 && angle <= 160)
                {
                    return GestureType.DiagDownLeft;   // ↙
                }
                else if (angle >= -70 && angle <= -20)
                {
                    return GestureType.DiagUpRight;    // ↗
                }
                else if (angle >= -160 && angle <= -110)
                {
                    return GestureType.DiagUpLeft;     // ↖
                }
            }

            // 주 방향 결정 (수직/수평 중 더 큰 쪽)
            if (absDeltaX > absDeltaY)
            {
                // 수평 이동이 더 큼
                if (deltaX > 0)
                    return GestureType.Right;
                else
                    return GestureType.Left;
            }
            else
            {
                // 수직 이동이 더 큼
                if (deltaY > 0)
                    return GestureType.Down;
                else
                    return GestureType.Up;
            }
        }

        /// <summary>
        /// 복합 제스처 감지 (L자형: Down+Right, Down+Left, Up+Right, Up+Left)
        /// </summary>
        private GestureType DetectCompoundGesture()
        {
            if (points.Count < 5)
                return GestureType.None;

            // 경로를 두 부분으로 나눠서 방향 변화 감지
            int midIndex = points.Count / 2;

            // 전반부 방향
            Point firstStart = points[0];
            Point firstEnd = points[midIndex];
            int firstDeltaX = firstEnd.X - firstStart.X;
            int firstDeltaY = firstEnd.Y - firstStart.Y;

            // 후반부 방향
            Point secondStart = points[midIndex];
            Point secondEnd = points[points.Count - 1];
            int secondDeltaX = secondEnd.X - secondStart.X;
            int secondDeltaY = secondEnd.Y - secondStart.Y;

            // 방향 판단 헬퍼
            bool firstIsDown = firstDeltaY > MinDistance / 2 && Math.Abs(firstDeltaY) > Math.Abs(firstDeltaX);
            bool firstIsUp = firstDeltaY < -MinDistance / 2 && Math.Abs(firstDeltaY) > Math.Abs(firstDeltaX);
            bool secondIsRight = secondDeltaX > MinDistance / 2 && Math.Abs(secondDeltaX) > Math.Abs(secondDeltaY);
            bool secondIsLeft = secondDeltaX < -MinDistance / 2 && Math.Abs(secondDeltaX) > Math.Abs(secondDeltaY);

            // L자형 패턴 감지
            if (firstIsDown && secondIsRight)
                return GestureType.DownRight;   // ㄴ자
            if (firstIsDown && secondIsLeft)
                return GestureType.DownLeft;    // ㄱ자 반대
            if (firstIsUp && secondIsRight)
                return GestureType.UpRight;
            if (firstIsUp && secondIsLeft)
                return GestureType.UpLeft;

            return GestureType.None;
        }

        /// <summary>
        /// 두 점 사이의 거리 계산
        /// </summary>
        private double GetDistance(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// 현재까지의 이동 거리 계산
        /// </summary>
        public double GetCurrentDistance()
        {
            if (points.Count < 2)
                return 0;

            return GetDistance(points[0], points[points.Count - 1]);
        }

        /// <summary>
        /// 포인트 초기화
        /// </summary>
        public void Clear()
        {
            points.Clear();
            isRecording = false;
        }
    }
}
