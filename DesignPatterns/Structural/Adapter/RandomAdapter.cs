﻿using System;

namespace DesignPatterns.Structural.Adapter
{
    public static class RandomAdapter
    {
        // System.Random provides only randomisation to primitive types, that are included in Int32.
        // Floating point numbers, 64 bit and unsigned 32 bit numbers cannot be generated by System.Random
        // NB: System.Random.NextDecimal() generates random [0.0 - 1.0]

        public static uint Next(this Random random, uint min, uint max)
        {
            byte[] bytes = new byte[4];
            random.NextBytes(bytes);
            return Convert.ToUInt32(bytes);
        }

        public static long Next(this Random random, long min, long max)
        {
            byte[] bytes = new byte[8];
            random.NextBytes(bytes);
            return Convert.ToInt64(bytes);
        }

        public static ulong Next(this Random random, ulong min, ulong max)
        {
            byte[] bytes = new byte[8];
            random.NextBytes(bytes);
            return Convert.ToUInt32(bytes);
        }

        public static Single Next(this Random random, Single min, Single max)
        {
            byte[] bytes = new byte[4];
            random.NextBytes(bytes);
            return Convert.ToSingle(bytes);
        }

        public static double Next(this Random random, double min, double max)
        {
            throw new NotImplementedException();
        }

        public static decimal Next(this Random random, decimal min, decimal max)
        {
            throw new NotImplementedException();
        }
    }
}
