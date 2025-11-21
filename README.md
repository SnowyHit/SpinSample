# SpinSample

## 🎬 Review Video  
Watch the demo of the project on YouTube:  
[Watch on YouTube](https://www.youtube.com/watch?v=4SLpjt144h8)

---

## 🧩 About  
SpinSample is a Unity sample project that implements a wheel-of-fortune style game loop:  
- Wheel slices are fully editor-configurable via ScriptableObjects.  
- Every 5th spin is a **Safe Zone** (risk-free, silver spin).  
- Every 30th spin is a **Super Zone** (risk-free, golden spin).  
- Other spin are normal spins, including a bomb slice which resets progress if landed on.  
- Players may cash out after any spin.
- Collected rewards are aggregated, stacked, and reset on bomb hit.

---

## Features  
- Weighted slice selection (including bomb and rewards).  
- Zone logic distinguishing Bronze / Silver / Gold spin types.  
- UI flow with spin panel, reward panel, bomb panel, “Spin Again” and “Cash Out” controls.  
- Clean singleton `GameManager` managing loop state.  
- Runtime reward list that stacks identical items rather than duplicating.
