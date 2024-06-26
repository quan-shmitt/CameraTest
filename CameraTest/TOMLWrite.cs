﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nett;

namespace CameraTest
{
    static internal class TOMLWrite
    {
        static TomlTable TOMLFILE;
        public static DataStruct dataStruct; // Define the struct as a member of the class

        public static void GetToml(string filename)
        {
            TOMLFILE = Toml.ReadFile(filename);
        }

        public static void WriteToml(string filename)
        {
            Toml.WriteFile(TOMLFILE, $"Data\\Configs\\{filename}");
        }

        // Update the functions to access the values of the struct
        public static void WriteAllData(string filename)
        {

            try
            {
                TOMLFILE.Get<TomlTable>("MLPStruct").Update("HiddenLayerCount", dataStruct.HiddenLayerCount);
                TOMLFILE.Get<TomlTable>("MLPStruct").Update("LearningRate", dataStruct.LearningRate);

                // Update CNNStruct fields
                TOMLFILE.Get<TomlTable>("CNNStruct").Update("kernelSize", dataStruct.KernelSize);
                TOMLFILE.Get<TomlTable>("CNNStruct").Update("kernelSteps", dataStruct.KernelStep);
                TOMLFILE.Get<TomlTable>("CNNStruct").Update("PoolSize", dataStruct.PoolSize);
                TOMLFILE.Get<TomlTable>("CNNStruct").Update("TargetResolution", dataStruct.TargetRes);
                TOMLFILE.Get<TomlTable>("CNNStruct").Update("algorithms", dataStruct.CNNAlgo);
                TOMLFILE.Get<TomlTable>("Testing").Update("TestCount", dataStruct.TestCount);

            }
            catch { }
            WriteToml(filename);
        }


        // Define the struct within the class
        public struct DataStruct
        {
            public double[] HiddenLayerCount;
            public double LearningRate;
            public double KernelSize;
            public double KernelStep;
            public double PoolSize;
            public int[] TargetRes;
            public string[] CNNAlgo;
            public double TestCount;
            public double TestAcc;
        }
    }
}
