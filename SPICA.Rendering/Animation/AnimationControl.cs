﻿using SPICA.Formats.CtrH3D.Animation;

using System;

namespace SPICA.Rendering.Animation
{
    public class AnimationControl
    {
        public H3DAnimation Animation;

        protected AnimationState State;

        private float _Frame;

        public float Frame
        {
            get
            {
                return _Frame;
            }
            set
            {
                _Frame = value > FramesCount
                    ? value % FramesCount
                    : value;
            }
        }

        public bool  IsLooping   { get; set; }
        public float Step        { get; set; }
        public bool  HasData     { get { return Animation != null; } }
        public float FramesCount { get { return Animation?.FramesCount ?? 0; } }

        public AnimationControl()
        {
            Step = 1;
        }

        public void CopyState(AnimationControl Control)
        {
            State     = Control.State;
            Frame     = Control.Frame;
            IsLooping = Control.IsLooping;
            Step      = Control.Step;
        }

        public void AdvanceFrame()
        {
            if (Animation != null &&
                Animation.FramesCount >= Math.Abs(Step) &&
                State == AnimationState.Playing)
            {
                _Frame += Step;

                if (_Frame < 0)
                {
                    _Frame += Animation.FramesCount;
                }
                else if (_Frame >= Animation.FramesCount)
                {
                    _Frame -= Animation.FramesCount;
                }
            }
        }

        public void SlowDown()
        {
            if (State == AnimationState.Playing && Math.Abs(Step) > 0.125f) Step *= 0.5f;
        }

        public void SpeedUp()
        {
            if (State == AnimationState.Playing && Math.Abs(Step) < 8) Step *= 2;
        }

        public void Play(float Step = 1)
        {
            this.Step = Step;

            State = AnimationState.Playing;
        }

        public void Pause()
        {
            State = AnimationState.Paused;
        }

        public void Stop()
        {
            State = AnimationState.Stopped;

            _Frame = 0;
        }
    }
}
