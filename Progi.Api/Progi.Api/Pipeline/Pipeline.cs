namespace Progi.Api.Pipeline
{
    public class Pipeline<T>
    {
        private readonly List<IPipelineStep<T>> _steps = new();
        public Pipeline() { }
        public Pipeline(List<IPipelineStep<T>> steps)
        {
            _steps = steps;
        }
        public Pipeline<T> AddStep(IPipelineStep<T> step)
        {
            _steps.Add(step);
            return this;
        }
        public void Execute(T context)
        {
            foreach (var step in _steps)
            {
                step.Process(context);
            }
        }
    }
}
