namespace Progi.Api.Pipeline
{
    public interface IPipelineStep<T>
    {
        void Process(T context);
    }
}
