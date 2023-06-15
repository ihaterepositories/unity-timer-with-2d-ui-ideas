# Timer implementation with float converting into 00:00

![UI Example Image](https://github.com/chugaister228/UnityTimer/blob/main/UiExample.png)

---

### How to use  
Create empty GameObject and attach *Timer.cs* script, paste the seconds duration float in the inspector.  
By default :hourglass: is 300f (5 min).
  
Now you can use Timer in any file: *[SerializeFiled] private Timer timer*;   
Base methods: *timer.StartTimer(), timer.StopTimer(), timer.ContinueTimer()*.

### Other features  
Properties:  
*timer.Duration* - returns general time to time over  
*timer.TimeRemaining* - returns time left to time over  
*timer.IsTimeOver* - returns true if time is over  

Methods:  
*timer.StartTimer()* - starts the time decrease  
*timer.StopTimer()* - stops the time decrease  
*timer.ContinueTimer()* - continious decreasing time from last timer stop  
*timer.IsMoreThanSomeTimeLeft(float time)* - returns true if time remaining is more than given time  
*timer.IsLessThanSomeTimeLeft(float time)* - returns true if time remaining is less than given time  

Events:  
*Timer.OnTimeOver* - static event which can be signed on some void method and will be invoked when time is over   

How to convert float into 00:00 format?  
*private string ConvertTimeToString(float timeInSeconds)*  
*{*  
    *int minutes = Mathf.FloorToInt(timeInSeconds / 60);*  
    *int seconds = Mathf.FloorToInt(timeInSeconds % 60);*  
    *string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);*  
    *return formattedTime;*  
*}*  

---  

git clone the project to see how it works
