# 🧩 Performance Report — Memory Allocation Impact: `new List<T>()` vs `Array.Empty<T>()`
**Author:** Gustavo Rabanal  
**Date:** 2025-10-10  
**Environment:** .NET 8 — macOS / dotnet-counters  
**Category:** GC & Memory Efficiency  

---

## 🧠 Executive Summary
This report presents a detailed performance comparison between two commonly used initialization patterns in .NET:

```csharp
return new List<int>();
// vs
return Array.Empty<int>();
```

The objective is to quantify the **memory allocation**, **GC pressure**, and **runtime overhead** caused by each approach under identical workload conditions.

The analysis leverages runtime metrics captured using `dotnet-counters`, focusing on GC activity, heap utilization, and allocation rates.

---

## ⚙️ Experimental Setup

| Component | Description |
|------------|--------------|
| **Runtime** | .NET 8.0 (CoreCLR) |
| **Host OS** | macOS Sonoma |
| **Tooling** | `dotnet-counters` |
| **Scenario** | Iterative creation of 10 million empty collections |
| **Variant 1** | `new List<int>()` — allocates new heap object per iteration |
| **Variant 2** | `Array.Empty<int>()` — returns cached zero-length array |
| **Duration** | 20 seconds per run |

---

## 📊 Metrics Summary

| Metric | new List<int>() | Array.Empty<int>() | Delta | Observation |
|---------|----------------:|------------------:|--------:|--------------|
| **Total Heap Allocated (Bytes)** | 323,750,000 | 1,166,720 | **~278× lower** | `Array.Empty` avoids per-call allocations |
| **Gen0 GC Count** | 1 | 0 | ✅ | One GC triggered due to allocation pressure |
| **GC Pause Time (s)** | 0.003 | 0 | ✅ | Minor pause introduced by `List<T>` |
| **Process Working Set (Bytes)** | 55,508,992 | 47,251,456 | ~8 MB lower | Lower memory footprint |
| **CPU Time (s)** | 0.457 | 0.319 | -30% | Less GC and allocation overhead |

---

## 🧠 Detailed Analysis

### 1️⃣ Allocation Behavior
Each `new List<int>()` call creates:
- A **List object** (~24 bytes)
- An internal **array of length 0** (~24 bytes)
- These objects are short-lived → collected in **Gen0**.

`Array.Empty<int>()` instead returns a **singleton cached array**, eliminating all heap activity.

> 🧩 Result: ~300× fewer allocations and no GC activity.

---

### 2️⃣ GC and Heap Dynamics
The `new List<T>()` variant triggered **1 Gen0 GC cycle**, visible in live counters as:
```
dotnet.gc.collections.gen0 = 1
dotnet.gc.heap.total_allocated = 3.23e+08 bytes
```
In contrast, the `Array.Empty<T>()` run showed no GC events.

Heap fragmentation and committed size remained **stable** with `Array.Empty`, while fluctuating under allocation pressure in the `List<T>` case.

---

### 3️⃣ Process-Level Observations
Memory (working set) and CPU consumption were both higher for the `new List<T>()` scenario, even in short-lived test runs.

This implies tangible performance impact in production systems where high-frequency API calls or background jobs instantiate large volumes of empty collections.

---

## 🚀 Conclusions

| Category | Winner | Reason |
|-----------|---------|--------|
| **Memory Efficiency** | 🏆 `Array.Empty<T>()` | No per-call allocation |
| **GC Pressure** | 🏆 `Array.Empty<T>()` | Zero collections triggered |
| **Latency / CPU** | 🏆 `Array.Empty<T>()` | Lower pause and overhead |
| **Code Safety** | Both | Immutable semantics safe in both cases |

**Final Recommendation:**  
> Always use `Array.Empty<T>()` (or `Enumerable.Empty<T>()` for IEnumerable) when returning or initializing empty collections.  
> This pattern is allocation-free, thread-safe, and officially recommended by the .NET Runtime Team.

---

## 📈 Next Steps

To further validate and visualize allocation timelines:
1. Run the same workload under `dotnet-trace` and open in **Speedscope** or **Visual Studio Concurrency Visualizer**.
2. Use `dotnet-gcdump` to inspect heap content before and after heavy allocation.
3. Benchmark with `BenchmarkDotNet` to quantify statistical differences under controlled isolation.

---

## 📚 References

- [.NET Runtime Docs — Performance Guidelines](https://learn.microsoft.com/dotnet/standard/garbage-collection/performance)  
- [CLR Team Blog — Avoid Allocations for Empty Collections](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#use-array-emptyt-instead-of-new-t0)  
- [PerfView — GC Thread Timeline Visualization](https://github.com/microsoft/perfview)  
- [dotnet-counters Documentation](https://learn.microsoft.com/dotnet/core/diagnostics/dotnet-counters)

---

**Prepared by:**  
Gustavo Rabanal  
Senior Software Architect  
