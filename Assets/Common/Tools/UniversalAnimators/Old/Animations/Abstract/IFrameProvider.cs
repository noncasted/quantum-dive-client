using Common.Tools.UniversalAnimators.Old.Animations.FrameSequence;

namespace Common.Tools.UniversalAnimators.Old.Animations.Abstract
{
    public interface IFrameProvider
    {
        int FramesCount { get; }
        IFrameData GetFrame(int index);
    }
}