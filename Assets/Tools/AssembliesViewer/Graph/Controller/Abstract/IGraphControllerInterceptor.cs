namespace Tools.AssembliesViewer.Graph.Controller.Abstract
{
    public interface IGraphControllerInterceptor
    {
        void SavePositions();
        void Redraw();
    }
}