using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal.Utility
{
    public class SnowFlake
    {

        private static long machineId;//机器Id
        private static long datacenterId = 0L;//数据Id
        private static long sequence = 0L;//计数从零开始
        private static long twepoch = 687888001020L; //唯一时间随机量

        private static long machineIdBits = 5L;//机器码字节数
        private static long datacenterIdBits = 5L;//数据字节数
        public static long maxMachineId = -1L ^ -1L << (int)machineIdBits;//最大机器ID
        private static long maxDatacenterId = -1L ^ (-1L << (int)datacenterIdBits);//最大数据ID

        private static long sequenceBits = 12L;//计数器字节数，12个字节用来保存计数码

        private static long machineIdShift = sequenceBits;//机器码数据左移位数，计时后面计数器占用的位数
        private static long datacenterIdShift = sequenceBits + machineIdBits;
        private static long timestampLeftShift = sequenceBits + machineIdBits + datacenterIdBits;//时间戳左移位数就是机器码+计数器总字节数+数据字节数

        public static long sequenceMask = -1L ^ -1L << (int)sequenceBits;//一微秒内可以产生计数，如果达到该值则等到下一微秒再进行生成
        /*"^"按位异或*/
        private static long lastTimestamp = -1L;//最后时间戳

        private static object syncRoot = new object();//加锁对象
        static SnowFlake snowflake;

        public static SnowFlake Instance()
        {
            if(snowflake ==null)
                snowflake = new SnowFlake();
            return snowflake;
        }

        public SnowFlake()
        {
            SnowFlakes(0L, -1);
        }

        public SnowFlake(long machineId)
        {
            SnowFlakes(machineId, -1);
        }

        public SnowFlake(long machineId, long datacenterId)
        {
            SnowFlakes(machineId, -1);
        }

        private void SnowFlakes(long machineId, long datacenterId)
        {
            if (machineId >= 0)
            {
                if (machineId > maxMachineId)
                {
                    throw new Exception("机器码ID非法");
                }
                SnowFlake.machineId = machineId;
            }
            if (datacenterId >= 0)
            {
                if (datacenterId > maxDatacenterId)
                {
                    throw new Exception("数据中心ID非法");
                }
                SnowFlake.datacenterId = datacenterId;
            }
        }

    }
}
