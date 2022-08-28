using System.Diagnostics;

using UnityEngine;
using UnityEngine.UI;

public class VariableScopePerformanceTester : MonoBehaviour
{
    private const long NumValues = 1000000000;

    public long SumAuto { get; private set; }

    private long sum;
    public long SumManual
    {
        get { return sum; }
        set { sum = value; }
    }

    private string report;

    void Start()
    {
        var stopwatch = new Stopwatch();

        stopwatch.Reset();
        stopwatch.Start();
        for (long i = 0; i < NumValues; ++i)
        {
            SumAuto += i;
        }
        var propertyTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Reset();
        stopwatch.Start();
        for (long i = 0; i < NumValues; ++i)
        {
            sum += i;
        }
        var fieldTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Reset();
        stopwatch.Start();
        long localSum = 0;
        for (long i = 0; i < NumValues; ++i)
        {
            localSum += i;
        }
        sum = localSum;
        var localTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Reset();
        stopwatch.Start();
        sum = 0;
        for (long i = 0; i < NumValues; ++i)
        {
            long localSumRealloc = sum; // or = 0, performance doesn't really change
            localSumRealloc += i;
        }
        var localReallocTime = stopwatch.ElapsedMilliseconds;

        report = "Test,Time\n"
            + "Property: " + propertyTime + "\n"
            + "Field: " + fieldTime + "\n"
            + "Local (Allocated once): " + localTime + "\n"
            + "Local (Allocated each iteration): " + localReallocTime + "\n";
    }

    void OnGUI()
    {
        var drawRect = new Rect(0, 0, Screen.width, Screen.height);
        GUI.TextArea(drawRect, report);
    }
}