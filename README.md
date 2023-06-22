# Timer script explaining and UI ideas preview

![UI Example Image](https://github.com/chugaister228/UnityTimer/blob/main/Prewiews/AllUiVideoPrewiev.gif)
All UI implementations are working with one timer, but you can make more.  

---  

### How to use  
Create empty GameObject and attach *Timer.cs* script, paste the seconds duration float in the inspector.  
By default :hourglass: is 300f (5 min).
  
Now you can use Timer in any script by Timer events, which are described below.  
You can also implement singletone pattern to use only one timer in your game.   
Learn this here: https://github.com/chugaister228/unity-singleton-pattern-implementation

UI implementations have two scripts - *TimerText.cs* and *TimerProgress.cs*  
(to make reverse progress - click isReverse in the Inspector)  

All UI implementations are working without dependencies.  
Events work instead of dependencies to optimize the Timer and SOLID following.  

---

### Properties  

returns general time to time over:  
```c# 
timer.Duration
```

returns time left to time over:  
```c#
timer.TimeRemaining
```

returns true if time is over:  
```c#
timer.IsTimeOver
```

### Methods  

returns true if time remaining is more than given time:  
```c#
timer.IsMoreThanSomeTimeLeft(float time)
```

returns true if time remaining is less than given time:  
```c#
timer.IsLessThanSomeTimeLeft(float time)
```  

### Events  
static event which can be signed on some void method and will be invoked when time is starting decreasing:  
```c#
Timer.OnTimerStart
```  

static event which can be signed on some void method and will be invoked when time is decreasing:  
```c#
Timer.OnTimerWorking
```

static event which can be signed on some void method and will be invoked when time is over:  
```c#
Timer.OnTimerFinish
```

---  

git pull the project to see how it works
