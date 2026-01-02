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
            DownRight,  // 아래 + 오른쪽 (L자)
            DownLeft    // 대각선 왼쪽 아래
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
        private const int MinDistance = 30;
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

            // 먼저 복합 제스처(DownRight) 체크
            GestureType compoundGesture = DetectCompoundGesture();
            if (compoundGesture != GestureType.None)
                return compoundGesture;

            // 단일 방향 제스처 체크
            Point start = points[0];
            Point end = points[points.Count - 1];

            int deltaX = end.X - start.X;
            int deltaY = end.Y - start.Y;

            // 대각선 왼쪽 아래 체크 (DownLeft)
            // Y가 증가하고(아래로), X가 감소하는(왼쪽으로) 경우
            if (deltaY > MinDistance && deltaX < -MinDistance)
            {
                double angle = Math.Atan2(deltaY, deltaX) * 180 / Math.PI;
                // 대각선: 대략 120~150도 범위
                if (angle >= 120 && angle <= 160)
                {
                    return GestureType.DownLeft;
                }
            }

            // 주 방향 결정 (수직/수평 중 더 큰 쪽)
            if (Math.Abs(deltaX) > Math.Abs(deltaY))
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
        /// 복합 제스처 감지 (Down + Right = L자 모양)
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

            // Down + Right 패턴 감지
            // 전반부: 아래로 (deltaY > 0, |deltaY| > |deltaX|)
            // 후반부: 오른쪽으로 (deltaX > 0, |deltaX| > |deltaY|)
            bool firstIsDown = firstDeltaY > MinDistance / 2 && Math.Abs(firstDeltaY) > Math.Abs(firstDeltaX);
            bool secondIsRight = secondDeltaX > MinDistance / 2 && Math.Abs(secondDeltaX) > Math.Abs(secondDeltaY);

            if (firstIsDown && secondIsRight)
            {
                return GestureType.DownRight;
            }

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
