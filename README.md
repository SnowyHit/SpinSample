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


<img width="1452" height="750" alt="Screenshot 2025-11-22 002908" src="https://github.com/user-attachments/assets/2e13f325-40d8-49f9-9881-74096f8c9e88" />
<img width="1452" height="756" alt="Screenshot 2025-11-22 002920" src="https://github.com/user-attachments/assets/69955960-0cd9-4832-b688-16cf92737605" />
<img width="1451" height="757" alt="Screenshot 2025-11-22 002914" src="https://github.com/user-attachments/assets/ec4b0dde-375c-4e8c-8aff-590ade68b780" />


