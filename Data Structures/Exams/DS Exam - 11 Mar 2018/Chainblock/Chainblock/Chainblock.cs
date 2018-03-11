using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Chainblock : IChainblock
{
    private Dictionary<int, Transaction> byId;
    private Dictionary<TransactionStatus, LinkedList<Transaction>> byStatus;
    private Dictionary<string, List<Transaction>> bySender;
    private Dictionary<string, List<Transaction>> byReceiver;

    public Chainblock()
    {
        byId = new Dictionary<int, Transaction>();
        bySender = new Dictionary<string, List<Transaction>>();
        byReceiver = new Dictionary<string, List<Transaction>>();
        byStatus = new Dictionary<TransactionStatus, LinkedList<Transaction>>
        {
            {TransactionStatus.Aborted, new LinkedList<Transaction>()},
            {TransactionStatus.Failed, new LinkedList<Transaction>()},
            {TransactionStatus.Successfull, new LinkedList<Transaction>()},
            {TransactionStatus.Unauthorized, new LinkedList<Transaction>()}
        };
    }

    public int Count => byId.Count;

    public void Add(Transaction tx)
    {
        byId.Add(tx.Id, tx);
        byStatus[tx.Status].AddLast(tx);

        if (!bySender.ContainsKey(tx.From))
        {
            bySender.Add(tx.From, new List<Transaction>());
        }

        bySender[tx.From].Add(tx);

        if (!byReceiver.ContainsKey(tx.To))
        {
            byReceiver.Add(tx.To, new List<Transaction>());
        }

        byReceiver[tx.To].Add(tx);
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        Transaction tx = byId[id];

        byStatus[tx.Status].Remove(tx);
        byStatus[newStatus].AddLast(tx);

        tx.Status = newStatus;
    }

    public bool Contains(Transaction tx)
    {
        return byId.ContainsKey(tx.Id);
    }

    public bool Contains(int id)
    {
        return byId.ContainsKey(id);
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        return byId.Values.Where(tx => tx.Amount >= lo && tx.Amount <= hi);
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return byId.Values
            .OrderByDescending(tx => tx.Amount)
            .ThenBy(tx => tx.Id);
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        if (byStatus[status].Count == 0)
        {
            throw new InvalidOperationException();
        }

        return byStatus[status]
            .OrderByDescending(tx => tx.Amount)
            .Select(tx => tx.To);
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        if (byStatus[status].Count == 0)
        {
            throw new InvalidOperationException();
        }

        return byStatus[status]
            .OrderByDescending(tx => tx.Amount)
            .Select(tx => tx.From);
    }

    public Transaction GetById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        return byId[id];
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        if (!byReceiver.ContainsKey(receiver))
        {
            throw new InvalidOperationException();
        }

        var transactions = byReceiver[receiver]
            .Where(tx => tx.Amount >= lo && tx.Amount < hi)
            .OrderByDescending(tx => tx.Amount)
            .ThenBy(tx => tx.Id)
            .ToList();

        if (transactions.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return transactions;
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        if (!byReceiver.ContainsKey(receiver))
        {
            throw new InvalidOperationException();
        }

        var transactions = byReceiver[receiver]
            .OrderByDescending(tx => tx.Amount)
            .ThenBy(tx => tx.Id)
            .ToList();

        if (transactions.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return transactions;
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        if (!bySender.ContainsKey(sender))
        {
            throw new InvalidOperationException();
        }

        var transactions = bySender[sender]
            .Where(tx => tx.Amount > amount)
            .OrderByDescending(tx => tx.Amount)
            .ToList();

        if (transactions.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return transactions;
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        if (!bySender.ContainsKey(sender))
        {
            throw new InvalidOperationException();
        }

        var transactions = bySender[sender]
            .OrderByDescending(tx => tx.Amount)
            .ToList();

        if (transactions.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return transactions;
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (byStatus[status].Count == 0)
        {
            throw new InvalidOperationException();
        }

        return byStatus[status].OrderByDescending(tx => tx.Amount);
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        return byStatus[status]
            .Where(tx => tx.Amount <= amount)
            .OrderByDescending(tx => tx.Amount);
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var transaction in byId.Values)
        {
            yield return transaction;
        }
    }

    public void RemoveTransactionById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        Transaction tx = byId[id];

        byId.Remove(tx.Id);
        byStatus[tx.Status].Remove(tx);
        bySender[tx.From].Remove(tx);
        byReceiver[tx.To].Remove(tx);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

