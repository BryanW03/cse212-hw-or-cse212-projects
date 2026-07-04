using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities added out of order: Low (1),
    // High (5), Medium (3). Dequeue three times.
    // Expected Result: High, Medium, Low
    // Defect(s) Found: Dequeue's search loop (index < _queue.Count - 1) never checked the last
    // item in the list, and the found item was never removed from the list after being returned.
    // As a result, the same item (High) was returned on every call instead of High, Medium, Low.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items where two share the highest priority: First (3), Second (1),
    // Third (3). Dequeue three times.
    // Expected Result: First, Third, Second (items with equal priority come out in the order
    // they were added - FIFO among ties)
    // Defect(s) Found: The ">=" comparison used to find the highest-priority index meant a later
    // item with an equal priority would incorrectly replace an earlier one, breaking FIFO order
    // for ties. Combined with the loop/removal defects above, "First" was returned on every call
    // instead of First, Third, Second.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from a queue that has no items in it.
    // Expected Result: An InvalidOperationException should be thrown with the message
    // "The queue is empty."
    // Defect(s) Found: No defects found. The empty-queue check was already implemented
    // correctly. Test passes as-is.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}