namespace Problem2.Application.Services;

public interface IPrintBalancerService
{
    void EnqueueJob(string jobId);
    void AssignNext();
    void CompleteJob(string printerId, string jobId);
    string Status();
}