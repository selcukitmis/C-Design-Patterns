﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            var camera1 = Camera.GetCamera("NIKON");
            var camera2 = Camera.GetCamera("NIKON");
            var camera3 = Camera.GetCamera("CANON");
            var camera4 = Camera.GetCamera("CANON");
            var camera5 = Camera.GetCamera("NIKON");

            Console.WriteLine(camera1.id);
            Console.WriteLine(camera2.id);
            Console.WriteLine(camera3.id);
            Console.WriteLine(camera4.id);
            Console.WriteLine(camera5.id);

            Console.ReadLine();
        }
    }

    class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        private string brand;
        public Guid id { get; set; }
        private Camera()
        {
            id = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
