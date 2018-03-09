using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Judge : IJudge
{
    private Dictionary<int, HashSet<Submission>> byUserId;
    private HashSet<int> contestIds;

    private SortedDictionary<int, Submission> bySubmissionId;

    private Dictionary<SubmissionType, HashSet<Submission>> byType;

    private OrderedDictionary<int, HashSet<Submission>> byPoints;

    public Judge()
    {
        byUserId = new Dictionary<int, HashSet<Submission>>();
        contestIds = new HashSet<int>();
        bySubmissionId = new SortedDictionary<int, Submission>();
        byType = new Dictionary<SubmissionType, HashSet<Submission>>
        {
            {SubmissionType.CSharpCode, new HashSet<Submission>()},
            {SubmissionType.JavaScriptCode, new HashSet<Submission>()},
            {SubmissionType.JavaCode, new HashSet<Submission>()},
            {SubmissionType.PhpCode, new HashSet<Submission>()}
        };

        byPoints = new OrderedDictionary<int, HashSet<Submission>>();
    }

    public void AddContest(int contestId)
    {
        contestIds.Add(contestId);
    }

    public void AddSubmission(Submission submission)
    {
        if (bySubmissionId.ContainsKey(submission.Id))
        {
            return;
        }

        if (!byUserId.ContainsKey(submission.UserId) ||
            !contestIds.Contains(submission.ContestId))
        {
            throw new InvalidOperationException(); ;
        }

        byType[submission.Type].Add(submission);

        bySubmissionId.Add(submission.Id, submission);

        if (!byPoints.ContainsKey(submission.Points))
        {
            byPoints.Add(submission.Points, new HashSet<Submission>());
        }

        byPoints[submission.Points].Add(submission);

        byUserId[submission.UserId].Add(submission);
    }

    public void AddUser(int userId)
    {
        if (byUserId.ContainsKey(userId))
        {
            return;
        }

        byUserId.Add(userId, new HashSet<Submission>());
    }

    public void DeleteSubmission(int submissionId)
    {
        if (!bySubmissionId.ContainsKey(submissionId))
        {
            throw new InvalidOperationException();
        }

        Submission toRemove = bySubmissionId[submissionId];

        bySubmissionId.Remove(submissionId);

        byType[toRemove.Type].Remove(toRemove);

        byPoints[toRemove.Points].Remove(toRemove);
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return bySubmissionId.Values;
    }

    public IEnumerable<int> GetUsers()
    {
        return byUserId.Keys.OrderBy(x => x);
    }

    public IEnumerable<int> GetContests()
    {
        return contestIds.OrderBy(x => x);
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        foreach (var keyValuePair in byPoints.Range(minPoints, true, maxPoints, true))
        {
            foreach (var submission in keyValuePair.Value.Where(x => x.Type == submissionType))
            {
                yield return submission;
            }
        }
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        if (!byUserId.ContainsKey(userId))
        {
            throw new InvalidOperationException();
        }

        //return byUserId[userId]
        //       .GroupBy(x => x.ContestId)
        //       .OrderByDescending(x => x.Max(s => s.Points))
        //       .ThenBy(x => x.Min(s => s.Id))
        //       .Select(x => x.Key);

        return byUserId[userId]
            .GroupBy(x => x.ContestId)
            .Select(x => x.OrderByDescending(s => s.Points)
                .ThenBy(s => s.Id)
                .First())
            .OrderByDescending(x => x.Points)
            .ThenBy(x => x.Id)
            .Select(x => x.ContestId);
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        if (!byUserId.ContainsKey(userId) ||
            !contestIds.Contains(contestId) ||
            !byPoints.ContainsKey(points))
        {
            throw new InvalidOperationException();
        }

        return byPoints[points].Where(x => x.UserId == userId && x.ContestId == contestId);
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        HashSet<int> contests = new HashSet<int>();
        foreach (var submission in byType[submissionType])
        {
            contests.Add(submission.ContestId);
        }

        return contests;
    }
}
