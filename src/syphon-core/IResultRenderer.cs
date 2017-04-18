namespace Syphon
{
    public interface IResultRenderer
    {
        void AppendUnchanged(string str);
        void AppendChanged(string str);
        void End();
    }
}