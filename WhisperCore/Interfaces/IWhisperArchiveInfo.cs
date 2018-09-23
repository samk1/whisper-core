﻿namespace WhisperCore.Interfaces
{
    public interface IWhisperArchiveInfo
    {
        uint Offset { get; }

        uint Points { get; }

        uint SecondsPerPoint { get; }
    }
}