﻿using System;
using System.Collections.Generic;
using System.Text;
using TNoodle.Puzzles;
using static TNoodle.Puzzles.CubePuzzle;
using static TNoodle.Utils.Assertion;

namespace TNoodle.Utils
{
    public static class Functions
    {
        public static event Action<string> Log;
        public static T Choose<T>(Random r, IEnumerable<T> keySet)
        {
            var chosen = default(T);
            var count = 0;
            foreach (var element in keySet)
                if (r.Next(++count) == 0)
                    chosen = element;
            Assert(count > 0);
            return chosen;
        }

        public static int BitCount(int value)
        {
            var v = (uint) value;
            uint c;

            c = v - ((v >> 1) & 0x55555555);
            c = ((c >> 2) & 0x33333333) + (c & 0x33333333);
            c = ((c >> 4) + c) & 0x0F0F0F0F;
            c = ((c >> 8) + c) & 0x00FF00FF;
            c = ((c >> 16) + c) & 0x0000FFFF;

            return (int) c;
        }

        public static int Modulo(int x, int m)
        {
            Assert(m > 0, "m must be > 0");
            var y = x % m;
            if (y < 0)
                y += m;
            return y;
        }

        public static string Join<T>(List<T> arr, string separator)
        {
            if (separator == null)
                separator = ",";

            var sb = new StringBuilder();
            for (var i = 0; i < arr.Count; i++)
            {
                if (i > 0)
                    sb.Append(separator);
                sb.Append(arr[i]);
            }
            return sb.ToString();
        }

        public static bool DeepEquals(this int[] a, int[] b)
        {
            for (var i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }

        public static bool DeepEquals(this int[,] a, int[,] b)
        {
            for (var i = 0; i < a.GetLength(0); i++)
            for (var j = 0; j < a.GetLength(1); j++)
                if (a[i, j] != b[i, j]) return false;
            return true;
        }


        public static int DeepHashCode(this int[,] a)
        {
            if (a == null)
                return 0;

            var result = 1;
            foreach (var element in a)
                result = 31 * result + element;

            return result;
        }


        public static Face OppositeFace(this Face f)
        {
            return (Face) (((int) f + 3) % 6);
        }

        // TODO We could rename faces so we can just do +6 mod 12 here instead.
        public static MegaminxPuzzle.Face? oppositeFace(this MegaminxPuzzle.Face face)
        {
            switch (face)
            {
                case MegaminxPuzzle.Face.U:
                    return MegaminxPuzzle.Face.D;
                case MegaminxPuzzle.Face.BL:
                    return MegaminxPuzzle.Face.DR;
                case MegaminxPuzzle.Face.BR:
                    return MegaminxPuzzle.Face.DL;
                case MegaminxPuzzle.Face.R:
                    return MegaminxPuzzle.Face.DBL;
                case MegaminxPuzzle.Face.F:
                    return MegaminxPuzzle.Face.B;
                case MegaminxPuzzle.Face.L:
                    return MegaminxPuzzle.Face.DBR;
                case MegaminxPuzzle.Face.D:
                    return MegaminxPuzzle.Face.U;
                case MegaminxPuzzle.Face.DR:
                    return MegaminxPuzzle.Face.BL;
                case MegaminxPuzzle.Face.DBR:
                    return MegaminxPuzzle.Face.L;
                case MegaminxPuzzle.Face.B:
                    return MegaminxPuzzle.Face.F;
                case MegaminxPuzzle.Face.DBL:
                    return MegaminxPuzzle.Face.R;
                case MegaminxPuzzle.Face.DL:
                    return MegaminxPuzzle.Face.BR;
                default:
                    return null;
            }
        }
    }
}