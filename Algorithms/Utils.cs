using System;
using System.Threading.Tasks;

namespace Algorithms;

public static class Utils
{

    static Random random = new();

    public static void Compute(int milliSeconds){
        var end = DateTime.Now + TimeSpan.FromMicroseconds(milliSeconds);
        while(DateTime.Now < end){}
    }

    public static void RandomCompute(){
        var end = DateTime.Now.AddMilliseconds(random.Next(1, 10));
        while(DateTime.Now < end){}
    }

    public static async Task RandomComputeAsync(){
        await Task.Run(() => {
            var end = DateTime.Now.AddMilliseconds(random.Next(1, 10));
            while(DateTime.Now < end){}
        });
    }

    public static async Task ComputeAsync(int milliSeconds){
        await Task.Factory.StartNew(() => {
            var end = DateTime.Now + TimeSpan.FromMicroseconds(milliSeconds);
            while(DateTime.Now < end){}
        }, TaskCreationOptions.AttachedToParent);
    }

}
